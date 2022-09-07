using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer.Classes
{
    /// <summary>
    /// A Instructor object
    /// </summary>
    public class Instructor : Person
    {
        private String password;
        private Specialties actualSpecialties;
        private ArrayList availabilities;
        private ArrayList lessons;
        private int sqlId;

        public Instructor(string firstName, string surname,string password, Specialties specialties, ArrayList availabilities) : base(firstName, surname)
        {
            this.password = password;
            this.actualSpecialties = specialties;
            this.availabilities = availabilities;
            this.lessons = new ArrayList();
        }

        public Instructor(string firstName, string surname, string password) : base(firstName, surname)
        {
            this.actualSpecialties = new Specialties();
            this.availabilities = new ArrayList();
            this.lessons = new ArrayList();
            this.password = password;
        }

        /// <summary>
        /// A method designated to see if an instructor is avaialable to teach the target lesson
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public bool CanTeachLesson(ref Lesson lesson)
        {
            bool relevent = false;
            foreach (Availability availability in this.availabilities)
            {
                if (lesson.Availability.Day != availability.Day) continue;//Makes sure the instructor is not occupied in the specific day
                else relevent = true;
                if (lesson.Availability.MinTime.isBefore(availability.MinTime) || lesson.Availability.MinTime.isAfter(availability.MaxTime))//Makes sure that the lesson doesn't get out of day's boundries
                    return false;
                if (lesson.Availability.MaxTime.isBefore(availability.MinTime) || lesson.Availability.MaxTime.isAfter(availability.MaxTime))//Makes sure that the lesson doesn't get out of day's boundries
                    return false;
            }
            if (!relevent) return false;
            foreach(Lesson lessonTemp in this.lessons)
            {
                if(lessonTemp.Availability.Day.Equals(lesson.Availability.Day))
                {
                    if ((lesson.Availability.MinTime.isAfter(lessonTemp.Availability.MinTime) && //Chekes for lessons overlaping,first two lines in the staement are for the case--> existLesson.minTime << trgtlesson.minTime << existLesson.maxTime
                    lesson.Availability.MinTime.isBefore(lessonTemp.Availability.MaxTime)) ||
                    (lesson.Availability.MaxTime.isAfter(lessonTemp.Availability.MinTime) && //Chekes for lessons overlaping,first two lines in the staement are for the case--> existLesson.minTime << trgtlesson.maxTime << existLesson.maxTime
                    lesson.Availability.MaxTime.isBefore(lessonTemp.Availability.MaxTime)))
                    {
                        if (lessonTemp.Availability.MaxTime.Equals(lesson.Availability.MinTime) || lessonTemp.Availability.MinTime.Equals(lesson.Availability.MaxTime))//The target lesson end when existing lesson starts or existing lesson end when target lesson starts
                            return this.CotainsOrHasSameSpecialties(lesson);

                        else if (!lessonTemp.IsPrivate && !lesson.IsPrivate)//If overlapping lessons and not public lessons
                        {
                            if (lessonTemp.containsAllSpecialties(lesson))//Existing lesson conatining the specialties of the target lesson
                            {
                                lesson = lessonTemp;
                                return true;
                            }
                            else
                                return false;//Non of the specialties are alike
                        }
                        else return false;//Overlapped lessons that has no common specialty or overlapping private lessons
                    }
                    else if (lessonTemp.Availability.MaxTime.Equals(lesson.Availability.MinTime) ||//Existing lesson min time = max time target lesson, or  existing lesson max time = min time target lesson or  
                        lessonTemp.Availability.MinTime.Equals(lesson.Availability.MaxTime))
                        continue;
                    else if (lessonTemp.Availability.MinTime.Equals(lesson.Availability.MinTime) &&
                            lessonTemp.Availability.MaxTime.Equals(lesson.Availability.MaxTime))
                    {
                        if (lessonTemp.IsPrivate && lesson.IsPrivate)//Private lessons on the same hours therfore return false
                            return false;

                        else if (!lessonTemp.IsPrivate && !lesson.IsPrivate)//Same hours for different public lessons
                        {
                            if (lessonTemp.containsAllSpecialties(lesson))//Existing lesson conatining the specialties of the target lesson
                            {
                                lesson = lessonTemp;
                                return true;
                            }
                            else
                                return false;//Non of the specialties are alike
                        }
                    }
                }
 
            }
            return this.CotainsOrHasSameSpecialties(lesson);//From this line a new lesson will be added in the higher class hierarchy
        }

        public bool CotainsOrHasSameSpecialties(Lesson lesson)
        {
            foreach (String specialty in lesson.Specialties.SpecialtiesArr)
            {
                if (!this.actualSpecialties.SpecialtiesArr.Contains(specialty))
                    return false;
            }
            return true;
        }

        /************************Adding and removing lessons******/
        public void addLesson(Lesson lesson)
        {
            this.lessons.Add(lesson);
        }

        public void removeLesson(Lesson lesson)
        {
            this.lessons.Remove(lessons);
        }
        /************************Getters and Setters ******************************************/
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }

        public string Surname { get { return this.surname; } set { this.surname = value; } }

        public string Password { get { return password; } set { this.password = value; } }

        public Specialties ActualSpecialties { get { return this.actualSpecialties; } set { this.actualSpecialties = value; } }

        public ArrayList Availabilities { get { return this.availabilities; } }

        public ArrayList Lessons { get { return this.lessons;} }

        public int SqlId { get { return this.sqlId; } set { this.sqlId = value; } }

        /***********************Overrided methods*********/
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Instructor)
            {
                Instructor temp = (Instructor)obj;
                if (this.firstName.Equals(temp.firstName) && this.surname.Equals(temp.surname)
                    && this.password.Equals(temp.password)) return true;
            }
            return false;
        }

        public override string ToString()
        {
            return this.firstName + " " + this.surname;
        }
    }
}
