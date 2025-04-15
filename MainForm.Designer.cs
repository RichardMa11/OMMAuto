
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panelMidRight = new System.Windows.Forms.Panel();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.panelOperate = new System.Windows.Forms.Panel();
            this.panelAgvOperate = new System.Windows.Forms.Panel();
            this.grpAgvOperate = new System.Windows.Forms.GroupBox();
            this.btnSavePLC = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
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
            this.timerlog = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.panelMiddle.SuspendLayout();
            this.panelMidRight.SuspendLayout();
            this.grpRight.SuspendLayout();
            this.panelOperate.SuspendLayout();
            this.panelAgvOperate.SuspendLayout();
            this.grpAgvOperate.SuspendLayout();
            this.panelState.SuspendLayout();
            this.panelAgvState.SuspendLayout();
            this.grpAgvConnection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpLog.SuspendLayout();
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
            this.panelMiddle.Size = new System.Drawing.Size(980, 557);
            this.panelMiddle.TabIndex = 0;
            // 
            // panelMidRight
            // 
            this.panelMidRight.Controls.Add(this.grpRight);
            this.panelMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMidRight.Location = new System.Drawing.Point(630, 0);
            this.panelMidRight.Name = "panelMidRight";
            this.panelMidRight.Size = new System.Drawing.Size(350, 557);
            this.panelMidRight.TabIndex = 9;
            // 
            // grpRight
            // 
            this.grpRight.Controls.Add(this.panelOperate);
            this.grpRight.Controls.Add(this.panelState);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRight.Location = new System.Drawing.Point(0, 0);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(350, 557);
            this.grpRight.TabIndex = 8;
            this.grpRight.TabStop = false;
            // 
            // panelOperate
            // 
            this.panelOperate.Controls.Add(this.panelAgvOperate);
            this.panelOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOperate.Location = new System.Drawing.Point(3, 349);
            this.panelOperate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelOperate.Name = "panelOperate";
            this.panelOperate.Size = new System.Drawing.Size(344, 205);
            this.panelOperate.TabIndex = 5;
            // 
            // panelAgvOperate
            // 
            this.panelAgvOperate.Controls.Add(this.grpAgvOperate);
            this.panelAgvOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAgvOperate.Location = new System.Drawing.Point(0, 0);
            this.panelAgvOperate.Name = "panelAgvOperate";
            this.panelAgvOperate.Size = new System.Drawing.Size(344, 205);
            this.panelAgvOperate.TabIndex = 5;
            // 
            // grpAgvOperate
            // 
            this.grpAgvOperate.Controls.Add(this.btnSavePLC);
            this.grpAgvOperate.Controls.Add(this.btnSend);
            this.grpAgvOperate.Controls.Add(this.btnConfigPlcAddress);
            this.grpAgvOperate.Controls.Add(this.btnConnect);
            this.grpAgvOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAgvOperate.Location = new System.Drawing.Point(0, 0);
            this.grpAgvOperate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAgvOperate.Name = "grpAgvOperate";
            this.grpAgvOperate.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAgvOperate.Size = new System.Drawing.Size(344, 205);
            this.grpAgvOperate.TabIndex = 4;
            this.grpAgvOperate.TabStop = false;
            this.grpAgvOperate.Text = "PLC操作";
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
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.LightBlue;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSend.Location = new System.Drawing.Point(52, 76);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 42);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "读  取";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
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
            this.panelState.Size = new System.Drawing.Size(344, 330);
            this.panelState.TabIndex = 6;
            // 
            // panelAgvState
            // 
            this.panelAgvState.Controls.Add(this.grpAgvConnection);
            this.panelAgvState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAgvState.Location = new System.Drawing.Point(0, 143);
            this.panelAgvState.Name = "panelAgvState";
            this.panelAgvState.Size = new System.Drawing.Size(344, 187);
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
            this.grpAgvConnection.Size = new System.Drawing.Size(344, 187);
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
            this.chkIsConnPLC.Location = new System.Drawing.Point(172, 75);
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
            this.label11.Location = new System.Drawing.Point(165, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "连接";
            // 
            // txtPlcConnect
            // 
            this.txtPlcConnect.BackColor = System.Drawing.Color.Red;
            this.txtPlcConnect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlcConnect.Location = new System.Drawing.Point(200, 114);
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
            this.txtSlaveId.Size = new System.Drawing.Size(55, 23);
            this.txtSlaveId.TabIndex = 14;
            this.txtSlaveId.Text = "1";
            this.txtSlaveId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(105, 74);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(55, 23);
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
            this.txtIp.Size = new System.Drawing.Size(116, 23);
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
            this.grpCmmState.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCmmState.Location = new System.Drawing.Point(0, 0);
            this.grpCmmState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCmmState.Name = "grpCmmState";
            this.grpCmmState.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCmmState.Size = new System.Drawing.Size(344, 143);
            this.grpCmmState.TabIndex = 0;
            this.grpCmmState.TabStop = false;
            this.grpCmmState.Text = "OMM软件状态";
            // 
            // timerlog
            // 
            this.timerlog.Enabled = true;
            this.timerlog.Interval = 1000;
            this.timerlog.Tick += new System.EventHandler(this.timerlog_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 557);
            this.panel1.TabIndex = 10;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Azure;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 20);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(624, 533);
            this.txtLog.TabIndex = 0;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(0, 0);
            this.grpLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLog.Name = "grpLog";
            this.grpLog.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLog.Size = new System.Drawing.Size(630, 557);
            this.grpLog.TabIndex = 1;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "系统日志";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(980, 557);
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
            this.panelMidRight.ResumeLayout(false);
            this.grpRight.ResumeLayout(false);
            this.panelOperate.ResumeLayout(false);
            this.panelAgvOperate.ResumeLayout(false);
            this.grpAgvOperate.ResumeLayout(false);
            this.panelState.ResumeLayout(false);
            this.panelAgvState.ResumeLayout(false);
            this.grpAgvConnection.ResumeLayout(false);
            this.grpAgvConnection.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.GroupBox grpCmmState;
        private System.Windows.Forms.Timer timerlog;
        private System.Windows.Forms.Panel panelOperate;
        private System.Windows.Forms.GroupBox grpAgvConnection;
        private System.Windows.Forms.GroupBox grpAgvOperate;
        private System.Windows.Forms.Button btnSend;
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
    }
}

