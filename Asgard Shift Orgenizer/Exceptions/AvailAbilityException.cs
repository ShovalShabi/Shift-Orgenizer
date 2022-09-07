using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgard_Shift_Orgenizer.Exceptions
{
    class AvailabilityException : Exception
    {
        public AvailabilityException(string msg) : base(msg) { }
    }
}
