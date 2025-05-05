using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
        private readonly object _lock = new object();
        private static bool _isStart = false;
        private static bool _isStop = false;

        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm));
        private SQLiteHelper _sqLiteHelpers = null;
        private FrmConfig _frmConfig;
        private FrmQueryPlc _frmQueryPlc;
        private FrmDicConfig _frmDicConfig;
        private ModbusUitl _modbusUitl;
        private static ApiClient _apiClient;

        private delegate void LogTxtDelegate();

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

        private void InitApiClient()
        {
            _apiClient = new ApiClient(txtHttp.Text.Trim())
            {
                LogRequestResponse = msg =>
                {
                    Log.Info($"[API] {DateTime.Now:HH:mm:ss} {msg}");
                    //File.AppendAllText("api.log", $"{msg}\n\n");
                }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPlcTxt();
            InitApiClient();

            PoolUi();
            PoolGetPlc();
            PoolSetPlc();
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

            parameter = new SQLiteParameter[] { new SQLiteParameter("Key", "Http") };
            dataSet = _sqLiteHelpers.ExecuteDataSet(sql, parameter);
            if (dataSet.Tables[0].Rows.Count != 0)
                txtHttp.Text = dataSet.Tables[0].Rows[0]["Value"].ToString();

            dataSet = _sqLiteHelpers.ExecuteDataSet("SELECT * FROM PLCCfg", null);
            if (dataSet != null)
            {
                foreach (DataRow r in dataSet.Tables[0].Rows)
                {
                    Global.PlcInfos.Add(new PlcInfo
                    {
                        PlcName = r["Name"].ToString(),
                        Address = r["Address"].ToString().StrToInt(),
                        Count = r["Count"].ToString().StrToInt()
                    });
                }
            }
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

        private void PoolUi()
        {
            var pollingService = new PollingService(
                pollingInterval: TimeSpan.FromSeconds(1),
                checkAction: async () =>
                {
                    await Task.Run(LoadLogTxt);

                    return true; // 始终继续轮询
                }
            );

            // 订阅错误事件
            pollingService.OnError += ex =>
                Log.Error($"PoolUi error: {ex.Message}");

            // 启动轮询
            pollingService.Start();
        }

        private void LoadLogTxt()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new LogTxtDelegate(LoadLogTxt));
                return;
            }
            // 具体操作代码
            this.txtLog.ScrollBars = ScrollBars.Vertical;
            this.txtLog.Text = SyncLog();
            this.txtLog.Select(this.txtLog.TextLength, 0);
            this.txtLog.ScrollToCaret();
        }

        private string SyncLog()
        {
            var appender = LogManager.GetRepository().GetAppenders().FirstOrDefault(a => a is FileAppender) as FileAppender;
            var logPath = appender?.File;
            if (File.Exists(logPath)) return ReadFileTail(logPath, encoding: Encoding.GetEncoding("GBK"));
            //MessageBoxX.Show("日志文件未找到！", "提示");
            Log.Error("日志文件未找到！");
            return "";
        }

        private void PoolGetPlc()
        {
            var pollingService = new PollingService(
                pollingInterval: TimeSpan.FromSeconds(3),
                checkAction: async () =>
                {
                    await Task.Run(GetPlcHeart);
                    if (chkIsConnPLC.Checked)
                    {
                        _isStop = await Task.Run(GetStop);
                        await Task.Run(GetProductType);
                        await Task.Run(GetProductId);
                        _isStart = await Task.Run(GetStart);
                    }

                    return true; // 始终继续轮询
                }
            );

            // 订阅错误事件
            pollingService.OnError += ex =>
                Log.Error($"PoolGetPlc error: {ex.Message}");

            // 启动轮询
            pollingService.Start();

            // 停止轮询（如点击停止按钮时调用）
            // pollingService.Stop();
        }

        private void PoolSetPlc()
        {
            var pollingService = new PollingService(
                pollingInterval: TimeSpan.FromSeconds(3),
                checkAction: async () =>
                {
                    await Task.Run(() => SetPlc(new int[] { 1 }, "CMM_Live"));
                    if (_isStart)
                    {
                        await Task.Run(() => SetPlc(new int[] { 1 }, "CMM_Busy"));
                        await Task.Run(() => SetPlc(new int[] { 0 }, "CMM_Ready"));
                    }
                    else
                    {
                        await Task.Run(() => SetPlc(new int[] { 0 }, "CMM_Busy"));
                        await Task.Run(() => SetPlc(new int[] { 1 }, "CMM_Ready"));
                    }

                    if (chkIsConnPLC.Checked)
                        await Task.Run(() => SetPlc(new int[] { 1 }, "CMM_Auto"));
                    else
                        await Task.Run(() => SetPlc(new int[] { 0 }, "CMM_Auto"));

                    return true; // 始终继续轮询
                }
            );

            // 订阅错误事件
            pollingService.OnError += ex =>
                Log.Error($"PoolSetPlc error: {ex.Message}");

            // 启动轮询
            pollingService.Start();

            // 停止轮询（如点击停止按钮时调用）
            // pollingService.Stop();
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
            //try
            //{
            //    if (_modbusUitl != null)
            //    {
            //        if (GetPlcAddressInfo("TEST").Rows.Count != 0)
            //        {
            //            _modbusUitl.WriteMultipleRegisters(GetPlcAddressInfo("TEST").Rows[0]["Address"].ToString().StrToInt(),
            //                ModbusClient.ConvertStringToRegisters(txtWrite.Text.Trim()));

            //            txtRead.Text = _modbusUitl.ReadHoldingRegistersConverString
            //                (GetPlcAddressInfo("TEST").Rows[0]["Address"].ToString().StrToInt(),
            //                GetPlcAddressInfo("TEST").Rows[0]["Count"].ToString().StrToInt(),
            //                txtWrite.Text.Trim().Length + 1).Replace("\0", "");

            //            //_modbusUitl.WriteMultipleRegisters(100, new int[] { 200 }); // 告知PLC终止任务
            //            //var t = _modbusUitl.ReadHoldingRegisters(100, 1);
            //        }
            //        else
            //        {
            //            MessageBoxX.Show("PLC信号地址【TEST】没有配置", "提示");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBoxX.Show($"读取PLC失败: {ex.Message}", "提示");
            //    Log.Error($"读取PLC失败: {ex.Message}");
            //}
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

        #region GET

        private async void GetPlcHeart()
        {
            await Task.Run(() =>
            {
                if (Global.PlcInfos.Count(p => p.PlcName == "Load_Live") == 0) return;
                if (_modbusUitl == null) return;

                int temp = 0;
                lock (_lock)
                {
                    temp = _modbusUitl.ReadHoldingRegisters
                    (Global.PlcInfos.First(p => p.PlcName == "Load_Live").Address,
                        Global.PlcInfos.First(p => p.PlcName == "Load_Live").Count).StrToInt();
                }
                Log.Info($"心跳信号：{temp}");
                this.BeginInvoke(new Action(() =>
                {
                    txtPlcConnect.BackColor = temp != 1 ? Color.Red : Color.LimeGreen;
                    lblPlcState.Text = temp != 1 ? "PLC连接断开......" : "";
                }));
            });
        }
        //plc收到结束信息时置0，开始和结束。表示这个流程结束(plc置0，或者我这边结束写0)
        private bool GetStart()
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "Load_Start") == 0) return false;
            if (_modbusUitl == null) return false;

            int temp = 0;
            lock (_lock)
            {
                temp = _modbusUitl.ReadHoldingRegisters(
                    Global.PlcInfos.First(p => p.PlcName == "Load_Start").Address,
                    Global.PlcInfos.First(p => p.PlcName == "Load_Start").Count).StrToInt();
            }
            Log.Info($"启动信号:{temp}");
            return temp == 1;
        }

        private async void GetProductType()
        {
            await Task.Run(() =>
            {
                if (Global.PlcInfos.Count(p => p.PlcName == "Load_PartType") == 0) return;
                if (_modbusUitl == null) return;

                string type = "";
                lock (_lock)
                {
                    type = _modbusUitl.ReadHoldingRegistersConverString
                    (Global.PlcInfos.First(p => p.PlcName == "Load_PartType").Address,
                        Global.PlcInfos.First(p => p.PlcName == "Load_PartType").Count,
                        Global.PlcInfos.First(p => p.PlcName == "Load_PartType").Count).Replace("\0", "");

                }
                Log.Info($"收到类型码：{type}");

                //if (txtTypeKey.Text.Trim() != type && !string.IsNullOrEmpty(type))
                //{
                //    SQLiteParameter[] parameter = new SQLiteParameter[] { new SQLiteParameter("Type", type) };
                //    string sql = "SELECT PrgName,PrgPath,Type FROM MeaSurePrgCfg WHERE Type = @Type";
                //    DataSet dataSet = _sqLiteHelpers.ExecuteDataSet(sql, parameter);
                //    if (dataSet.Tables[0].Rows.Count == 0)
                //    {
                //        Log.Error($"类型码:{type}的程式没有维护，无法启动！！！");
                //    }
                //    else
                //    {
                //        this.BeginInvoke(new Action(() =>
                //        {
                //            txtTypeKey.Text = type;
                //            txtType.Text = type;
                //            txtMeasureName.Text = dataSet.Tables[0].Rows[0]["PrgName"].ToString();
                //            txtMeasureProgram.Text = dataSet.Tables[0].Rows[0]["PrgPath"].ToString();
                //        }));

                //        if (!_isStart)
                //            SetPlc(new int[] { 1 }, "CMM_Ready");
                //        else
                //            Log.Error("运行中！！！");
                //    }
                //}
            });
        }

        private async void GetProductId()
        {
            await Task.Run(() =>
            {
                if (Global.PlcInfos.Count(p => p.PlcName == "Load_PartID") == 0) return;
                if (_modbusUitl == null) return;

                string temp = "";
                lock (_lock)
                {
                    temp = _modbusUitl.ReadHoldingRegistersConverString
                    (Global.PlcInfos.First(p => p.PlcName == "Load_PartID").Address,
                        Global.PlcInfos.First(p => p.PlcName == "Load_PartID").Count,
                        Global.PlcInfos.First(p => p.PlcName == "Load_PartID").Count).Replace("\0", "");
                }
                Log.Info($"收到工件码：{temp}");
                this.BeginInvoke(new Action(() =>
                {
                    //txtWorkPiece.Text = temp;
                }));
            });
        }

        private bool GetStop()
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "Load_EStop") == 0) return false;
            if (_modbusUitl == null) return false;

            int temp = 0;
            lock (_lock)
            {
                temp = _modbusUitl.ReadHoldingRegisters
                (Global.PlcInfos.First(p => p.PlcName == "Load_EStop").Address,
                    Global.PlcInfos.First(p => p.PlcName == "Load_EStop").Count).StrToInt();
            }
            Log.Info($"急停信号：{temp}");
            return temp == 1;
        }

        #endregion

        #region SET
        //需要PLC置位
        private void SetEnd(int value)
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_MeasureCompleted") == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (Global.PlcInfos.First(p => p.PlcName == "CMM_MeasureCompleted").Address,
                    new int[] { value }
                    );
        }

        private void SetReady(int value)
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_Ready") == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (Global.PlcInfos.First(p => p.PlcName == "CMM_Ready").Address,
                    new int[] { value }
                );
        }
        //需要PLC置位
        private void SetError(int value)
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_Alarm") == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (Global.PlcInfos.First(p => p.PlcName == "CMM_Alarm").Address,
                    new int[] { value }
                );
        }

        private void SetBusy(int value)
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_Busy") == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (Global.PlcInfos.First(p => p.PlcName == "CMM_Busy").Address,
                    new int[] { value }
                );
        }

        private void SetConnectPlc(int value)
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_Live") == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (Global.PlcInfos.First(p => p.PlcName == "CMM_Live").Address,
                    new int[] { value }
                );
        }

        private void SetType()
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_AckParType") == 0)
                return;

            //_modbusUitl?.WriteMultipleRegisters
            //(Global.PlcInfos.First(p => p.PlcName == "CMM_AckParType").Address,
            //    ModbusClient.ConvertStringToRegisters(txtType.Text.Trim())
            //);
        }

        private void SetId()
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_AckPartID") == 0)
                return;

            //_modbusUitl?.WriteMultipleRegisters
            //(Global.PlcInfos.First(p => p.PlcName == "CMM_AckPartID").Address,
            //    ModbusClient.ConvertStringToRegisters(txtWorkPiece.Text.Trim())
            //);
        }

        private void SetSafetyPos(int value)
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_SafetyPos") == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (Global.PlcInfos.First(p => p.PlcName == "CMM_SafetyPos").Address,
                    new int[] { value }
                );
        }

        private void SetAuto(int value)
        {
            if (Global.PlcInfos.Count(p => p.PlcName == "CMM_Auto") == 0)
                return;

            if (_modbusUitl != null)
                _modbusUitl.WriteMultipleRegisters
                (Global.PlcInfos.First(p => p.PlcName == "CMM_Auto").Address,
                    new int[] { value }
                );
        }

        private async void SetPlc(int[] value, string type)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (Global.PlcInfos.Count(p => p.PlcName == type) == 0) return;
                    if (_modbusUitl == null) return;

                    Log.Info($"写入PLC,写入值：{string.Join(", ", value ?? Array.Empty<int>())}，" + $"写入类型：{type}");
                    lock (_lock)
                    {
                        _modbusUitl?.WriteMultipleRegisters(Global.PlcInfos.First(p => p.PlcName == type).Address, value);
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"写入PLC失败,写入值：{string.Join(", ", value ?? Array.Empty<int>())}，" +
                              $"写入类型：{type}，失败原因：{e.Message + e.StackTrace}");
                }
            });
        }

        #endregion

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

        private async void btnTest_Click(object sender, EventArgs e)
        {
            // 初始化客户端
            //var apiClient = new ApiClient("https://api.example.com/v1");
            // 设置认证令牌
            _apiClient.SetBearerToken("your-access-token");

            try
            {
                // GET 请求示例
                //var user = await apiClient.GetAsync<User>("/users/123", new Dictionary<string, string>
                //{
                //    {"include", "profile"}
                //});

                // POST 请求示例
                var newOrder = await _apiClient.PostAsync<User>("/orders", new
                {
                    productId = 456,
                    quantity = 2
                });
            }
            catch (HttpRequestException ex)
            {
                Log.Error($@"网络请求错误: {ex.Message}");
                //Console.WriteLine($@"网络请求错误: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Log.Error($@"数据处理错误: {ex.Message}");
                //Console.WriteLine($@"数据处理错误: {ex.Message}");
            }
        }

        private void btnSaveHttp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHttp.Text.Trim()))
            {
                MessageBoxX.Show("接口地址不能为空！", "提示");
                return;
            }

            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    {"Key", "Http"}, {"Value", txtHttp.Text.Trim()}, {"CreateDate", DateTime.Now}
                }
            };

            SQLiteParameter[] parameter = new SQLiteParameter[] { new SQLiteParameter("Key", "Http") };
            _sqLiteHelpers.Delete("Cfg", "Key=@Key", parameter);

            foreach (var dic in data)
            {
                _sqLiteHelpers.InsertData("Cfg", dic);
            }

            var result = MessageBoxX.Show($"保存接口地址成功！", "提示");

            if (result == MessageBoxResult.OK)
                InitApiClient();
        }

        private void btnQueryPlc_Click(object sender, EventArgs e)
        {
            if (_frmQueryPlc == null || _frmQueryPlc.IsDisposed)
            {
                _frmQueryPlc = new FrmQueryPlc(_sqLiteHelpers, _modbusUitl);
                _frmQueryPlc.FormClosed += (s, args) => { _frmQueryPlc = null; };
            }
            _frmQueryPlc.Show();
            _frmQueryPlc.BringToFront();  // 激活并置顶窗体
        }

        private void btnDicConfig_Click(object sender, EventArgs e)
        {
            if (_frmDicConfig == null || _frmDicConfig.IsDisposed)
            {
                _frmDicConfig = new FrmDicConfig(_sqLiteHelpers);
                _frmDicConfig.FormClosed += (s, args) => { _frmDicConfig = null; };
            }
            _frmDicConfig.Show();
            _frmDicConfig.BringToFront();  // 激活并置顶窗体
        }
    }

    public class PlcInfo
    {
        public string PlcName { get; set; }

        public int Address { get; set; }

        public int Count { get; set; }
    }

    public class Global
    {
        public static List<PlcInfo> PlcInfos = new List<PlcInfo>();
    }

    public class User
    {
        public string include { get; set; }

        public int profile { get; set; }
    }
}
