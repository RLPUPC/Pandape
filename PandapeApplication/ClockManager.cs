using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Application
{
    public class ClockManager: IClockManager
    {
        public ClockManager() { }
        
        public DateTime GetCurrentUtc() { return DateTime.UtcNow; }
        
    }
}
