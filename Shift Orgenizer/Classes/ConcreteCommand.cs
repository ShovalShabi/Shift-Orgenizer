using Asgard_Shift_Orgenizer.Interfaces;
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
    class ConcreteCommand : Command
    {
        public ConcreteCommand(IModel reciever) : base(reciever) { }

        public override void CommandAddStudent(Student student, ref Lesson lesson)
        {
            reciever.ModelAddStudent(student,ref lesson);
        }

        public override void CommandRemoveStudent(Student student)
        {
            reciever.ModelRemoveStudent(student);
        }
    }
}
