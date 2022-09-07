using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer.Classes
{
    /// <summary>
    /// Time Object
    /// </summary>
    public class Time
    {
        private int hours;
        private int minutes;
        private int sqlId;

        public Time(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }

        /// <summary>
        /// Checking if time is before other time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool isBefore(Time time)
        {
            int currentHur = this.hours * 100, currentMin = this.minutes;
            int trgtHur = time.Hours * 100, trgtMin = time.minutes;
            if (currentHur + currentMin < trgtHur + trgtMin)
                return true;
            return false;
        }

        /// <summary>
        /// Checking if time is after other time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool isAfter(Time time)
        {
            int currentHur = this.hours * 100, currentMin = this.minutes;
            int trgtHur = time.Hours * 100, trgtMin = time.minutes;
            if (currentHur + currentMin > trgtHur + trgtMin)
                return true;
            return false;
        }

        /************************Getters and Setters ******************************************/
        public int Hours { get { return this.hours; } set { this.hours = value; } }

        public int Minutes { get { return this.minutes; } set { this.minutes = value; } }

        public int SqlId { get { return this.sqlId; } set { this.sqlId = value; } }

        public override int GetHashCode()
        {

            return base.GetHashCode();
        }

        /*************************Overrided Methods**************************************/
        public override bool Equals(object obj)
        {
            if(obj is Time)
            {
                Time temp = (Time) obj;
                if (this.hours == temp.hours && this.minutes == temp.minutes)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            string str = "";
            if (this.hours < 10)
                str += "0" + this.hours + ":";
            else
                str += this.hours + ":";
            if (this.minutes < 10)
                str += "0" + this.minutes;
            else
                str += this.minutes;
            return str;
        }

    }
}
