using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Shift_Orgenizer.Classes
{
    /// <summary>
    /// A general abstract class for describing Student 
    /// and Instructor Objects
    /// </summary>
    public abstract class Person
    {
        protected string firstName;
        protected string surname;

        public Person(string firstName, string surname)
        {
            this.firstName = firstName;
            this.surname = surname;
        }

    }
}
