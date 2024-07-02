using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Application
{
    public interface IClockManager
    {
        DateTime GetCurrentUtc();
    }
}
