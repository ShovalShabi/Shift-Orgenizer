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
    /// A Lesson object
    /// </summary>
    public class Lesson
    {
        private Instructor lessonInstructor;
        private ArrayList studentList;
        private Availability availability;
        private Specialties specialties;
        private bool isPrivate;  //true for private lesson false for public lesson
        private int sqlId;

        public Lesson(Instructor instructor, Availability availability, Specialties specialties ,bool isPrivate)
        {
            this.lessonInstructor = instructor;
            this.studentList = new ArrayList();
            this.availability = availability;
            this.specialties = specialties;
            this.isPrivate = isPrivate;
        }
        public Lesson(Availability availability, Specialties specialties, bool isPrivate)
        {
            this.studentList = new ArrayList();
            this.availability = availability;
            this.specialties = specialties;
            this.isPrivate = isPrivate;
        }
        /// <summary>
        /// Cheks for similarty of two lessons
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public bool containsAllSpecialties(Lesson lesson)
        {
            foreach (String speecialty in lesson.Specialties.SpecialtiesArr)
            {
                if (!this.specialties.SpecialtiesArr.Contains(speecialty))
                    return false;
            }
            return true;
        }

        public void AddStudent(Student student)
        {
            this.studentList.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.studentList.Remove(student);
        }
        /************************Getters and Setters *********************************************/
        public Instructor Instructor { get { return this.lessonInstructor; } set { this.lessonInstructor = value; } }

        public ArrayList StudentList { get { return studentList; } }

        public Availability Availability { get { return this.availability; } }

        public Specialties Specialties { get { return this.specialties; } }

        public bool IsPrivate { get { return this.isPrivate; } }

        public int SqlId { get { return this.sqlId; } set { this.sqlId = value; } }

        /***********************Overrided methods*************************************************/
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(obj is Lesson)
            {
                Lesson temp = (Lesson)obj;
                if (this.availability.Equals(temp.Availability) && this.isPrivate== temp.IsPrivate) return true;
            }
            return false;
        }

        public override string ToString()
        {
            string str="";
            if(this.isPrivate)
            {
                str+="Private lesson of "+this.specialties+" by "+this.lessonInstructor+"\n";
                str += "Conducted every week at " + this.availability.Day + " at "+this.availability.MinTime+ " to "+this.availability.MaxTime;
            }
            else
            {
                str += "Public lesson of " + this.specialties + " by " + this.lessonInstructor + "\n";
                str += "Conducted every week at " + this.availability.Day + " at " + this.availability.MinTime + " to "+this.availability.MaxTime; 
            }
            return str;
        }
    }
}
