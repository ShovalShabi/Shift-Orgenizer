using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer.Classes
{
    /// <summary>
    /// A part of Command Design pattern.
    /// Designated for trigger to add new student
    /// </summary>
    class Invoker
    {
        private Command command;

        public void SetAddStudent(Command command)
        {
            this.command = command;
        }

        public void ExecuteAddStudent(Student student, Lesson lesson)
        {
            this.command.CommandAddStudent(student, ref lesson);
        }

        public void ExecuteRemoveStudent(Student student)
        {
            this.command.CommandRemoveStudent(student);
        }
    }
}
