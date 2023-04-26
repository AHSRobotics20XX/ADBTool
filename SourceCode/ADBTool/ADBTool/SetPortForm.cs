using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBTool
{
    public partial class SetPortForm : Form
    {
        public string Port = "";
        public SetPortForm()
        {
            InitializeComponent();
        }

        private void btnSetPort_Click(object sender, EventArgs e)
        {
            if (IsPortValid(txtbxPort))
            {
                Port = txtbxPort.Text;
                this.Close();
            }
        }

        private bool IsPortValid(System.Windows.Forms.TextBox txtbx)
        {
            bool ReturnValue = true;

            if (!int.TryParse(txtbx.Text, out int testPort))
            {
                ReturnValue = false;
            }

            if (!ReturnValue)
            {
                MessageBox.Show("Invalid Port Number");
                txtbx.Focus();
            }

            return ReturnValue;
        }
    }
}
