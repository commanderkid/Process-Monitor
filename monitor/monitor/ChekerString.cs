using System;
using System.Diagnostics;

namespace monitor
{
    class ChekerString
    {
        public readonly int WaitingT, CheckT;
        public readonly string ProcessN;
        public readonly bool IsAllOk = false;

        public ChekerString(string[] args)
        {
            if (args.Length != 3)
                Console.WriteLine("Wrong input data! Must be: process_name waiting_time checking_period");
            else if (!int.TryParse(args[1], out WaitingT))
                Console.WriteLine("Wrong waiting_time input information");
            else if (!int.TryParse(args[2], out CheckT))
                Console.WriteLine("Wrong checking_period input information");
            else if (Process.GetProcessesByName(args[0]).Length == 0)
                Console.WriteLine($"Process {args[0]} is not exist");
            else if ((WaitingT < 35791) && (CheckT < 35791))
            {
                IsAllOk = true;
                WaitingT = WaitingT * 1000 * 60;
                CheckT = CheckT * 1000 * 60;
                ProcessN = args[0];
            }
            else
                Console.WriteLine("waiting_time and check_time must be less or equal 35791");
        }
    }
}
