using Shift_Orgenizer.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Shift_Orgenizer.Interfaces
{
    /// <summary>
    /// View interface
    /// </summary>
    public interface IView
    {
        void ViewAddViewListener(IView listener);
        void ViewAddStudent(Student student, Lesson lesson);
        void ViewRemoveStudent(Student student);
        Instructor ViewGetInstructor(string firstName, string surname, string password);
        ArrayList ViewGetAllInstructors();
        Dictionary<string,ArrayList> ViewGetAllLessonsByDays();

    }
}
