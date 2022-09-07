using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift_Orgenizer.Exceptions
{
    class OutOfCapacityException : Exception
    {
        public OutOfCapacityException(string msg) : base(msg) { }
    }
}
