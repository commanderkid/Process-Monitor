using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monitor
{
    static class ConverterFromMinToMSec
    {
        public static int Converter(int Minutes)
        {
            int checker = int.MaxValue / (60 * 1000);
            if (checker >= Minutes)
                return Minutes * 60 * 1000;
        }
    }
}
