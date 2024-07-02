using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Application.Tests
{
    public class MockClockManager: IClockManager
    {
        private DateTime _currentUtc;

        public DateTime GetCurrentUtc() 
        { 
            return _currentUtc; 
        }

        public void SetCurrentUtc(DateTime utc) 
        {
            _currentUtc = utc;
        }
    }
}
