using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgard_Shift_Orgenizer.Exceptions
{
    class NoLessonsException : Exception
    {
        public NoLessonsException(string msg) : base(msg) { }
    }
}
