using ADBTool_Robotics;

namespace ADBHelper
{
    public partial class AddDeviceForm : Form
    {
        public String DeviceIP = "";
        public String DevicePort = "";

        public AddDeviceForm()
        {
            InitializeComponent();
        }

        #region Validation
        private bool IsPortValid(TextBox txtbx)
        {
            bool ReturnValue = true;

            int testPort = 0;
            if (!int.TryParse(txtbx.Text, out testPort))
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
        private bool IsIPValid(TextBox txtbx)
        {
            bool ReturnValue = true;

            List<String> temp = new List<string>();
            temp.AddRange(txtbx.Text.Split("."));

            if (temp.Count != 4)
            {
                ReturnValue = false;
            }

            if (ReturnValue)
            {
                foreach (String s in temp)
                {
                    int testOctet = 0;

                    if (!int.TryParse(s, out testOctet))
                    {
                        ReturnValue = false;
                    }
                    else if (!(testOctet >= 0 && testOctet <= 255))
                    {
                        ReturnValue = false;
                    }
                }
            }

            if (!ReturnValue)
            {
                MessageBox.Show("Invalid IP Address");
                txtbx.Focus();
            }

            return ReturnValue;
        }
        #endregion

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            if (IsIPValid(txtbxIPAddress) && IsPortValid(txtbxPort))
            {
                DeviceIP = txtbxIPAddress.Text;
                DevicePort = txtbxPort.Text;

                this.Close();
            }
        }
    }
}
