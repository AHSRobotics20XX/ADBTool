namespace ADBTool_Robotics
{
    partial class WorkerForm
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
            components = new System.ComponentModel.Container();
            statusStrip = new StatusStrip();
            tslblTime = new ToolStripStatusLabel();
            statusTimer = new System.Windows.Forms.Timer(components);
            lblTitle = new Label();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { tslblTime });
            statusStrip.Location = new Point(0, 55);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(456, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // tslblTime
            // 
            tslblTime.Name = "tslblTime";
            tslblTime.Size = new Size(441, 17);
            tslblTime.Spring = true;
            tslblTime.Text = "Time";
            // 
            // statusTimer
            // 
            statusTimer.Enabled = true;
            statusTimer.Tick += statusTimer_Tick;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(429, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Executing Command. Please Wait...";
            // 
            // WorkerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 77);
            ControlBox = false;
            Controls.Add(lblTitle);
            Controls.Add(statusStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "WorkerForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Waiting...";
            TopMost = true;
            FormClosing += WaitingForm_FormClosing;
            Load += WaitingForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel tslblTime;
        private System.Windows.Forms.Timer statusTimer;
        private Label lblTitle;
    }
}