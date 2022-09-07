using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift_Orgenizer.Exceptions
{
    class LessonSelectionException : Exception
    {
        public LessonSelectionException(string msg) : base(msg) { }
    }
}
