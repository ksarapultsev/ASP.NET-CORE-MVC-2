using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ConfiguringApps.Infractructure
{
    public class UpTimeServises
    {
        private Stopwatch timer;

        public UpTimeServises()
        {
            timer = Stopwatch.StartNew();
        }

        public long Uptime => timer.ElapsedMilliseconds;
    }
}
