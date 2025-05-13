
namespace OMMAuto
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panelMidRight = new System.Windows.Forms.Panel();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.panelOperate = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDicConfig = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSaveHttp = new System.Windows.Forms.Button();
            this.panelAgvOperate = new System.Windows.Forms.Panel();
            this.grpAgvOperate = new System.Windows.Forms.GroupBox();
            this.lblPlcState = new System.Windows.Forms.Label();
            this.btnSavePLC = new System.Windows.Forms.Button();
            this.btnQueryPlc = new System.Windows.Forms.Button();
            this.btnConfigPlcAddress = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panelState = new System.Windows.Forms.Panel();
            this.panelAgvState = new System.Windows.Forms.Panel();
            this.grpAgvConnection = new System.Windows.Forms.GroupBox();
            this.chkIsConnPLC = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPlcConnect = new System.Windows.Forms.TextBox();
            this.txtSlaveId = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCommInfo = new System.Windows.Forms.Label();
            this.grpCmmState = new System.Windows.Forms.GroupBox();
            this.chkIsSend = new System.Windows.Forms.CheckBox();
            this.txtHttp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkIsStatusCheck = new System.Windows.Forms.CheckBox();
            this.txtWorkPiece = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPreOrEnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExit = new System.Windows.Forms.TextBox();
            this.txtRun = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.txtPause = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIwpCfg = new System.Windows.Forms.Button();
            this.panelMiddle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.panelMidRight.SuspendLayout();
            this.grpRight.SuspendLayout();
            this.panelOperate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelAgvOperate.SuspendLayout();
            this.grpAgvOperate.SuspendLayout();
            this.panelState.SuspendLayout();
            this.panelAgvState.SuspendLayout();
            this.grpAgvConnection.SuspendLayout();
            this.grpCmmState.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.panel1);
            this.panelMiddle.Controls.Add(this.panelMidRight);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 0);
            this.panelMiddle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(1280, 857);
            this.panelMiddle.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 857);
            this.panel1.TabIndex = 10;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(0, 0);
            this.grpLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLog.Name = "grpLog";
            this.grpLog.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLog.Size = new System.Drawing.Size(930, 857);
            this.grpLog.TabIndex = 1;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "系统日志";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Azure;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 20);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(924, 833);
            this.txtLog.TabIndex = 0;
            // 
            // panelMidRight
            // 
            this.panelMidRight.Controls.Add(this.grpRight);
            this.panelMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMidRight.Location = new System.Drawing.Point(930, 0);
            this.panelMidRight.Name = "panelMidRight";
            this.panelMidRight.Size = new System.Drawing.Size(350, 857);
            this.panelMidRight.TabIndex = 9;
            // 
            // grpRight
            // 
            this.grpRight.Controls.Add(this.panelOperate);
            this.grpRight.Controls.Add(this.panelState);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRight.Location = new System.Drawing.Point(0, 0);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(350, 857);
            this.grpRight.TabIndex = 8;
            this.grpRight.TabStop = false;
            // 
            // panelOperate
            // 
            this.panelOperate.Controls.Add(this.groupBox1);
            this.panelOperate.Controls.Add(this.panelAgvOperate);
            this.panelOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOperate.Location = new System.Drawing.Point(3, 448);
            this.panelOperate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelOperate.Name = "panelOperate";
            this.panelOperate.Size = new System.Drawing.Size(344, 406);
            this.panelOperate.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIwpCfg);
            this.groupBox1.Controls.Add(this.btnDicConfig);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.btnSaveHttp);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 221);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(344, 185);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OMM操作";
            // 
            // btnDicConfig
            // 
            this.btnDicConfig.BackColor = System.Drawing.Color.LightBlue;
            this.btnDicConfig.FlatAppearance.BorderSize = 0;
            this.btnDicConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnDicConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnDicConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDicConfig.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnDicConfig.Location = new System.Drawing.Point(52, 78);
            this.btnDicConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDicConfig.Name = "btnDicConfig";
            this.btnDicConfig.Size = new System.Drawing.Size(96, 42);
            this.btnDicConfig.TabIndex = 22;
            this.btnDicConfig.Text = "数据字典";
            this.btnDicConfig.UseVisualStyleBackColor = true;
            this.btnDicConfig.Click += new System.EventHandler(this.btnDicConfig_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.LightBlue;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnTest.Location = new System.Drawing.Point(52, 26);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(96, 42);
            this.btnTest.TabIndex = 21;
            this.btnTest.Text = "测  试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSaveHttp
            // 
            this.btnSaveHttp.BackColor = System.Drawing.Color.LightBlue;
            this.btnSaveHttp.FlatAppearance.BorderSize = 0;
            this.btnSaveHttp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnSaveHttp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSaveHttp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveHttp.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSaveHttp.Location = new System.Drawing.Point(194, 26);
            this.btnSaveHttp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveHttp.Name = "btnSaveHttp";
            this.btnSaveHttp.Size = new System.Drawing.Size(96, 42);
            this.btnSaveHttp.TabIndex = 2;
            this.btnSaveHttp.Text = "保存接口地址";
            this.btnSaveHttp.UseVisualStyleBackColor = true;
            this.btnSaveHttp.Click += new System.EventHandler(this.btnSaveHttp_Click);
            // 
            // panelAgvOperate
            // 
            this.panelAgvOperate.Controls.Add(this.grpAgvOperate);
            this.panelAgvOperate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAgvOperate.Location = new System.Drawing.Point(0, 0);
            this.panelAgvOperate.Name = "panelAgvOperate";
            this.panelAgvOperate.Size = new System.Drawing.Size(344, 221);
            this.panelAgvOperate.TabIndex = 5;
            // 
            // grpAgvOperate
            // 
            this.grpAgvOperate.Controls.Add(this.lblPlcState);
            this.grpAgvOperate.Controls.Add(this.btnSavePLC);
            this.grpAgvOperate.Controls.Add(this.btnQueryPlc);
            this.grpAgvOperate.Controls.Add(this.btnConfigPlcAddress);
            this.grpAgvOperate.Controls.Add(this.btnConnect);
            this.grpAgvOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAgvOperate.Location = new System.Drawing.Point(0, 0);
            this.grpAgvOperate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAgvOperate.Name = "grpAgvOperate";
            this.grpAgvOperate.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAgvOperate.Size = new System.Drawing.Size(344, 221);
            this.grpAgvOperate.TabIndex = 4;
            this.grpAgvOperate.TabStop = false;
            this.grpAgvOperate.Text = "PLC操作";
            // 
            // lblPlcState
            // 
            this.lblPlcState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlcState.AutoSize = true;
            this.lblPlcState.BackColor = System.Drawing.Color.Red;
            this.lblPlcState.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPlcState.ForeColor = System.Drawing.Color.White;
            this.lblPlcState.Location = new System.Drawing.Point(22, 134);
            this.lblPlcState.Name = "lblPlcState";
            this.lblPlcState.Size = new System.Drawing.Size(300, 33);
            this.lblPlcState.TabIndex = 10;
            this.lblPlcState.Text = "PLC连接断开......";
            this.lblPlcState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSavePLC
            // 
            this.btnSavePLC.BackColor = System.Drawing.Color.LightBlue;
            this.btnSavePLC.FlatAppearance.BorderSize = 0;
            this.btnSavePLC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnSavePLC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSavePLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePLC.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSavePLC.Location = new System.Drawing.Point(194, 76);
            this.btnSavePLC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSavePLC.Name = "btnSavePLC";
            this.btnSavePLC.Size = new System.Drawing.Size(96, 42);
            this.btnSavePLC.TabIndex = 8;
            this.btnSavePLC.Text = "保存PLCIP";
            this.btnSavePLC.UseVisualStyleBackColor = true;
            this.btnSavePLC.Click += new System.EventHandler(this.btnSavePLC_Click);
            // 
            // btnQueryPlc
            // 
            this.btnQueryPlc.BackColor = System.Drawing.Color.LightBlue;
            this.btnQueryPlc.FlatAppearance.BorderSize = 0;
            this.btnQueryPlc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnQueryPlc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnQueryPlc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryPlc.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnQueryPlc.Location = new System.Drawing.Point(52, 76);
            this.btnQueryPlc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQueryPlc.Name = "btnQueryPlc";
            this.btnQueryPlc.Size = new System.Drawing.Size(96, 42);
            this.btnQueryPlc.TabIndex = 3;
            this.btnQueryPlc.Text = "查看PLC值";
            this.btnQueryPlc.UseVisualStyleBackColor = true;
            this.btnQueryPlc.Click += new System.EventHandler(this.btnQueryPlc_Click);
            // 
            // btnConfigPlcAddress
            // 
            this.btnConfigPlcAddress.BackColor = System.Drawing.Color.LightBlue;
            this.btnConfigPlcAddress.FlatAppearance.BorderSize = 0;
            this.btnConfigPlcAddress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnConfigPlcAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnConfigPlcAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigPlcAddress.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnConfigPlcAddress.Location = new System.Drawing.Point(194, 26);
            this.btnConfigPlcAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfigPlcAddress.Name = "btnConfigPlcAddress";
            this.btnConfigPlcAddress.Size = new System.Drawing.Size(96, 42);
            this.btnConfigPlcAddress.TabIndex = 2;
            this.btnConfigPlcAddress.Text = "配置PLC地址";
            this.btnConfigPlcAddress.UseVisualStyleBackColor = true;
            this.btnConfigPlcAddress.Click += new System.EventHandler(this.btnConfigPlcAddress_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.LightBlue;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnConnect.Location = new System.Drawing.Point(52, 26);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 42);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "开始连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panelState
            // 
            this.panelState.Controls.Add(this.panelAgvState);
            this.panelState.Controls.Add(this.grpCmmState);
            this.panelState.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelState.Location = new System.Drawing.Point(3, 19);
            this.panelState.Name = "panelState";
            this.panelState.Size = new System.Drawing.Size(344, 429);
            this.panelState.TabIndex = 6;
            // 
            // panelAgvState
            // 
            this.panelAgvState.Controls.Add(this.grpAgvConnection);
            this.panelAgvState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAgvState.Location = new System.Drawing.Point(0, 241);
            this.panelAgvState.Name = "panelAgvState";
            this.panelAgvState.Size = new System.Drawing.Size(344, 188);
            this.panelAgvState.TabIndex = 4;
            // 
            // grpAgvConnection
            // 
            this.grpAgvConnection.Controls.Add(this.chkIsConnPLC);
            this.grpAgvConnection.Controls.Add(this.label11);
            this.grpAgvConnection.Controls.Add(this.txtPlcConnect);
            this.grpAgvConnection.Controls.Add(this.txtSlaveId);
            this.grpAgvConnection.Controls.Add(this.txtPort);
            this.grpAgvConnection.Controls.Add(this.txtIp);
            this.grpAgvConnection.Controls.Add(this.label8);
            this.grpAgvConnection.Controls.Add(this.label7);
            this.grpAgvConnection.Controls.Add(this.label6);
            this.grpAgvConnection.Controls.Add(this.lblCommInfo);
            this.grpAgvConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAgvConnection.Location = new System.Drawing.Point(0, 0);
            this.grpAgvConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAgvConnection.Name = "grpAgvConnection";
            this.grpAgvConnection.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAgvConnection.Size = new System.Drawing.Size(344, 188);
            this.grpAgvConnection.TabIndex = 3;
            this.grpAgvConnection.TabStop = false;
            this.grpAgvConnection.Text = "PLC通讯";
            // 
            // chkIsConnPLC
            // 
            this.chkIsConnPLC.AutoSize = true;
            this.chkIsConnPLC.Checked = true;
            this.chkIsConnPLC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsConnPLC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIsConnPLC.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkIsConnPLC.Location = new System.Drawing.Point(195, 75);
            this.chkIsConnPLC.Name = "chkIsConnPLC";
            this.chkIsConnPLC.Size = new System.Drawing.Size(49, 21);
            this.chkIsConnPLC.TabIndex = 17;
            this.chkIsConnPLC.Text = "联机";
            this.chkIsConnPLC.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(183, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "连接";
            // 
            // txtPlcConnect
            // 
            this.txtPlcConnect.BackColor = System.Drawing.Color.Red;
            this.txtPlcConnect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlcConnect.Location = new System.Drawing.Point(223, 114);
            this.txtPlcConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPlcConnect.Name = "txtPlcConnect";
            this.txtPlcConnect.Size = new System.Drawing.Size(21, 16);
            this.txtPlcConnect.TabIndex = 15;
            // 
            // txtSlaveId
            // 
            this.txtSlaveId.Enabled = false;
            this.txtSlaveId.Location = new System.Drawing.Point(105, 111);
            this.txtSlaveId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSlaveId.Name = "txtSlaveId";
            this.txtSlaveId.Size = new System.Drawing.Size(64, 23);
            this.txtSlaveId.TabIndex = 14;
            this.txtSlaveId.Text = "1";
            this.txtSlaveId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(105, 74);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(64, 23);
            this.txtPort.TabIndex = 13;
            this.txtPort.Text = "502";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(105, 37);
            this.txtIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(139, 23);
            this.txtIp.TabIndex = 12;
            this.txtIp.Text = "127.0.1.1";
            this.txtIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(32, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Slave ID：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(32, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Port：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(32, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "IP：";
            // 
            // lblCommInfo
            // 
            this.lblCommInfo.AutoSize = true;
            this.lblCommInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCommInfo.ForeColor = System.Drawing.Color.Red;
            this.lblCommInfo.Location = new System.Drawing.Point(32, 151);
            this.lblCommInfo.Name = "lblCommInfo";
            this.lblCommInfo.Size = new System.Drawing.Size(229, 16);
            this.lblCommInfo.TabIndex = 8;
            this.lblCommInfo.Text = "注：修改完要重新连接并保存";
            this.lblCommInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpCmmState
            // 
            this.grpCmmState.Controls.Add(this.textBox1);
            this.grpCmmState.Controls.Add(this.label1);
            this.grpCmmState.Controls.Add(this.txtPause);
            this.grpCmmState.Controls.Add(this.chkIsSend);
            this.grpCmmState.Controls.Add(this.txtHttp);
            this.grpCmmState.Controls.Add(this.label14);
            this.grpCmmState.Controls.Add(this.chkIsStatusCheck);
            this.grpCmmState.Controls.Add(this.txtWorkPiece);
            this.grpCmmState.Controls.Add(this.label2);
            this.grpCmmState.Controls.Add(this.txtType);
            this.grpCmmState.Controls.Add(this.label12);
            this.grpCmmState.Controls.Add(this.label10);
            this.grpCmmState.Controls.Add(this.txtPreOrEnd);
            this.grpCmmState.Controls.Add(this.label5);
            this.grpCmmState.Controls.Add(this.label4);
            this.grpCmmState.Controls.Add(this.txtExit);
            this.grpCmmState.Controls.Add(this.txtRun);
            this.grpCmmState.Controls.Add(this.label3);
            this.grpCmmState.Controls.Add(this.label9);
            this.grpCmmState.Controls.Add(this.txtOther);
            this.grpCmmState.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCmmState.Location = new System.Drawing.Point(0, 0);
            this.grpCmmState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCmmState.Name = "grpCmmState";
            this.grpCmmState.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCmmState.Size = new System.Drawing.Size(344, 241);
            this.grpCmmState.TabIndex = 0;
            this.grpCmmState.TabStop = false;
            this.grpCmmState.Text = "OMM软件状态";
            // 
            // chkIsSend
            // 
            this.chkIsSend.AutoSize = true;
            this.chkIsSend.Checked = true;
            this.chkIsSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIsSend.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkIsSend.Location = new System.Drawing.Point(249, 160);
            this.chkIsSend.Name = "chkIsSend";
            this.chkIsSend.Size = new System.Drawing.Size(73, 21);
            this.chkIsSend.TabIndex = 35;
            this.chkIsSend.Text = "发送监控";
            this.chkIsSend.UseVisualStyleBackColor = true;
            // 
            // txtHttp
            // 
            this.txtHttp.Location = new System.Drawing.Point(99, 199);
            this.txtHttp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHttp.Name = "txtHttp";
            this.txtHttp.Size = new System.Drawing.Size(223, 23);
            this.txtHttp.TabIndex = 34;
            this.txtHttp.Text = "http://localhost:8200/autolink";
            this.txtHttp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(20, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 17);
            this.label14.TabIndex = 33;
            this.label14.Text = "OMM接口：";
            // 
            // chkIsStatusCheck
            // 
            this.chkIsStatusCheck.AutoSize = true;
            this.chkIsStatusCheck.Checked = true;
            this.chkIsStatusCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsStatusCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIsStatusCheck.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkIsStatusCheck.Location = new System.Drawing.Point(249, 120);
            this.chkIsStatusCheck.Name = "chkIsStatusCheck";
            this.chkIsStatusCheck.Size = new System.Drawing.Size(73, 21);
            this.chkIsStatusCheck.TabIndex = 32;
            this.chkIsStatusCheck.Text = "状态检测";
            this.chkIsStatusCheck.UseVisualStyleBackColor = true;
            // 
            // txtWorkPiece
            // 
            this.txtWorkPiece.Location = new System.Drawing.Point(99, 159);
            this.txtWorkPiece.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWorkPiece.Name = "txtWorkPiece";
            this.txtWorkPiece.Size = new System.Drawing.Size(145, 23);
            this.txtWorkPiece.TabIndex = 31;
            this.txtWorkPiece.Text = "ABCD00001";
            this.txtWorkPiece.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(20, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "工件码：";
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(99, 119);
            this.txtType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(145, 23);
            this.txtType.TabIndex = 29;
            this.txtType.Text = "ABCD";
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(20, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 28;
            this.label12.Text = "类型码：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(26, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "接口断开";
            // 
            // txtPreOrEnd
            // 
            this.txtPreOrEnd.BackColor = System.Drawing.Color.White;
            this.txtPreOrEnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPreOrEnd.Location = new System.Drawing.Point(99, 27);
            this.txtPreOrEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPreOrEnd.Name = "txtPreOrEnd";
            this.txtPreOrEnd.Size = new System.Drawing.Size(21, 16);
            this.txtPreOrEnd.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(58, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "运行";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(153, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "异常";
            // 
            // txtExit
            // 
            this.txtExit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExit.Location = new System.Drawing.Point(99, 78);
            this.txtExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExit.Name = "txtExit";
            this.txtExit.Size = new System.Drawing.Size(21, 16);
            this.txtExit.TabIndex = 23;
            // 
            // txtRun
            // 
            this.txtRun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRun.Location = new System.Drawing.Point(194, 27);
            this.txtRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRun.Name = "txtRun";
            this.txtRun.Size = new System.Drawing.Size(21, 16);
            this.txtRun.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(243, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "空闲";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(153, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "离线";
            // 
            // txtOther
            // 
            this.txtOther.BackColor = System.Drawing.Color.LimeGreen;
            this.txtOther.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOther.Location = new System.Drawing.Point(194, 78);
            this.txtOther.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(21, 16);
            this.txtOther.TabIndex = 19;
            // 
            // txtPause
            // 
            this.txtPause.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPause.Location = new System.Drawing.Point(285, 27);
            this.txtPause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPause.Name = "txtPause";
            this.txtPause.Size = new System.Drawing.Size(21, 16);
            this.txtPause.TabIndex = 36;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(285, 78);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(21, 16);
            this.textBox1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(243, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "完成";
            // 
            // btnIwpCfg
            // 
            this.btnIwpCfg.BackColor = System.Drawing.Color.LightBlue;
            this.btnIwpCfg.FlatAppearance.BorderSize = 0;
            this.btnIwpCfg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnIwpCfg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnIwpCfg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIwpCfg.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnIwpCfg.Location = new System.Drawing.Point(195, 78);
            this.btnIwpCfg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIwpCfg.Name = "btnIwpCfg";
            this.btnIwpCfg.Size = new System.Drawing.Size(96, 42);
            this.btnIwpCfg.TabIndex = 23;
            this.btnIwpCfg.Text = "IWP配置";
            this.btnIwpCfg.UseVisualStyleBackColor = true;
            this.btnIwpCfg.Click += new System.EventHandler(this.btnIwpCfg_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1280, 857);
            this.Controls.Add(this.panelMiddle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoOMM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMiddle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.panelMidRight.ResumeLayout(false);
            this.grpRight.ResumeLayout(false);
            this.panelOperate.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelAgvOperate.ResumeLayout(false);
            this.grpAgvOperate.ResumeLayout(false);
            this.grpAgvOperate.PerformLayout();
            this.panelState.ResumeLayout(false);
            this.panelAgvState.ResumeLayout(false);
            this.grpAgvConnection.ResumeLayout(false);
            this.grpAgvConnection.PerformLayout();
            this.grpCmmState.ResumeLayout(false);
            this.grpCmmState.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.GroupBox grpCmmState;
        private System.Windows.Forms.Panel panelOperate;
        private System.Windows.Forms.GroupBox grpAgvConnection;
        private System.Windows.Forms.GroupBox grpAgvOperate;
        private System.Windows.Forms.Button btnQueryPlc;
        private System.Windows.Forms.Button btnConfigPlcAddress;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panelState;
        private System.Windows.Forms.Panel panelAgvState;
        private System.Windows.Forms.Panel panelAgvOperate;
        private System.Windows.Forms.GroupBox grpRight;
        private System.Windows.Forms.Panel panelMidRight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSlaveId;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblCommInfo;
        private System.Windows.Forms.Button btnSavePLC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPlcConnect;
        private System.Windows.Forms.CheckBox chkIsConnPLC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox chkIsStatusCheck;
        private System.Windows.Forms.TextBox txtWorkPiece;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPreOrEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExit;
        private System.Windows.Forms.TextBox txtRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.TextBox txtHttp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveHttp;
        private System.Windows.Forms.Label lblPlcState;
        private System.Windows.Forms.Button btnDicConfig;
        private System.Windows.Forms.CheckBox chkIsSend;
        private System.Windows.Forms.TextBox txtPause;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIwpCfg;
    }
}

