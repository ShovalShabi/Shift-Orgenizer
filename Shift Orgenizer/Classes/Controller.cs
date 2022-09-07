using Asgard_Shift_Orgenizer.Classes;
using Asgard_Shift_Orgenizer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Shift_Orgenizer.UI
{
    /// <summary>
    /// A Contrellor object part of MVC design pattern.
    /// Stores a listner to model and to the view.
    /// </summary>
    class Controller : IModel, IView
    {
        private IModel model;
        private IView view;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            this.ModelAddModelListener(this);
            this.ViewAddViewListener(this);
        }
        /**********************************************Model interface implementation*************************/
        public void ModelAddModelListener(IModel listener)
        {
            this.model.ModelAddModelListener(listener);
        }

        public void ModelAddStudent(Student student,ref Lesson lesson)
        {
            Command command = new ConcreteCommand(this.model);
            Invoker invoker = new Invoker();
            invoker.SetAddStudent(command);
            invoker.ExecuteAddStudent(student,lesson);
        }


        public ArrayList ModelGetAllInstructors()
        {
            return this.model.ModelGetAllInstructors();
        }


        public Dictionary<string, ArrayList> ModelGetAllLessonsByDays()
        {
            return this.model.ModelGetAllLessonsByDays();
        }


        public Instructor ModelGetInstrucor(string firstName, string surname, string password)
        {
            return this.model.ModelGetInstrucor(firstName, surname, password);
        }

        public void ModelRemoveStudent(Student student)
        {
            Command command = new ConcreteCommand(this.model);
            Invoker invoker = new Invoker();
            invoker.SetAddStudent(command);
            invoker.ExecuteRemoveStudent(student);
        }

        /**********************************************UI Interface implementation*************************/
        public void ViewAddStudent(Student student, Lesson lesson)
        {
            this.ModelAddStudent(student, ref lesson);
        }

        public void ViewAddViewListener(IView listener)
        {
            view.ViewAddViewListener(this);
        }

        public ArrayList ViewGetAllInstructors()
        {
            return this.ModelGetAllInstructors();
        }

        public Dictionary<string, ArrayList> ViewGetAllLessonsByDays()
        {
            return this.ModelGetAllLessonsByDays();
        }

        public Instructor ViewGetInstructor(string firstName, string surname, string password)
        {
            return this.ModelGetInstrucor(firstName,surname, password);
        }

        public void ViewRemoveStudent(Student student)
        {
            this.ModelRemoveStudent(student);
        }
    }
}
