using Asgard_Shift_Orgenizer.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer.Interfaces
{
    /// <summary>
    /// Model interface
    /// </summary>
    interface IModel
    {
        void ModelAddModelListener(IModel listener);
        void ModelAddStudent(Student student, ref Lesson lesson);
        void ModelRemoveStudent(Student student);
        Instructor ModelGetInstrucor(string firstName, string surname, string password);
        ArrayList ModelGetAllInstructors();
        Dictionary<string,ArrayList> ModelGetAllLessonsByDays();
    }
}
