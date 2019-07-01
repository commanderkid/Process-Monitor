using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            ChekerString cString = new ChekerString(args);
            if(cString.IsAllOk)
            {
                KillerTimer killTime = new KillerTimer(cString.ProcessN, cString.WaitingT);
                LooperTimer looperTimer = new LooperTimer(cString.ProcessN, cString.CheckT);
                if (cString.WaitingT <= cString.CheckT)
                    killTime.StartKillingProcess(null);
                else
                {
                    killTime.StartKillingProcess(looperTimer.LoopTimerReturner());
                    looperTimer.StartLoopingProcess(killTime.TimerKillReturner());
                }
            }
            Console.ReadKey();
        }
    }
}
