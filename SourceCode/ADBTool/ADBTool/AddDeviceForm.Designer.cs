namespace ADBHelper
{
    partial class AddDeviceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gboxNewDeviceForm = new GroupBox();
            lblPort = new Label();
            lblIPAddress = new Label();
            btnAddDevice = new Button();
            txtbxPort = new TextBox();
            txtbxIPAddress = new TextBox();
            lblNewDeviceForm = new Label();
            gboxNewDeviceForm.SuspendLayout();
            SuspendLayout();
            // 
            // gboxNewDeviceForm
            // 
            gboxNewDeviceForm.Controls.Add(lblPort);
            gboxNewDeviceForm.Controls.Add(lblIPAddress);
            gboxNewDeviceForm.Controls.Add(btnAddDevice);
            gboxNewDeviceForm.Controls.Add(txtbxPort);
            gboxNewDeviceForm.Controls.Add(txtbxIPAddress);
            gboxNewDeviceForm.Controls.Add(lblNewDeviceForm);
            gboxNewDeviceForm.Dock = DockStyle.Fill;
            gboxNewDeviceForm.Location = new Point(0, 0);
            gboxNewDeviceForm.Name = "gboxNewDeviceForm";
            gboxNewDeviceForm.Size = new Size(416, 237);
            gboxNewDeviceForm.TabIndex = 0;
            gboxNewDeviceForm.TabStop = false;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(275, 93);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(29, 15);
            lblPort.TabIndex = 5;
            lblPort.Text = "Port";
            // 
            // lblIPAddress
            // 
            lblIPAddress.AutoSize = true;
            lblIPAddress.Location = new Point(96, 93);
            lblIPAddress.Name = "lblIPAddress";
            lblIPAddress.Size = new Size(62, 15);
            lblIPAddress.TabIndex = 4;
            lblIPAddress.Text = "IP Address";
            // 
            // btnAddDevice
            // 
            btnAddDevice.Location = new Point(143, 184);
            btnAddDevice.Name = "btnAddDevice";
            btnAddDevice.Size = new Size(125, 23);
            btnAddDevice.TabIndex = 3;
            btnAddDevice.Text = "Add";
            btnAddDevice.UseVisualStyleBackColor = true;
            btnAddDevice.Click += btnAddDevice_Click;
            // 
            // txtbxPort
            // 
            txtbxPort.Location = new Point(239, 111);
            txtbxPort.Name = "txtbxPort";
            txtbxPort.Size = new Size(100, 23);
            txtbxPort.TabIndex = 2;
            // 
            // txtbxIPAddress
            // 
            txtbxIPAddress.Location = new Point(77, 111);
            txtbxIPAddress.Name = "txtbxIPAddress";
            txtbxIPAddress.Size = new Size(100, 23);
            txtbxIPAddress.TabIndex = 1;
            // 
            // lblNewDeviceForm
            // 
            lblNewDeviceForm.AutoSize = true;
            lblNewDeviceForm.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNewDeviceForm.Location = new Point(117, 30);
            lblNewDeviceForm.Name = "lblNewDeviceForm";
            lblNewDeviceForm.Size = new Size(177, 25);
            lblNewDeviceForm.TabIndex = 0;
            lblNewDeviceForm.Text = "Adding New Device";
            // 
            // FormNewWifiDevice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 237);
            Controls.Add(gboxNewDeviceForm);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNewWifiDevice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Wifi Device";
            gboxNewDeviceForm.ResumeLayout(false);
            gboxNewDeviceForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gboxNewDeviceForm;
        private Label lblNewDeviceForm;
        private Button btnAddDevice;
        private TextBox txtbxPort;
        private TextBox txtbxIPAddress;
        private Label lblPort;
        private Label lblIPAddress;
    }
}