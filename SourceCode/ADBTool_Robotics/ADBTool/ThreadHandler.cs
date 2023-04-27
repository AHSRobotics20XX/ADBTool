using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADBTool_Robotics
{
    internal class ThreadHandler
    {
        BackgroundWorker worker;

        public void SetupBackgroundWorker(DoWorkEventHandler LogicMethod, RunWorkerCompletedEventHandler CompletedMethod)
        {
            worker = new BackgroundWorker();
            worker.DoWork += LogicMethod;
            worker.RunWorkerCompleted += CompletedMethod;
        }
        
        public void StartBackgroundWorker()
        {
            if (worker != null)
            {
                worker.RunWorkerAsync();
            }
        }

        //public void SetupBackgroundWorker(DoWorkEventHandler LogicMethod, RunWorkerCompletedEventHandler CompletedMethod, ProgressChangedEventHandler ProgressMethod)
        //{
        //    worker = new BackgroundWorker();
        //    worker.DoWork += LogicMethod;
        //    worker.ProgressChanged += ProgressMethod;
        //    worker.WorkerReportsProgress = true;
        //    worker.RunWorkerCompleted += CompletedMethod;
        //}
        //private void SetPercentage(object? sender, int percent)
        //{
        //    (sender as BackgroundWorker).ReportProgress(percent);
        //}



        public void CreateThreadPool(WaitCallback method)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(method));
            System.Diagnostics.Debug.WriteLine("Started ThreadPool");
        }

        public void WaitForAllThreadsInThreadPoolToFinish()
        {
            int maxThreads = 0;
            int placeHolder = 0;
            int availThreads = 0;
            int timeOutSeconds = 15;

            //Now wait until all threads from the Threadpool have returned
            while (timeOutSeconds > 0)
            {
                //figure out what the max worker thread count it
                System.Threading.ThreadPool.GetMaxThreads(out maxThreads, out placeHolder);
                System.Threading.ThreadPool.GetAvailableThreads(out availThreads, out placeHolder);

                if (availThreads == maxThreads)
                {
                    System.Diagnostics.Debug.WriteLine("All Threads Done");
                    break;
                }

                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(1000));
                --timeOutSeconds;
            }

            if (timeOutSeconds <= 0)
            {
                System.Diagnostics.Debug.WriteLine("Excedid Time Limit For Worker Threads");
            }
        }
    }
}
