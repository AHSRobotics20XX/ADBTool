namespace ADBTool
{
    partial class SetPortForm
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
            lblPort = new Label();
            btnSetPort = new Button();
            txtbxPort = new TextBox();
            lblNewPort = new Label();
            SuspendLayout();
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(114, 77);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(29, 15);
            lblPort.TabIndex = 11;
            lblPort.Text = "Port";
            // 
            // btnSetPort
            // 
            btnSetPort.Location = new Point(66, 139);
            btnSetPort.Name = "btnSetPort";
            btnSetPort.Size = new Size(125, 23);
            btnSetPort.TabIndex = 9;
            btnSetPort.Text = "Set";
            btnSetPort.UseVisualStyleBackColor = true;
            btnSetPort.Click += btnSetPort_Click;
            // 
            // txtbxPort
            // 
            txtbxPort.Location = new Point(78, 95);
            txtbxPort.Name = "txtbxPort";
            txtbxPort.Size = new Size(100, 23);
            txtbxPort.TabIndex = 8;
            // 
            // lblNewPort
            // 
            lblNewPort.AutoSize = true;
            lblNewPort.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNewPort.Location = new Point(52, 32);
            lblNewPort.Name = "lblNewPort";
            lblNewPort.Size = new Size(153, 25);
            lblNewPort.TabIndex = 6;
            lblNewPort.Text = "Setting New Port";
            // 
            // SetPortForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(257, 194);
            Controls.Add(lblPort);
            Controls.Add(btnSetPort);
            Controls.Add(txtbxPort);
            Controls.Add(lblNewPort);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetPortForm";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPort;
        private Button btnSetPort;
        private TextBox txtbxPort;
        private Label lblNewPort;
    }
}