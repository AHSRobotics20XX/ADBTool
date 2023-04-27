using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBTool_Robotics
{
    public partial class DeleteDirectoryForm : Form
    {
        public MainForm mainForm;
        public string selectedDevice = "";

        public DeleteDirectoryForm()
        {
            InitializeComponent();
        }

        private void DeleteDirectoryForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Deleting Directory From " + selectedDevice;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mainForm.UseADB("-s " + selectedDevice + " shell rm -r " + txtbxDirectory.Text + "/CustomLog/", false);

            this.Close();
        }

        private void txtbxDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtbxDirectory.Text.Length > 0)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }
    }
}
