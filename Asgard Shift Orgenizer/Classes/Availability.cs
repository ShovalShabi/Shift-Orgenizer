using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer.Classes
{
    /// <summary>
    /// Enum structure for self use, easy to use
    /// </summary>
    public enum Day
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Week
    };

    /// <summary>
    /// Availabilty object, defines the available days of the instructors 
    /// and lessons as well
    /// </summary>
    public class Availability
    {
        private string day;
        private Time minTime;
        private Time maxTime;
        private int sqlId;

        public Availability(string day, Time minTime, Time maxTime)
        {
            this.day= day;
            this.minTime = minTime;
            this.maxTime = maxTime;

        }
        /*************************Getters,Setters**************************************/
        public string Day { get { return this.day; } set { this.day = value; } }
        public Time MinTime { get { return this.minTime; } set { this.minTime = value; } }
        public Time MaxTime { get { return this.maxTime; } set { this.maxTime = value; } }
        public int SqlId { get { return this.sqlId; } set { this.sqlId = value; } }


        /*************************Overrided Methods**************************************/
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Availability)
            {
                Availability temp = (Availability)obj;
                if (this.day.Equals(temp.Day) && this.minTime.Equals(temp.MinTime) && this.maxTime.Equals(temp.MaxTime)) return true;
            }
            return false;
        }
    }
}
