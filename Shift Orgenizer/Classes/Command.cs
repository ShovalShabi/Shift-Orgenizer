using Shift_Orgenizer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Shift_Orgenizer.Classes
{
    /// <summary>
    /// A part of Command Design pattern.
    /// Designated for trigger to add new student
    /// </summary>
    abstract class Command
    {
        protected IModel reciever;

        public Command(IModel reciever)
        {
            this.reciever = reciever;
        }

        public abstract void CommandAddStudent(Student student, ref Lesson lesson);
        public abstract void CommandRemoveStudent(Student student);
    }
}
