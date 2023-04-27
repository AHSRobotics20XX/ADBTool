using ADBHelper;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADBTool_Robotics
{
    public partial class MainForm : Form
    {
        SettingsHandler settingsHandler = new SettingsHandler();
        DeviceHandler deviceHandler = new DeviceHandler();
        HelperHandler helperHandler = new HelperHandler();

        private string currentUSBDeviceName;
        private string currentWiFiDeviceName;
        private string currentDeviceType;
        private int currentDeviceIndex;


        private string wiFiStatus;
        private bool robotics;

        public MainForm()
        {
            InitializeComponent();
        }

        #region MainForm Load and Close
        private void Form1_Load(object sender, EventArgs e)
        {
            settingsHandler.LoadAllSettings();
            deviceHandler.DeviceType = settingsHandler.DeviceType;
            deviceHandler.DeviceName = settingsHandler.DeviceName;
            deviceHandler.DevicePort = settingsHandler.DevicePort;
            deviceHandler.DeviceDirectory = settingsHandler.DeviceDirectory;

            statusTimer.Start();
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            ExRefresh(cboxExSelectedDevice);

            wiFiStatus = "disconnected";
            UpdateStatus();

            OutputToConsole("Server has started");
            deviceHandler.ShowDeviceList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wiFiStatus.Equals("connected"))
            {
                UseADB("disconnect", true);
                wiFiStatus = "disconnected";
                UpdateStatus();
            }

            UseADB("kill-server", false);

            statusTimer.Stop();

            settingsHandler.DeviceType = deviceHandler.DeviceType;
            settingsHandler.DeviceName = deviceHandler.DeviceName;
            settingsHandler.DevicePort = deviceHandler.DevicePort;
            settingsHandler.DeviceDirectory = deviceHandler.DeviceDirectory;
            settingsHandler.SaveAllSettings();
        }
        #endregion

        #region MainForm
        private void statusTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
        private void clearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtbxConsole.Text = "";
        }
        private void tsitemResetDefault_Click(object sender, EventArgs e)
        {
            cboxExSelectedDevice.Items.Clear();
            txtbxExDeviceDirectory.Clear();

            settingsHandler.ClearAllSettings();
            deviceHandler.ClearAllDevices();
        }
        #endregion

        #region Commands Tab
        private void cboxExSelectedDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cboxExSelectedDevice.Text.Equals(""))
            {
                currentDeviceIndex = cboxExSelectedDevice.SelectedIndex;
                txtbxExDeviceDirectory.Text = deviceHandler.DeviceList[currentDeviceIndex].DeviceDirectory;

                if (cboxExSelectedDevice.Text.Contains("."))
                {
                    EnableWiFiItems();
                    DisableUSBItems();
                    currentDeviceType = "WiFi";
                }
                else
                {
                    DisableWiFiItems();
                    EnableUSBItems();
                    currentUSBDeviceName = cboxExSelectedDevice.Text;
                    currentDeviceType = "USB";
                }

                //Where both WiFi and USB Items are enable and disabled
                txtbxExLocalDirectory.Enabled = true;
                txtbxExDeviceDirectory.Enabled = true;
                btnExBrowse.Enabled = true;
            }
            else
            {
                txtbxExLocalDirectory.Enabled = false;
                txtbxExDeviceDirectory.Enabled = false;
                btnExBrowse.Enabled = false;
            }
        }
        private void btnExRefresh_Click(object sender, EventArgs e)
        {
            ExRefresh(cboxExSelectedDevice);
        }
        private void btnExAddDevice_Click(object sender, EventArgs e)
        {
            AddDeviceForm addDeviceForm = new AddDeviceForm();
            addDeviceForm.ShowDialog();

            if (!addDeviceForm.DeviceIP.Equals("") && !addDeviceForm.DevicePort.Equals(""))
            {
                deviceHandler.AddDevice(new WiFiDevice(addDeviceForm.DeviceIP, addDeviceForm.DevicePort));
                ExRefresh(cboxExSelectedDevice);
                OutputToConsole("Device has been added");
            }
        }
        private void btnExConnect_Click(object sender, EventArgs e)
        {
            if (!cboxExSelectedDevice.Text.Equals(""))
            {
                currentWiFiDeviceName = cboxExSelectedDevice.Text;

                if (wiFiStatus.Equals("connected"))
                {
                    UseADB("disconnect", true);
                }



                if (!UseADB("connect " + currentWiFiDeviceName, true).First().StartsWith("cannot"))
                {
                    wiFiStatus = "connected";
                    UpdateStatus();

                    btnExDisconnect.Enabled = true;
                }
            }
            else
            {
                OutputToConsole("Please select a device");
            }
        }
        private void btnExDisconnect_Click(object sender, EventArgs e)
        {
            UseADB("disconnect", true);

            btnExDisconnect.Enabled = false;

            wiFiStatus = "disconnected";
            UpdateStatus();
        }
        private void btnExRemoveDevice_Click(object sender, EventArgs e)
        {
            if (!cboxExSelectedDevice.Text.Equals(""))
            {
                string line = cboxExSelectedDevice.Text;

                if (wiFiStatus.Equals("connected"))
                {
                    UseADB("disconnect", true);

                    btnExDisconnect.Enabled = false;

                    wiFiStatus = "disconnected";
                    UpdateStatus();
                }



                if (line.Contains("."))
                {
                    string ip = helperHandler.StringBeforeDelimiter(line, ":");
                    string port = helperHandler.StringAfterDelimiter(line, ":");
                    deviceHandler.RemoveDevice(ip, port);
                    cboxExSelectedDevice.Items.RemoveAt(cboxExSelectedDevice.SelectedIndex);
                    DisableWiFiItems();
                }
                else
                {
                    OutputToConsole("Please select a device to remove");
                }
            }
        }
        private void btnExSetPort_Click(object sender, EventArgs e)
        {
            SetPortForm setPortForm = new SetPortForm();
            setPortForm.ShowDialog();

            if (!setPortForm.Port.Equals(""))
            {
                UseADB("-s " + currentUSBDeviceName + " tcpip " + setPortForm.Port, true);
            }
        }
        private void txtbxExDeviceDirectory_TextChanged(object sender, EventArgs e)
        {
            deviceHandler.DeviceList[currentDeviceIndex].DeviceDirectory = txtbxExDeviceDirectory.Text;

            btnExPullDirectory.Enabled = DirectoriesExSpecified();
        }
        private void txtbxExLocalDirectory_TextChanged(object sender, EventArgs e)
        {
            btnExPullDirectory.Enabled = DirectoriesExSpecified();
        }
        private void btnExBrowse_Click(object sender, EventArgs e)
        {
            string lastDirectory = settingsHandler.LastLocalDirectory;

            FolderBrowserDialog directoryDialog = new FolderBrowserDialog();

            if (helperHandler.IsStringNullOrEmpty(lastDirectory) || !Directory.Exists(lastDirectory))
            {
                directoryDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            }
            else
            {
                directoryDialog.InitialDirectory = lastDirectory;
            }



            if (directoryDialog.ShowDialog() != DialogResult.Cancel)
            {
                settingsHandler.LastLocalDirectory = directoryDialog.SelectedPath;
                txtbxExLocalDirectory.Text = directoryDialog.SelectedPath;
            }
        }
        private void btnExPullDirectory_Click(object sender, EventArgs e)
        {
            if (cboxExSelectedDevice.Text.Contains("."))
            {
                UseADB("-s " + currentWiFiDeviceName + " pull " + txtbxExDeviceDirectory.Text.ToString() + " " + txtbxExLocalDirectory.Text.ToString(), true);
            }
            else
            {
                UseADB("-s " + currentUSBDeviceName + " pull " + txtbxExDeviceDirectory.Text.ToString() + " " + txtbxExLocalDirectory.Text.ToString(), true);
            }
        }
        #endregion

        #region Other
        private List<String> UseADB(String command, bool outputToConsole)
        {
            WorkerForm workerForm = new WorkerForm();
            workerForm.ADBInput = command;
            workerForm.CallADB();
            workerForm.ShowDialog();

            String? stringOutput = workerForm.ADBOutput;
            List<String> listOutput = workerForm.ADBOutputList;

            if (outputToConsole)
            {
                if (stringOutput.Equals(""))
                {
                    stringOutput = stringOutput + "\r\n";
                }

                OutputToConsole(command, stringOutput);
            }

            return listOutput;
        }
        private void OutputToConsole(String Input, String Output)
        {
            rtxtbxConsole.Text = rtxtbxConsole.Text + "Input: " + Input + "\r\n";
            rtxtbxConsole.Text = rtxtbxConsole.Text + "Output: " + Output;
            rtxtbxConsole.SelectionStart = rtxtbxConsole.Text.Length;
            rtxtbxConsole.ScrollToCaret();
        }
        private void OutputToConsole(String message)
        {
            rtxtbxConsole.Text = rtxtbxConsole.Text + "Info: " + message + "\r\n";
            rtxtbxConsole.SelectionStart = rtxtbxConsole.Text.Length;
            rtxtbxConsole.ScrollToCaret();
        }
        private void UpdateStatus()
        {
            if (wiFiStatus.ToUpper().Equals("CONNECTED"))
            {
                tslblStatus.Text = "Connected to " + currentWiFiDeviceName;
                tslblStatus.BackColor = Color.LawnGreen;
            }
            else if (wiFiStatus.ToUpper().Equals("DISCONNECTED"))
            {
                tslblStatus.Text = "Disconnected";
                tslblStatus.BackColor = Color.Red;
            }
            else if (wiFiStatus.ToUpper().Equals("RECONNECT"))
            {
                tslblStatus.Text = "Restarting " + currentWiFiDeviceName + " device ";
                tslblStatus.BackColor = Color.Yellow;
            }
        }
        private void EnableUSBItems()
        {
            btnExSetPort.Enabled = true;
        }
        private void DisableUSBItems()
        {
            btnExSetPort.Enabled = false;
        }
        private void EnableWiFiItems()
        {
            btnExConnect.Enabled = true;
            btnExRemoveDevice.Enabled = true;
        }
        private void DisableWiFiItems()
        {
            btnExConnect.Enabled = false;
            btnExDisconnect.Enabled = false;
            btnExRemoveDevice.Enabled = false;
        }
        private void ExRefresh(System.Windows.Forms.ComboBox comboBox)
        {
            List<String> list = UseADB("devices", false);

            if (list.Count != 0)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    String line = list[i].Trim();
                    line = helperHandler.StringBeforeDelimiter(line, "device").Trim();

                    if (line.Length > 0)
                    {
                        if (!line.Contains("."))
                        {
                            deviceHandler.AddDevice(new USBDevice(line));
                        }
                    }
                }
            }

            if (deviceHandler.DeviceList.Count != 0)
            {
                comboBox.Items.Clear();

                for (int i = 0; i < deviceHandler.DeviceList.Count; i++)
                {
                    String name = deviceHandler.DeviceList[i].DeviceName;
                    String port = deviceHandler.DeviceList[i].DevicePort;

                    if (deviceHandler.DeviceList[i].GetType().Equals(typeof(WiFiDevice)))
                    {
                        comboBox.Items.Add(name + ":" + port);
                    }
                    else
                    {
                        comboBox.Items.Add(name);
                    }
                }
            }
        }
        private bool DirectoriesExSpecified()
        {
            bool ReturnValue = false;

            if (txtbxExDeviceDirectory.Text.Length > 0 && txtbxExLocalDirectory.Text.Length > 0)
            {
                ReturnValue = true;
            }

            return ReturnValue;
        }
        #endregion
    }
}
