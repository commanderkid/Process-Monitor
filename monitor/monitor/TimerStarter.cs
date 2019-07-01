using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace monitor
{
    class TimerStarter
    {
        private string ProcessName;
        public TimerStarter(string processName, uint waitingTime, uint checkingTime)
        {
            ProcessName = processName;
            if(waitingTime <= checkingTime)
                ProcessKiller(waitingTime);
            else
            {
                Timer killerTimer = new Timer(TimerCB, null, waitingTime, Timeout.Infinite);
                PolitimerInAction pia = new PolitimerInAction(killerTimer, processName, checkingTime);
                pia.TimerStart();
            }
        }

        private void ProcessKiller(uint waitingTime)
        {
            Timer killerTimer = new Timer(TimerCB, null, waitingTime, Timeout.Infinite); 
        }

        private void TimerCB(object sender)
        {
            Process[] prcList = Process.GetProcessesByName(ProcessName);
            if (prcList.Length == 0)
            {
                //Console.Write($"\rProcess {ProcessName} is not exist\n");
                return;
            }
            else
            {
                foreach (Process proc in prcList)
                {
                    try { proc.Kill(); }
                    catch
                    {
                        Thread.Sleep(100);
                        Console.Write($"\rCant kill process {ProcessName}");
                        break;
                    }
                }
                Thread.Sleep(100);
                if (Process.GetProcessesByName(ProcessName).Length == 0)
                    Console.Write($"\rAll processes {ProcessName} has been closed");
            }
        }
    }
}
