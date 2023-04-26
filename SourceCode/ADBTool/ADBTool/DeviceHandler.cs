using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADBTool
{
    public class DeviceHandler
    {
        public List<Device> DeviceList = new List<Device>();

        internal void AddDevice(Device Device)
        {
            if (Device.GetType() == typeof(WiFiDevice))
            {
                if (DeviceNamePortList().IndexOf(Device.DeviceName + ":" + Device.DevicePort) < 0)
                {
                    DeviceList.Add(Device);
                }
            }
            else
            {
                if (DeviceNameList().IndexOf(Device.DeviceName) < 0)
                {
                    DeviceList.Add(Device);
                }
            }
        }

        internal bool FindDeviceIndex(string DeviceName, out int Index)
        {
            Index = -1;
            for (int i = 0; i < DeviceList.Count; i++)
            {
                if (DeviceList[i].DeviceName.Equals(DeviceName, StringComparison.OrdinalIgnoreCase))
                {
                    Index = i;
                }
            }
                
            return (Index > -1);
        }
        internal bool FindDeviceIndex(string DeviceName, string DevicePort, out int Index)
        {
            Index = -1;
            for (int i = 0; i < DeviceList.Count; i++)
            {
                if (DeviceList[i].DeviceName.Equals(DeviceName, StringComparison.OrdinalIgnoreCase))
                {
                    if (DeviceList[i].DevicePort.Equals(DevicePort, StringComparison.OrdinalIgnoreCase))
                    {
                        Index = i;
                    }
                }
            }

            return (Index > -1);
        }

        internal void RemoveDevice(string Name)
        {
            if (FindDeviceIndex(Name, out int Index))
            {
                DeviceList.RemoveAt(Index);
            }
        }
        internal void RemoveDevice(string Name, string Port)
        {
            if (FindDeviceIndex(Name, Port, out int Index))
            {
                DeviceList.RemoveAt(Index);
            }
        }

        public String DeviceType
        {
            get 
            {
                String ReturnValue = "";

                bool firstDevice = true;

                foreach (Device device in DeviceList)
                {
                    if (firstDevice)
                    {
                        firstDevice = false;
                    }
                    else
                    {
                        ReturnValue = ReturnValue + "|";
                    }

                    ReturnValue = ReturnValue + device.DeviceType;
                }

                return ReturnValue;
            }
            set
            {
                DeviceList.Clear();
                List<String> temp = new List<String>();
                if (value.Length > 0)
                {
                    temp.AddRange(value.Split("|"));
                }
                for (int i = 0; i < temp.Count; i++)
                {
                    if (i > DeviceList.Count - 1)
                    {
                        if (temp[i].Equals("WiFi"))
                        {
                            DeviceList.Add(new WiFiDevice("",""));
                        }
                        else 
                        {
                            DeviceList.Add(new USBDevice(""));
                        }
                    }
                }
            }
        }

        public List<String> DeviceNameList()
        {
            List<String> ReturnValue = new List<String>();

            ReturnValue.AddRange(DeviceName.Split("|"));

            return ReturnValue;
        }
        public List<String> DeviceNamePortList()
        {
            List<String> ReturnValue = new List<String>();
            List<String> deviceNames = new List<string>();
            List<String> devicePort = new List<string>();

            deviceNames.AddRange(DeviceName.Split("|"));
            devicePort.AddRange(DevicePort.Split("|"));

            for (int i = 0; i < deviceNames.Count; i++)
            {
                ReturnValue.Add(deviceNames[i] + ":" + devicePort[i]);
            }

            return ReturnValue;
        }
        public String DeviceName
        {
            get
            {
                String ReturnValue = "";

                bool firstDevice = true;

                foreach (Device device in DeviceList)
                {
                    if (firstDevice)
                    {
                        firstDevice = false;
                    }
                    else
                    {
                        ReturnValue = ReturnValue + "|";
                    }

                    ReturnValue = ReturnValue + device.DeviceName;
                }

                return ReturnValue;
            }
            set
            {
                List<String> temp = new List<String>();
                if (value.Length > 0)
                {
                    temp.AddRange(value.Split("|"));
                }
                for (int i = 0; i < temp.Count; i++)
                {
                    DeviceList[i].DeviceName = temp[i];
                }
            }
        }
        public String DevicePort
        {
            get
            {
                String ReturnValue = "";

                bool firstDevice = true;

                foreach (Device device in DeviceList)
                {
                    if (firstDevice)
                    {
                        firstDevice = false;
                    }
                    else
                    {
                        ReturnValue = ReturnValue + "|";
                    }

                    ReturnValue = ReturnValue + device.DevicePort;
                }

                return ReturnValue;
            }
            set
            {
                List<String> temp = new List<String>();
                if (value.Length > 0) 
                {
                    temp.AddRange(value.Split("|"));
                }
                for (int i = 0; i < temp.Count; i++)
                {
                    DeviceList[i].DevicePort = temp[i];
                }
            }
        }

        public string DeviceDirectory
        {
            get
            {
                String ReturnValue = "";

                bool firstDevice = true;

                foreach (Device device in DeviceList)
                {
                    if (firstDevice)
                    {
                        firstDevice = false;
                    }
                    else
                    {
                        ReturnValue = ReturnValue + "|";
                    }

                    ReturnValue = ReturnValue + device.DeviceDirectory;
                }

                return ReturnValue;
            }
            set
            {
                List<String> temp = new List<String>();
                if (value.Length > 0)
                {
                    temp.AddRange(value.Split("|"));
                }
                for (int i = 0; i < temp.Count; i++)
                {
                    DeviceList[i].DeviceDirectory = temp[i];
                }
            }
        }
        

        internal void ClearAllDevices()
        {
            DeviceList.Clear();
        }

        public List<Device> WiFiDeviceList()
        {
            List<Device> ReturnValue = new List<Device>();

            foreach (Device dev in DeviceList)
            {
                if (dev.GetType().Equals(typeof(WiFiDevice)))
                {
                    ReturnValue.Add(dev);
                }
            }
            return ReturnValue;
        }
        public List<Device> USBDeviceList()
        {
            List<Device> ReturnValue = new List<Device>();

            foreach (Device dev in DeviceList)
            {
                if (dev.GetType().Equals(typeof(USBDevice)))
                {
                    ReturnValue.Add(dev);
                }
            }
            return ReturnValue;
        }

        #region Debug Console
        public void ShowDeviceList()
        {
            Debug.WriteLine("**********************************************");
            Debug.WriteLine("**               Device List                **");
            Debug.WriteLine("**********************************************");
            ShowDeviceList(DeviceList);
        }
        public void ShowWiFiDeviceList()
        {
            Debug.WriteLine("**********************************************");
            Debug.WriteLine("**             WiFi Device List             **");
            Debug.WriteLine("**********************************************");
            ShowDeviceList(WiFiDeviceList());
        }
        public void ShowUSBDeviceList()
        {
            Debug.WriteLine("**********************************************");
            Debug.WriteLine("**             USB Device List              **");
            Debug.WriteLine("**********************************************");
            ShowDeviceList(USBDeviceList());
        }

        private void ShowDeviceList(List<Device> devices)
        {
            foreach (Device dev in devices)
            {
                Debug.WriteLine("\r\nC# Class Type : " + dev.GetType().Name);
                Debug.WriteLine("DeviceType : " + dev.DeviceType);
                Debug.WriteLine("DeviceName : " + dev.DeviceName);
                Debug.WriteLine("DevicePort : " + dev.DevicePort);
            }
        }
        #endregion
    }

    public abstract class Device
    {
        public string DeviceType { get; internal set; }
        public string DeviceName { get; internal set; }
        public string DevicePort { get; internal set; }
        public string DeviceDirectory { get; internal set; }
        public Device(String Type, String Name, String Port)
        {
            this.DeviceType = Type;
            this.DeviceName = Name;
            this.DevicePort = Port;
        }
    }
    public class WiFiDevice : Device
    {
        public WiFiDevice(String Name, String Port) : base("WiFi", Name, Port)
        {
        }
    }
    public class USBDevice : Device
    {
        public USBDevice(String Name) : base("USB", Name, "")
        {
        }
    }
}

