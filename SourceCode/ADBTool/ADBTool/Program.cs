using System.Diagnostics;

namespace ADBTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            //test();
        }

        public static void test()
        {
            DeviceHandler deviceCollection = new DeviceHandler();
            deviceCollection.AddDevice(new WiFiDevice("test1", "1111"));
            deviceCollection.AddDevice(new WiFiDevice("test2", "2222"));
            deviceCollection.AddDevice(new USBDevice("test3"));

            deviceCollection.ShowDeviceList();

            deviceCollection.RemoveDevice("test1");

            deviceCollection.AddDevice(new WiFiDevice("wifi1", "1111"));

            deviceCollection.RemoveDevice("test3");

            deviceCollection.AddDevice(new USBDevice("usb3"));

            deviceCollection.ShowWiFiDeviceList();
            deviceCollection.ShowUSBDeviceList();

            for (int i = 0; i < deviceCollection.DeviceList.Count; i++)
            {
                if (deviceCollection.DeviceList[i].GetType().Equals(typeof(WiFiDevice)))
                {
                    WiFiDevice wifiDeviceInstance = (WiFiDevice)deviceCollection.DeviceList[i];
                    Debug.WriteLine(deviceCollection.DeviceList[i].GetType().Name
                            + ":" + wifiDeviceInstance.DeviceName
                            + ":"
                            + wifiDeviceInstance.DevicePort);
                }
                else if (deviceCollection.DeviceList[i].GetType().Equals(typeof(USBDevice)))
                {
                    USBDevice usbDeviceInstance = (USBDevice)deviceCollection.DeviceList[i];
                    Debug.WriteLine(deviceCollection.DeviceList[i].GetType().Name
                            + ":" + usbDeviceInstance.DeviceName);

                }
            }
        }
    }
}