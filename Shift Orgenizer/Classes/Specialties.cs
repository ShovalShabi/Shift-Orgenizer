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
    /// Specialties Object
    /// Indicating what are the capabillities of the person or the subjects of a lesson
    /// </summary>
    public class Specialties
    {
        private ArrayList specialties;
        private int sqlId;

        public Specialties()
        {
            this.specialties = new ArrayList();
        }

        public bool hasSpacilaty(string specialty)
        {
            return this.specialties.Contains(specialty);
        }

        /************************Getters and Setters ******************************************/
        public ArrayList SpecialtiesArr { get { return this.specialties; } set { this.specialties =value; } }
        public int SqlId { get { return this.sqlId; } set { this.sqlId = value; } }

        /***********************Overrided methods*************************************************/
        public override string ToString()
        {
            string str = "";
            foreach(string specialty in this.specialties)
            {
                if (specialties.IndexOf(specialty) < this.specialties.Count - 1)
                    str += specialty + " ";
                else str += specialty;
            }
            return str;
        }
    }
}
