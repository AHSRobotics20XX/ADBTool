using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBTool
{
    public partial class WorkerForm : Form
    {
        ThreadHandler threadHandler = new ThreadHandler();
        private Stopwatch stopwatch = new Stopwatch();

        public String? ADBInput = "";
        public String? ADBOutput = "";
        public List<String> ADBOutputList = new List<string>();

        public WorkerForm()
        {
            InitializeComponent();
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            statusTimer.Start();
            stopwatch.Start();
        }

        private void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            statusTimer.Stop();
            stopwatch.Stop();
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = stopwatch.Elapsed;
            tslblTime.Text = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        }

        #region ADB Items
        public void CallADB()
        {
            threadHandler.SetupBackgroundWorker(ADBLogic, ADBHasCompleted);
            threadHandler.StartBackgroundWorker();
        }

        private void ADBLogic(object? sender, DoWorkEventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "adb/adb.exe";
            startInfo.Arguments = ADBInput;
            process.StartInfo = startInfo;
            process.Start();
            ADBOutput = process.StandardOutput.ReadToEnd();
        }

        private void ADBHasCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
            ADBOutputList.AddRange(ADBOutput.Replace("\r\n", "\n").Split("\n"));
        }
        #endregion
    }
}
