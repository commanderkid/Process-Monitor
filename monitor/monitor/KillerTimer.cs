using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;

namespace monitor
{
    class KillerTimer
    {
        Timer LTimer;
        Timer timer = new Timer();
        string ProcessName;
        int WaitingTimer;
        public KillerTimer(string processName, int waitingTimer)
        {
            ProcessName = processName;
            WaitingTimer = waitingTimer;
        }

        public void StartKillingProcess(Timer loopTimer)
        {
            LTimer = loopTimer;
            timer.AutoReset = false;
            timer.Interval = WaitingTimer;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public Timer TimerKillReturner()
        {
            return timer;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(!(LTimer is null))
                LTimer.Stop();

            Process[] prc = Process.GetProcessesByName(ProcessName);
            foreach(Process proc in prc)
            {
                try
                {
                    proc.Kill();
                }
                catch
                {
                    Console.WriteLine($"Can't kill process: {proc.Id} {ProcessName}");
                }
                System.Threading.Thread.Sleep(10);
            }
            int procLeng = Process.GetProcessesByName(ProcessName).Length;
            if (procLeng == 0)
                Console.WriteLine($"All processes {ProcessName} has been killed");
            else
                Console.WriteLine($"Number of unclosed processes: {ProcessName} is {procLeng}");
        }
    }
}
