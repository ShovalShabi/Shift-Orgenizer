using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift_Orgenizer.Exceptions
{
    class NoLessonsException : Exception
    {
        public NoLessonsException(string msg) : base(msg) { }
    }
}
