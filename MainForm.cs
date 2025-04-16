using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using EasyModbus;
using KENDLL.Common;
using log4net;
using log4net.Appender;
using OMMAuto.CommonHelp;
using OMMAuto.Extension;
using Panuon.UI.Silver;

namespace OMMAuto
{
    public partial class MainForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm));
        private SQLiteHelper _sqLiteHelpers = null;
        private ModbusUitl _modbusUitl;
        private FrmConfig _frmConfig;

        public MainForm()
        {
            InitializeComponent();
            InitSqliteHelps();
        }

        private void InitSqliteHelps()
        {
            var sqlBasePath = GetSqliteBasePath();
            if (!Directory.Exists(sqlBasePath))
                Directory.CreateDirectory(sqlBasePath);

            string dbAddress = Path.Combine(sqlBasePath, $"CMM-BaseData.db3");
            _sqLiteHelpers = new SQLiteHelper(dbAddress);
            _sqLiteHelpers.Open();
        }

        private string GetSqliteBasePath()
        {
            string path;
            string project = "SQLiteData";
            try
            {
                path = Path.Combine(project);
            }
            catch (Exception ex)
            {
                Log.Error($"[Save][SQL] - check path error: {ex}");
                throw new Exception($"save sql error: {ex.Message}", ex);
            }
            Log.Info($"[Path] - get path: {path}");
            return path;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadLogTxt();
            LoadPlcTxt();
            PoolPlc();
        }

        private void LoadLogTxt()
        {
            this.txtLog.ScrollBars = ScrollBars.Vertical;
            this.txtLog.Text = SyncLog();
            this.txtLog.Select(this.txtLog.TextLength, 0);
            this.txtLog.ScrollToCaret();
        }

        private string SyncLog()
        {
            var appender = LogManager.GetRepository().GetAppenders().FirstOrDefault(a => a is FileAppender) as FileAppender;
            var logPath = appender.File;
            if (!File.Exists(logPath))
            {
                MessageBoxX.Show("日志文件未找到！", "提示");
                return "";
            }
            return ReadFileTail(logPath, encoding: Encoding.GetEncoding("GBK"));
        }

        private void LoadPlcTxt()
        {
            SQLiteParameter[] parameter = new SQLiteParameter[] { new SQLiteParameter("Key", "PLCIp") };
            string sql = "SELECT * FROM Cfg WHERE Key=@Key";
            DataSet dataSet = _sqLiteHelpers.ExecuteDataSet(sql, parameter);
            //var ip = dataSet.Tables[0].Rows.Count == 0 ? txtIp.Text.Trim() : dataSet.Tables[0].Rows[0]["Value"].ToString();
            if (dataSet.Tables[0].Rows.Count != 0)
                txtIp.Text = dataSet.Tables[0].Rows[0]["Value"].ToString();

            parameter = new SQLiteParameter[] { new SQLiteParameter("Key", "PLCPort") };
            dataSet = _sqLiteHelpers.ExecuteDataSet(sql, parameter);
            //var port = dataSet.Tables[0].Rows.Count == 0 ? txtPort.Text.Trim() : dataSet.Tables[0].Rows[0]["Value"].ToString();
            if (dataSet.Tables[0].Rows.Count != 0)
                txtPort.Text = dataSet.Tables[0].Rows[0]["Value"].ToString();

            ConnPlc();
        }

        public void ConnPlc()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIp.Text.Trim()))
                {
                    MessageBoxX.Show("PLC 的IP地址不能为空！", "提示");
                    return;
                }

                if (string.IsNullOrEmpty(txtPort.Text.Trim()))
                {
                    MessageBoxX.Show("PLC 的端口号不能为空！", "提示");
                    return;
                }

                _modbusUitl = ModbusUitl.getInstanceConn(txtIp.Text.Trim(), txtPort.Text.Trim().StrToInt());

                if (MessageBoxX.Show($"连接PLC成功", "提示") == MessageBoxResult.OK)
                    btnSavePLC_Click(null, null);

            }
            catch (Exception ex)
            {
                MessageBoxX.Show($"连接PLC失败: {ex.Message}", "提示");
                Log.Error($"连接PLC失败: {ex.Message}");
            }
        }

        private void PoolPlc()
        {
            var pollingService = new PollingService(
                pollingInterval: TimeSpan.FromSeconds(3),
                checkAction: async () =>
                {
                    //bool isConnected = await CheckNetworkConnection();
                    await Task.Run(CheckPlc);
                    GetProduct();
                    GetStart();

                    return true; // 始终继续轮询
                }
            );

            // 订阅错误事件
            pollingService.OnError += ex =>
                Log.Error($"Polling error: {ex.Message}");

            // 启动轮询
            pollingService.Start();

            // 停止轮询（如点击停止按钮时调用）
            // pollingService.Stop();
        }

        private void timerlog_Tick(object sender, EventArgs e)
        {
            LoadLogTxt();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnPlc();
        }

        //FormClosing是在窗体即将关闭但还未关闭时触发，这时候还可以取消关闭操作，比如弹出确认对话框，用户点击取消，那么窗体就不会关闭。
        //而FormClosed是在窗体已经关闭之后触发，这时候窗体已经不可见了，只能执行一些清理工作，比如释放资源或者记录日志，但无法阻止关闭。
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBoxX.Show("是否退出？", "提示", null, MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
                e.Cancel = true; // 阻止关闭

            //if (!isClosingByAnimation && e.CloseReason != CloseReason.ApplicationExitCall)
            //{
            //    e.Cancel = true;  // 阻止直接关闭

            //    var result = MessageBoxX.Show("是否退出？", "提示", null, MessageBoxButton.YesNo);
            //    if (result == MessageBoxResult.Yes)
            //        CloseWindow();     // 启动动画
            //}
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sqLiteHelpers.Close();
            Log.Info($"OMMAuto被关闭！！！");
        }

        public string ReadFileTail(string filePath, int bufferSize = 1024 * 15, Encoding encoding = null)
        {
            // 参数校验
            if (!File.Exists(filePath)) throw new FileNotFoundException("文件不存在", filePath);
            if (bufferSize <= 0) throw new ArgumentException(@"缓冲区大小必须大于0", nameof(bufferSize));

            // 设置编码（默认UTF-8）
            //encoding ??= Encoding.UTF8;
            if (encoding == null)
                encoding = Encoding.UTF8;

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    long fileLength = stream.Length;

                    // 处理小文件：直接全量读取
                    if (fileLength <= bufferSize)
                    {
                        byte[] fullBuffer = new byte[fileLength];
                        stream.Read(fullBuffer, 0, (int)fileLength);
                        return encoding.GetString(fullBuffer);
                    }

                    // 处理大文件：读取末尾内容
                    else
                    {
                        byte[] buffer = new byte[bufferSize];
                        // 定位到文件末尾前 bufferSize 字节的位置（需确保不越界）
                        stream.Seek(-bufferSize, SeekOrigin.End);
                        int bytesRead = stream.Read(buffer, 0, bufferSize);

                        // 处理实际读取字节数（可能小于bufferSize）
                        return encoding.GetString(buffer, 0, bytesRead);
                    }
                }
            }
            catch (IOException ex)
            {
                Log.Error($"读取文件失败: {ex.Message + ex.StackTrace}");
                throw new IOException($"读取文件失败: {ex.Message}", ex);
            }
        }

        public async Task<string> ReadFileTailAsync(string filePath, int bufferSize = 1024 * 15, Encoding encoding = null, CancellationToken cancellationToken = default)
        {
            // 参数校验
            if (!File.Exists(filePath)) throw new FileNotFoundException("文件不存在", filePath);
            if (bufferSize <= 0) throw new ArgumentException(@"缓冲区大小必须大于0", nameof(bufferSize));

            //encoding ??= Encoding.UTF8; // 默认编码
            if (encoding == null)
                encoding = Encoding.UTF8;

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, bufferSize: 4096, // 系统默认页大小
                    useAsync: true))  // 启用异步IO
                {
                    long fileLength = stream.Length;

                    // 小文件直接全量读取
                    if (fileLength <= bufferSize)
                    {
                        byte[] fullBuffer = new byte[fileLength];
                        await stream.ReadAsync(fullBuffer, 0, (int)fileLength, cancellationToken)
                                    .ConfigureAwait(false);
                        return encoding.GetString(fullBuffer);
                    }

                    // 大文件读取末尾
                    else
                    {
                        byte[] buffer = new byte[bufferSize];
                        stream.Seek(-bufferSize, SeekOrigin.End); // 定位到末尾前 bufferSize

                        int totalBytesRead = 0;
                        while (totalBytesRead < bufferSize)
                        {
                            int bytesRead = await stream.ReadAsync(
                                buffer,
                                totalBytesRead,
                                bufferSize - totalBytesRead,
                                cancellationToken
                            ).ConfigureAwait(false);

                            if (bytesRead == 0) break; // 流结束
                            totalBytesRead += bytesRead;
                        }

                        return encoding.GetString(buffer, 0, totalBytesRead);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw; // 取消操作直接抛出
            }
            catch (Exception ex)
            {
                Log.Error($"读取文件失败: {ex.Message + ex.StackTrace}");
                throw new IOException($"读取文件失败: {ex.Message}", ex);
            }
        }

        public void ReadPlc()
        {
            _modbusUitl.ReadHoldingRegisters(262, 1);
        }

        public void WritePlc()
        {
            int[] productCode = ModbusClient.ConvertStringToRegisters("你好呀");
            _modbusUitl.WriteMultipleRegisters(262, productCode); // 告知PLC终止任务//25个字符  占13位地址
            _modbusUitl.WriteMultipleRegisters(262, new int[] { 200 }); // 告知PLC终止任务
            _modbusUitl.WriteMultipleRegisters(262, new int[] { 0 });//操作指令初始化
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return; // 允许退格键
            int len = txtPort.Text.Length;
            if (len < 1 && e.KeyChar == '0')
            { // 禁止首位输入0
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar))
            { // 仅允许数字
                e.Handled = true;
            }
        }

        private void btnConfigPlcAddress_Click(object sender, EventArgs e)
        {
            if (_frmConfig == null || _frmConfig.IsDisposed)
            {
                _frmConfig = new FrmConfig(_sqLiteHelpers);
                _frmConfig.FormClosed += (s, args) => { _frmConfig = null; };
            }
            _frmConfig.Show();
            _frmConfig.BringToFront();  // 激活并置顶窗体
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (_modbusUitl != null)
                {
                    int[] productCode = ModbusClient.ConvertStringToRegisters("你好呀");
                    _modbusUitl.WriteMultipleRegisters(100, productCode);
                    //_modbusUitl.WriteMultipleRegisters(100, new int[] { 200 }); // 告知PLC终止任务
                    //var t = _modbusUitl.ReadHoldingRegisters(100, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBoxX.Show($"读取LC失败: {ex.Message}", "提示");
                Log.Error($"读取LC失败: {ex.Message}");
            }
        }

        private void btnSavePLC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIp.Text.Trim()))
            {
                MessageBoxX.Show("PLC 的IP地址不能为空！", "提示");
                return;
            }

            if (string.IsNullOrEmpty(txtPort.Text.Trim()))
            {
                MessageBoxX.Show("PLC 的端口号不能为空！", "提示");
                return;
            }

            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    {"Key", "PLCIp"}, {"Value", txtIp.Text.Trim()}, {"CreateDate", DateTime.Now}
                },
                new Dictionary<string, object>
                {
                    {"Key", "PLCPort"}, {"Value", txtPort.Text.Trim()}, {"CreateDate", DateTime.Now}
                }
            };

            SQLiteParameter[] parameter = new SQLiteParameter[] { new SQLiteParameter("Key", "PLCIp") };
            _sqLiteHelpers.Delete("Cfg", "Key=@Key", parameter);

            parameter = new SQLiteParameter[] { new SQLiteParameter("Key", "PLCPort") };
            _sqLiteHelpers.Delete("Cfg", "Key=@Key", parameter);

            foreach (var dic in data)
            {
                _sqLiteHelpers.InsertData("Cfg", dic);
            }

            MessageBoxX.Show($"保存PLCIp成功", "提示");
        }

        #region 与PLC交互

        private void CheckPlc()
        {
            if (GetPlcAddressInfo("Load_Live").Rows.Count == 0)
                return;

            if (_modbusUitl != null)
                this.BeginInvoke(new Action(() =>
                {
                    txtPlcConnect.BackColor = _modbusUitl.ReadHoldingRegisters
                        (GetPlcAddressInfo("Load_Live").Rows[0]["Address"].ToString().StrToInt(),
                        GetPlcAddressInfo("Load_Live").Rows[0]["Count"].ToString().StrToInt()).StrToInt() == 0 ?
                        Color.Red : Color.LimeGreen;
                }));
        }

        private bool GetStart()
        {
            if (GetPlcAddressInfo("Load_Start").Rows.Count == 0)
                return false;

            if (_modbusUitl != null)
                return _modbusUitl.ReadHoldingRegisters
                (GetPlcAddressInfo("Load_Start").Rows[0]["Address"].ToString().StrToInt(),
                    GetPlcAddressInfo("Load_Start").Rows[0]["Count"].ToString().StrToInt()).StrToInt() != 0;

            return false;
        }

        private void GetProduct()
        {
            if (GetPlcAddressInfo("Load_PartID").Rows.Count == 0)
                return;

            if (_modbusUitl == null) return;

            var id = _modbusUitl.ReadHoldingRegisters
            (GetPlcAddressInfo("Load_PartID").Rows[0]["Address"].ToString().StrToInt(),
                GetPlcAddressInfo("Load_PartID").Rows[0]["Count"].ToString().StrToInt());

            SQLiteParameter[] parameter = new SQLiteParameter[] { new SQLiteParameter("PrgName", id) };
            string sql = "SELECT PrgName,PrgPath FROM MeaSurePrgCfg WHERE PrgName = @PrgName";
            DataSet dataSet = _sqLiteHelpers.ExecuteDataSet(sql, parameter);
            var proId = id;
            dataSet.Tables[0].Rows[0]["PrgPath"].ToString();
            SetReady();
        }

        private void SetEnd()
        {
            if (GetPlcAddressInfo("CMM_MeasureCompleted").Rows.Count == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (GetPlcAddressInfo("CMM_MeasureCompleted").Rows[0]["Address"].ToString().StrToInt(),
                    new int[] { GetPlcAddressInfo("CMM_MeasureCompleted").Rows[0]["Count"].ToString().StrToInt() }
                    );
        }

        private void SetReady()
        {
            if (GetPlcAddressInfo("CMM_Ready").Rows.Count == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (GetPlcAddressInfo("CMM_Ready").Rows[0]["Address"].ToString().StrToInt(),
                    new int[] { GetPlcAddressInfo("CMM_Ready").Rows[0]["Count"].ToString().StrToInt() }
                );
        }

        private void SetError()
        {
            if (GetPlcAddressInfo("CMM_Alarm").Rows.Count == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (GetPlcAddressInfo("CMM_Alarm").Rows[0]["Address"].ToString().StrToInt(),
                    new int[] { GetPlcAddressInfo("CMM_Alarm").Rows[0]["Count"].ToString().StrToInt() }
                );
        }

        private DataTable GetPlcAddressInfo(string name)
        {
            DataTable dt = new DataTable();
            SQLiteParameter[] parameter = new SQLiteParameter[] { new SQLiteParameter("Name", name) };
            string sql = "SELECT * FROM PLCCfg WHERE Name=@Name";
            DataSet dataSet = _sqLiteHelpers.ExecuteDataSet(sql, parameter);
            if (dataSet.Tables[0].Rows.Count != 0)
                dt = dataSet.Tables[0];

            return dt;
        }

        #endregion
        
        #region 关闭窗体动画

        // 可选：声明动画完成事件
        public event EventHandler AnimationCompleted;
        private System.Windows.Forms.Timer closeTimer;
        private DateTime animationStart;
        private double initialHeight;
        private double initialWidth;
        private bool isClosingByAnimation = false;

        private void CloseWindow()
        {
            // 初始化定时器
            closeTimer = new System.Windows.Forms.Timer();
            closeTimer.Interval = 15; // 约60FPS
            initialHeight = this.Height;
            initialWidth = this.Width;
            animationStart = DateTime.Now;

            closeTimer.Tick += (s, e) =>
            {
                // 计算动画进度（0到1之间）
                double progress = (DateTime.Now - animationStart).TotalMilliseconds / 1000.0;

                if (progress >= 1.0)
                {
                    // 动画完成
                    closeTimer.Stop();
                    isClosingByAnimation = true;
                    this.Close();
                    AnimationCompleted?.Invoke(this, EventArgs.Empty);
                    return;
                }

                // 更新窗口尺寸
                this.Height = (int)Math.Max(initialHeight * (1 - progress), 0);
                this.Width = (int)Math.Max(initialWidth * (1 - progress), 0);

                // （可选）保持窗口居中缩放
                this.Left += (int)(initialWidth * progress / 2);
                this.Top += (int)(initialHeight * progress / 2);
            };

            closeTimer.Start();
        }

        #endregion
    }
}
