using System;
using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monitor
{
    class LooperTimer
    {
        Timer KTimer;
        string ProcessName;
        int LoopTime;
        Timer timer = new Timer();
        public LooperTimer(string processName, int LTime)
        {
            ProcessName = processName;
            LoopTime = LTime;
        }

        public void StartLoopingProcess(Timer kt)
        {
            KTimer = kt; 
            timer.AutoReset = true;
            timer.Interval = LoopTime;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public Timer LoopTimerReturner()
        {
            return timer;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int procLeft = Process.GetProcessesByName(ProcessName).Length;
            System.Threading.Thread.Sleep(100);
            if (procLeft == 0)
            {
                if (!(KTimer is null))
                    KTimer.Stop();

                Console.WriteLine($"All processes {ProcessName} has been finished");
                timer.Enabled = false;
                timer.Stop();
            }
            else
                Console.WriteLine($"Number of unclosed processes: {ProcessName} is {procLeft}");
        }
    }
}
