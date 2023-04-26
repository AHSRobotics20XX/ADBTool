using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ADBTool
{
    internal class SettingsHandler
    {
        public string DeviceType { get; internal set; }
        public string DeviceName { get; internal set; }
        public string DevicePort { get; internal set; }
        public string DeviceDirectory { get; internal set; }
        public string LastLocalDirectory { get; internal set; }

        public void SaveAllSettings()
        {
            Properties.Settings.Default.DeviceType = DeviceType;
            Properties.Settings.Default.DeviceName = DeviceName;
            Properties.Settings.Default.DevicePort = DevicePort;
            Properties.Settings.Default.DeviceDirectory = DeviceDirectory;

            Properties.Settings.Default.Save();
        }
        public void LoadAllSettings() 
        {
            DeviceType = Properties.Settings.Default.DeviceType;
            DeviceName = Properties.Settings.Default.DeviceName;
            DevicePort = Properties.Settings.Default.DevicePort;
            DeviceDirectory = Properties.Settings.Default.DeviceDirectory;
        }

        public void ClearAllSettings()
        {
            DeviceType = "";
            DeviceName = "";
            DevicePort = "";
            LastLocalDirectory = "";

            SaveAllSettings();
        }
    }
}
