namespace ADBTool_Robotics
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusBar = new StatusStrip();
            lblVersion = new ToolStripStatusLabel();
            lblTime = new ToolStripStatusLabel();
            toolBar = new ToolStrip();
            tsbtnSettings = new ToolStripSplitButton();
            clearConsoleToolStripMenuItem = new ToolStripMenuItem();
            tsitemResetDefault = new ToolStripMenuItem();
            tslblStatus = new ToolStripLabel();
            gboxConsole = new GroupBox();
            rtxtbxConsole = new RichTextBox();
            gboxCommands = new GroupBox();
            tabControl1 = new TabControl();
            tbList = new TabPage();
            gboxFileCom = new GroupBox();
            lblExPullFiles = new Label();
            btnExPullDirectory = new Button();
            btnExBrowse = new Button();
            txtbxExLocalDirectory = new TextBox();
            txtbxExDeviceDirectory = new TextBox();
            gboxSingleCom = new GroupBox();
            btnDelDir = new Button();
            btnExSetPort = new Button();
            gboxExSelectedDevice = new GroupBox();
            btnExRefresh = new Button();
            btnExDisconnect = new Button();
            btnExConnect = new Button();
            cboxExSelectedDevice = new ComboBox();
            statusTimer = new System.Windows.Forms.Timer(components);
            toolTips = new ToolTip(components);
            statusBar.SuspendLayout();
            toolBar.SuspendLayout();
            gboxConsole.SuspendLayout();
            gboxCommands.SuspendLayout();
            tabControl1.SuspendLayout();
            tbList.SuspendLayout();
            gboxFileCom.SuspendLayout();
            gboxSingleCom.SuspendLayout();
            gboxExSelectedDevice.SuspendLayout();
            SuspendLayout();
            // 
            // statusBar
            // 
            statusBar.Items.AddRange(new ToolStripItem[] { lblVersion, lblTime });
            statusBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusBar.Location = new Point(0, 441);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(898, 22);
            statusBar.SizingGrip = false;
            statusBar.TabIndex = 0;
            statusBar.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            lblVersion.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(45, 17);
            lblVersion.Text = "Version";
            // 
            // lblTime
            // 
            lblTime.Alignment = ToolStripItemAlignment.Right;
            lblTime.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(84, 17);
            lblTime.Spring = true;
            lblTime.Text = "Getting Time...";
            // 
            // toolBar
            // 
            toolBar.BackColor = SystemColors.Control;
            toolBar.GripStyle = ToolStripGripStyle.Hidden;
            toolBar.Items.AddRange(new ToolStripItem[] { tsbtnSettings, tslblStatus });
            toolBar.Location = new Point(0, 0);
            toolBar.Name = "toolBar";
            toolBar.Size = new Size(898, 25);
            toolBar.TabIndex = 1;
            // 
            // tsbtnSettings
            // 
            tsbtnSettings.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbtnSettings.DropDownItems.AddRange(new ToolStripItem[] { clearConsoleToolStripMenuItem, tsitemResetDefault });
            tsbtnSettings.Image = (Image)resources.GetObject("tsbtnSettings.Image");
            tsbtnSettings.ImageTransparentColor = Color.Magenta;
            tsbtnSettings.Name = "tsbtnSettings";
            tsbtnSettings.Size = new Size(65, 22);
            tsbtnSettings.Text = "Settings";
            tsbtnSettings.ToolTipText = "Application Settings";
            // 
            // clearConsoleToolStripMenuItem
            // 
            clearConsoleToolStripMenuItem.Name = "clearConsoleToolStripMenuItem";
            clearConsoleToolStripMenuItem.Size = new Size(158, 22);
            clearConsoleToolStripMenuItem.Text = "Clear Console";
            clearConsoleToolStripMenuItem.ToolTipText = "Clears The Console\r\n";
            clearConsoleToolStripMenuItem.Click += clearConsoleToolStripMenuItem_Click;
            // 
            // tsitemResetDefault
            // 
            tsitemResetDefault.Name = "tsitemResetDefault";
            tsitemResetDefault.Size = new Size(158, 22);
            tsitemResetDefault.Text = "Reset To Default";
            tsitemResetDefault.ToolTipText = "Reset All Program Settings To Defaults";
            tsitemResetDefault.Click += tsitemResetDefault_Click;
            // 
            // tslblStatus
            // 
            tslblStatus.Alignment = ToolStripItemAlignment.Right;
            tslblStatus.BackColor = Color.Red;
            tslblStatus.BackgroundImageLayout = ImageLayout.Center;
            tslblStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tslblStatus.Name = "tslblStatus";
            tslblStatus.Size = new Size(39, 22);
            tslblStatus.Text = "Status";
            tslblStatus.ToolTipText = "Current WiFi Device Status";
            // 
            // gboxConsole
            // 
            gboxConsole.Controls.Add(rtxtbxConsole);
            gboxConsole.Dock = DockStyle.Bottom;
            gboxConsole.Location = new Point(0, 285);
            gboxConsole.Name = "gboxConsole";
            gboxConsole.Size = new Size(898, 156);
            gboxConsole.TabIndex = 2;
            gboxConsole.TabStop = false;
            gboxConsole.Text = "Console";
            // 
            // rtxtbxConsole
            // 
            rtxtbxConsole.Dock = DockStyle.Fill;
            rtxtbxConsole.Location = new Point(3, 19);
            rtxtbxConsole.Name = "rtxtbxConsole";
            rtxtbxConsole.ReadOnly = true;
            rtxtbxConsole.Size = new Size(892, 134);
            rtxtbxConsole.TabIndex = 0;
            rtxtbxConsole.Text = "";
            // 
            // gboxCommands
            // 
            gboxCommands.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gboxCommands.Controls.Add(tabControl1);
            gboxCommands.Location = new Point(0, 28);
            gboxCommands.Name = "gboxCommands";
            gboxCommands.Size = new Size(898, 258);
            gboxCommands.TabIndex = 3;
            gboxCommands.TabStop = false;
            gboxCommands.Text = "Commands";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbList);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 19);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(892, 236);
            tabControl1.TabIndex = 0;
            // 
            // tbList
            // 
            tbList.AutoScroll = true;
            tbList.Controls.Add(gboxFileCom);
            tbList.Controls.Add(gboxSingleCom);
            tbList.Controls.Add(gboxExSelectedDevice);
            tbList.Location = new Point(4, 24);
            tbList.Name = "tbList";
            tbList.Padding = new Padding(3);
            tbList.Size = new Size(884, 208);
            tbList.TabIndex = 2;
            tbList.Text = "List";
            tbList.UseVisualStyleBackColor = true;
            // 
            // gboxFileCom
            // 
            gboxFileCom.Controls.Add(lblExPullFiles);
            gboxFileCom.Controls.Add(btnExPullDirectory);
            gboxFileCom.Controls.Add(btnExBrowse);
            gboxFileCom.Controls.Add(txtbxExLocalDirectory);
            gboxFileCom.Controls.Add(txtbxExDeviceDirectory);
            gboxFileCom.Location = new Point(136, 61);
            gboxFileCom.Name = "gboxFileCom";
            gboxFileCom.Size = new Size(561, 101);
            gboxFileCom.TabIndex = 3;
            gboxFileCom.TabStop = false;
            gboxFileCom.Text = "File Commands";
            // 
            // lblExPullFiles
            // 
            lblExPullFiles.AutoSize = true;
            lblExPullFiles.Location = new Point(6, 19);
            lblExPullFiles.Name = "lblExPullFiles";
            lblExPullFiles.Size = new Size(53, 15);
            lblExPullFiles.TabIndex = 21;
            lblExPullFiles.Text = "Pull FIles";
            // 
            // btnExPullDirectory
            // 
            btnExPullDirectory.Enabled = false;
            btnExPullDirectory.Location = new Point(442, 66);
            btnExPullDirectory.Name = "btnExPullDirectory";
            btnExPullDirectory.Size = new Size(112, 23);
            btnExPullDirectory.TabIndex = 20;
            btnExPullDirectory.Text = "Pull Directory";
            btnExPullDirectory.UseVisualStyleBackColor = true;
            btnExPullDirectory.Click += btnExPullDirectory_Click;
            // 
            // btnExBrowse
            // 
            btnExBrowse.Enabled = false;
            btnExBrowse.Location = new Point(442, 36);
            btnExBrowse.Name = "btnExBrowse";
            btnExBrowse.Size = new Size(112, 23);
            btnExBrowse.TabIndex = 19;
            btnExBrowse.Text = "Browse";
            btnExBrowse.UseVisualStyleBackColor = true;
            btnExBrowse.Click += btnExBrowse_Click;
            // 
            // txtbxExLocalDirectory
            // 
            txtbxExLocalDirectory.Enabled = false;
            txtbxExLocalDirectory.Location = new Point(6, 37);
            txtbxExLocalDirectory.Name = "txtbxExLocalDirectory";
            txtbxExLocalDirectory.PlaceholderText = "Local Directory";
            txtbxExLocalDirectory.ReadOnly = true;
            txtbxExLocalDirectory.Size = new Size(430, 23);
            txtbxExLocalDirectory.TabIndex = 18;
            txtbxExLocalDirectory.TextChanged += txtbxExLocalDirectory_TextChanged;
            // 
            // txtbxExDeviceDirectory
            // 
            txtbxExDeviceDirectory.Enabled = false;
            txtbxExDeviceDirectory.Location = new Point(6, 66);
            txtbxExDeviceDirectory.Name = "txtbxExDeviceDirectory";
            txtbxExDeviceDirectory.PlaceholderText = "Device Directory";
            txtbxExDeviceDirectory.Size = new Size(430, 23);
            txtbxExDeviceDirectory.TabIndex = 11;
            txtbxExDeviceDirectory.TextChanged += txtbxExDeviceDirectory_TextChanged;
            // 
            // gboxSingleCom
            // 
            gboxSingleCom.Controls.Add(btnDelDir);
            gboxSingleCom.Controls.Add(btnExSetPort);
            gboxSingleCom.Location = new Point(6, 61);
            gboxSingleCom.Name = "gboxSingleCom";
            gboxSingleCom.Size = new Size(124, 101);
            gboxSingleCom.TabIndex = 2;
            gboxSingleCom.TabStop = false;
            gboxSingleCom.Text = "Single Commands";
            // 
            // btnDelDir
            // 
            btnDelDir.Enabled = false;
            btnDelDir.Location = new Point(6, 51);
            btnDelDir.Name = "btnDelDir";
            btnDelDir.Size = new Size(112, 23);
            btnDelDir.TabIndex = 23;
            btnDelDir.Text = "Delete Directory";
            btnDelDir.UseVisualStyleBackColor = true;
            btnDelDir.Click += btnDelDir_Click;
            // 
            // btnExSetPort
            // 
            btnExSetPort.Enabled = false;
            btnExSetPort.Location = new Point(6, 22);
            btnExSetPort.Name = "btnExSetPort";
            btnExSetPort.Size = new Size(112, 23);
            btnExSetPort.TabIndex = 18;
            btnExSetPort.Text = "Set Port";
            toolTips.SetToolTip(btnExSetPort, "Set USB Device Port");
            btnExSetPort.UseVisualStyleBackColor = true;
            btnExSetPort.Click += btnExSetPort_Click;
            // 
            // gboxExSelectedDevice
            // 
            gboxExSelectedDevice.Controls.Add(btnExRefresh);
            gboxExSelectedDevice.Controls.Add(btnExDisconnect);
            gboxExSelectedDevice.Controls.Add(btnExConnect);
            gboxExSelectedDevice.Controls.Add(cboxExSelectedDevice);
            gboxExSelectedDevice.Location = new Point(6, 6);
            gboxExSelectedDevice.Name = "gboxExSelectedDevice";
            gboxExSelectedDevice.Size = new Size(231, 48);
            gboxExSelectedDevice.TabIndex = 1;
            gboxExSelectedDevice.TabStop = false;
            gboxExSelectedDevice.Text = "Selected Device";
            // 
            // btnExRefresh
            // 
            btnExRefresh.Image = Properties.Resources.Refresh;
            btnExRefresh.Location = new Point(130, 19);
            btnExRefresh.Name = "btnExRefresh";
            btnExRefresh.Size = new Size(27, 23);
            btnExRefresh.TabIndex = 5;
            btnExRefresh.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTips.SetToolTip(btnExRefresh, "Refresh List");
            btnExRefresh.UseVisualStyleBackColor = true;
            btnExRefresh.Click += btnExRefresh_Click;
            // 
            // btnExDisconnect
            // 
            btnExDisconnect.Enabled = false;
            btnExDisconnect.Image = Properties.Resources.Disconnect;
            btnExDisconnect.Location = new Point(196, 19);
            btnExDisconnect.Name = "btnExDisconnect";
            btnExDisconnect.Size = new Size(27, 23);
            btnExDisconnect.TabIndex = 3;
            btnExDisconnect.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTips.SetToolTip(btnExDisconnect, "Disconnect From WiFi Device");
            btnExDisconnect.UseVisualStyleBackColor = true;
            btnExDisconnect.Click += btnExDisconnect_Click;
            // 
            // btnExConnect
            // 
            btnExConnect.Enabled = false;
            btnExConnect.Image = Properties.Resources.Connect;
            btnExConnect.Location = new Point(163, 19);
            btnExConnect.Name = "btnExConnect";
            btnExConnect.Size = new Size(27, 23);
            btnExConnect.TabIndex = 1;
            btnExConnect.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTips.SetToolTip(btnExConnect, "Connect To WiFi Device");
            btnExConnect.UseVisualStyleBackColor = true;
            btnExConnect.Click += btnExConnect_Click;
            // 
            // cboxExSelectedDevice
            // 
            cboxExSelectedDevice.Dock = DockStyle.Left;
            cboxExSelectedDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxExSelectedDevice.FormattingEnabled = true;
            cboxExSelectedDevice.Location = new Point(3, 19);
            cboxExSelectedDevice.Name = "cboxExSelectedDevice";
            cboxExSelectedDevice.Size = new Size(121, 23);
            cboxExSelectedDevice.TabIndex = 0;
            cboxExSelectedDevice.SelectedIndexChanged += cboxExSelectedDevice_SelectedIndexChanged;
            // 
            // statusTimer
            // 
            statusTimer.Tick += statusTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 463);
            Controls.Add(gboxCommands);
            Controls.Add(gboxConsole);
            Controls.Add(toolBar);
            Controls.Add(statusBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(420, 350);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ADBTool";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            toolBar.ResumeLayout(false);
            toolBar.PerformLayout();
            gboxConsole.ResumeLayout(false);
            gboxCommands.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tbList.ResumeLayout(false);
            gboxFileCom.ResumeLayout(false);
            gboxFileCom.PerformLayout();
            gboxSingleCom.ResumeLayout(false);
            gboxExSelectedDevice.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusBar;
        private ToolStripStatusLabel lblVersion;
        private ToolStripStatusLabel lblTime;
        private ToolStrip toolBar;
        private ToolStripSplitButton tsbtnSettings;
        private GroupBox gboxConsole;
        private RichTextBox rtxtbxConsole;
        private GroupBox gboxCommands;
        private ToolStripMenuItem tsitemResetDefault;
        private TabControl tabControl1;
        private System.Windows.Forms.Timer statusTimer;
        private GroupBox gboxWiFiSelectedDevice;
        private ComboBox cboxWiFiSelectedDevice;
        private GroupBox gboxUSBSelectedDevice;
        private ComboBox cboxUSBSelectedDevice;
        private Button btnUSBRefresh;
        private Button btnWiFiConnect;
        private ToolTip toolTips;
        private ToolStripMenuItem clearConsoleToolStripMenuItem;
        private ToolStripLabel tslblStatus;
        private Button btnWiFiRefresh;
        private Button btnWiFiDisconnect;
        private TabPage tbList;
        private TextBox txtbxUSBPort;
        private Button btnUSBSetPort;
        private GroupBox groupBox2;
        private Button btnWifiBrowse;
        private TextBox txtbxWifiLocalDirectory;
        private GroupBox groupBox1;
        private TextBox txtbxWifiDeviceDirectory;
        private Button btnWifiGetDirectory;
        private GroupBox gboxExSelectedDevice;
        private Button btnExRefresh;
        private Button btnExDisconnect;
        private Button btnExConnect;
        private ComboBox cboxExSelectedDevice;
        private GroupBox gboxFileCom;
        private GroupBox gboxSingleCom;
        private Label lblExPullFiles;
        private Button btnExPullDirectory;
        private Button btnExBrowse;
        private TextBox txtbxExLocalDirectory;
        private TextBox txtbxExDeviceDirectory;
        private Button btnExSetPort;
        private Button btnDelDir;
    }
}