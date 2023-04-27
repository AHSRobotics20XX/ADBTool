namespace ADBTool_Robotics
{
    partial class DeleteDirectoryForm
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
            lblTitle = new Label();
            lblTitle2 = new Label();
            txtbxDirectory = new TextBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(440, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Deleting Directory From Device";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle2.Location = new Point(141, 66);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(181, 21);
            lblTitle2.TabIndex = 1;
            lblTitle2.Text = "Enter Directory To Delete";
            // 
            // txtbxDirectory
            // 
            txtbxDirectory.Location = new Point(93, 106);
            txtbxDirectory.Name = "txtbxDirectory";
            txtbxDirectory.Size = new Size(279, 23);
            txtbxDirectory.TabIndex = 2;
            txtbxDirectory.TextChanged += txtbxDirectory_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(186, 149);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // DeleteDirectoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 197);
            Controls.Add(btnDelete);
            Controls.Add(txtbxDirectory);
            Controls.Add(lblTitle2);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeleteDirectoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DeleteDirectoryForm";
            Load += DeleteDirectoryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTitle2;
        private TextBox txtbxDirectory;
        private Button btnDelete;
    }
}