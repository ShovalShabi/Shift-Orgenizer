using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgard_Shift_Orgenizer.Exceptions
{
    class StudentAlreadyExistException : Exception
    {
        public StudentAlreadyExistException(string msg) : base(msg) { }
    }
}
