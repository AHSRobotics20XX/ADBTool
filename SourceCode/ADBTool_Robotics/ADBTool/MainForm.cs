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

            deviceHandler.AddDevice(new WiFiDevice("192.168.49.1", "5555"));

            statusTimer.Start();
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            ExRefresh(cboxExSelectedDevice);

            wiFiStatus = "disconnected";
            UpdateStatus();

            OutputToConsole("Server has started");
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
                currentDeviceType = deviceHandler.DeviceList[currentDeviceIndex].DeviceType;
                txtbxExDeviceDirectory.Text = deviceHandler.DeviceList[currentDeviceIndex].DeviceDirectory;


                if (currentDeviceType.Equals("WiFi"))
                {
                    //If the device is a WiFi Device
                    btnExSetPort.Enabled = false;
                    btnExConnect.Enabled = true;
                    btnExDisconnect.Enabled = true;

                    currentWiFiDeviceName = cboxExSelectedDevice.Text;
                }
                else
                {
                    //If the device is a USB Device
                    btnExSetPort.Enabled = true;
                    btnExConnect.Enabled = false;
                    btnExDisconnect.Enabled = false;

                    currentUSBDeviceName = cboxExSelectedDevice.Text;
                }

                //If the device is a WiFi or USB Device
                btnDelDir.Enabled = true;
                txtbxExLocalDirectory.Enabled = true;
                txtbxExDeviceDirectory.Enabled = true;
                btnExBrowse.Enabled = true;
            }
            else
            {
                txtbxExLocalDirectory.Enabled = false;
                txtbxExDeviceDirectory.Enabled = false;
                btnExBrowse.Enabled = false;
                btnDelDir.Enabled = false;
            }
        }
        private void btnExRefresh_Click(object sender, EventArgs e)
        {
            ExRefresh(cboxExSelectedDevice);
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
                UseADB("-s " + currentWiFiDeviceName + " pull " + txtbxExDeviceDirectory.Text.ToString() + " " + txtbxExLocalDirectory.Text.ToString() + "/CustomLog/", true);
            }
            else
            {
                UseADB("-s " + currentUSBDeviceName + " pull " + txtbxExDeviceDirectory.Text.ToString() + " " + txtbxExLocalDirectory.Text.ToString() + "/CustomLog/", true);
            }
        }
        #endregion

        #region Other
        public List<String> UseADB(String command, bool outputToConsole)
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
        private void ExRefresh(System.Windows.Forms.ComboBox comboBox)
        {
            List<String> list = UseADB("devices", false);

            if (list.Count != 0)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    String line = list[i].Trim();

                    if (!line.Contains("offline") && !line.Contains("unauthorized"))
                    {
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

        private void btnDelDir_Click(object sender, EventArgs e)
        {
            DeleteDirectoryForm deleteDirectoryForm = new DeleteDirectoryForm();
            deleteDirectoryForm.mainForm = this;
            deleteDirectoryForm.selectedDevice = cboxExSelectedDevice.Text;
            deleteDirectoryForm.ShowDialog();
        }
    }
}
