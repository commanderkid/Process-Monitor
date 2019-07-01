using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace monitor
{
    class PolitimerInAction
    {
        private string NamePrc;
        private Timer KillTimer;
        private uint RepeatedPeriod;
        private bool KillerTimerSwitcher = true;
        public PolitimerInAction(Timer killerTimer, string processName, uint repeatPeriod)
        {
            RepeatedPeriod = repeatPeriod;
            KillTimer      = killerTimer;
            NamePrc        = processName;
        }
        public void TimerStart()
        {
            Timer tmr = new Timer(Timeprocessor, null, 0, RepeatedPeriod);
            while (KillerTimerSwitcher){ };
            Thread.Sleep(100);
            tmr.Dispose();
        }

        private void Timeprocessor(object sender)
        {
            Timer KillTim = (Timer)sender;
            Process[] prc = Process.GetProcessesByName(NamePrc);
            if (prc.Length == 0)
            {
                Console.WriteLine($"\rProcess {NamePrc} is not exist!!");
                Thread.Sleep(100);
                KillerTimerSwitcher = false;
                return;
            }
            else
            {
                Thread.Sleep(100);
                Console.WriteLine($"\rProcess {NamePrc} in action");
            }
        }
    }
}
