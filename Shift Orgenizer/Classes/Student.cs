using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Shift_Orgenizer.Classes
{
    /// <summary>
    /// A Student Object
    /// </summary>
    public class Student : Person
    {
        private int serialNumber;
        private Specialties specialties;
        private bool lessonPreference;
        public Student(string firstName, string surname, Specialties specialties, bool lessonPreference) : base(firstName, surname)
        {
            this.specialties = specialties;
            this.lessonPreference = lessonPreference;
        }

        /************************Getters and Setters ******************************************/
        public string FirstName { get { return this.firstName; } }

        public string Surname { get { return this.surname; } }

        public int SerialNumber { get { return this.serialNumber; } set { this.serialNumber = value; } }

        public Specialties Specialties { get { return this.specialties; } set { this.specialties = value; } }

        public bool LessonPrefernce { get { return this.lessonPreference; } set { this.lessonPreference = value; } }

        /***********************Overrided methods*************************************************/
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Student)
            {
                Student temp = (Student)obj;
                if (this.firstName.ToLower().Equals(temp.FirstName.ToLower()) && this.surname.ToLower().Equals(temp.Surname.ToLower()) && this.serialNumber == temp.serialNumber) return true;
            }
            return false;
        }

        public override string ToString()
        {
            return this.firstName + " " + this.surname + " SID-" + this.serialNumber;
        }
    }
}
