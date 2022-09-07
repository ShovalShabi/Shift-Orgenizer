using Asgard_Shift_Orgenizer.Exceptions;
using Asgard_Shift_Orgenizer.Interfaces;
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
    /// A SwiimmingClub objects.
    /// The main Object that controls over the entire functionality of the backed side.
    /// Designed in Singleton design pattern
    /// </summary>
    class SwimmingClub : IModel
    {
        public static SwimmingClub instance=null;
        private ArrayList instructorsList;
        private ArrayList studentsList;
        private ArrayList lessonsList;
        private Dictionary<string, ArrayList> daysDict;
        private Dictionary<int, Student> studentsIds; //Dictionary of students serial code as keys and students objects as value
        private Dictionary<int, Lesson> lessonssIds; //Dictionary of lessons serial code as keys and lessons objects as value
        private IModel modelListener;
        private const int MAX_STUDENTS = 30;

        private SwimmingClub()
        {
            this.instructorsList =  new ArrayList();
            this.studentsList = new ArrayList();
            this.lessonsList = new ArrayList();
            this.daysDict = new Dictionary<string, ArrayList>();  //each day contains list of lessons of its own

        }

        /// <summary>
        /// Loading data from dataBbase
        /// </summary>
        public void LoadData()
        {
            DatabaseConnector dbConnector = DatabaseConnector.Instance;
            dbConnector.ConnectToDatabase();
            dbConnector.createCommand();
            dbConnector.DatabaseGetData(ref this.instructorsList, ref this.studentsList, ref this.lessonsList, ref this.daysDict, ref this.studentsIds, ref this.lessonssIds);
            Console.WriteLine("Finished loading data");
        }

        /***********************Implemented Model interface*************************************************/

        public void ModelAddModelListener(IModel listener)
        {
            this.modelListener=listener;
        }
        /// <summary>
        /// Adding Student to the model
        /// </summary>
        /// <param name="student"></param>
        /// <param name="lesson"></param>
        public void ModelAddStudent(Student student,ref  Lesson lesson)
        {
            DatabaseConnector dbConnector = DatabaseConnector.Instance;
            if (this.studentsList.Contains(student)) throw new StudentAlreadyExistException("The Student " + student.FirstName + " " + student.Surname + " is already exist");
            if (this.studentsList.Count < MAX_STUDENTS)
            {
                foreach (Instructor instructor in this.instructorsList)
                {
                    if (instructor.CanTeachLesson(ref lesson))
                    {
                        if (lesson.IsPrivate)
                        {
                            this.addLesson(lesson);
                            lesson.AddStudent(student);
                            lesson.Instructor= instructor;
                            instructor.addLesson(lesson);
                        }
                        else
                        {
                            if (!this.lessonsList.Contains(lesson))
                            {
                                this.addLesson(lesson);
                                instructor.addLesson(lesson);
                                lesson.Instructor = instructor;
                            }
                            else
                                lesson =(Lesson) this.lessonsList[this.lessonsList.IndexOf(lesson)];
                            lesson.AddStudent(student);
                        }
                        this.studentsList.Add(student);
                        dbConnector.AddStudentProcedure(student,ref lesson);
                        Console.WriteLine("The Student " + student + " added successfuly!");
                        return;
                    }
                                            
                }
                throw new AvailabilityException("Please check again for instructors availabilities");
            }
            throw new OutOfCapacityException("Sorry, there is no any room for another student at this moment");
        }
        /// <summary>
        /// Removing Student from the model
        /// </summary>
        /// <param name="student"></param>
        public void ModelRemoveStudent(Student student)
        {
            DatabaseConnector dbConnector = DatabaseConnector.Instance;
            if(this.studentsList.Contains(student))
            {
                Student trgtStudent = this.studentsIds[student.SerialNumber];
                this.studentsList.Remove(trgtStudent);
                foreach (Lesson lesson in this.lessonsList)
                {
                    if (lesson.StudentList.Contains(trgtStudent))
                    {
                        lesson.StudentList.Remove(trgtStudent);
                        if (lesson.StudentList.Count == 0)
                        {
                            this.removeLesson(lesson);
                            dbConnector.RemovelessonFromDB(lesson);
                            break;
                        }
                    }

                }
                dbConnector.RemoveStudentProcedure(trgtStudent);
                this.studentsList.Remove(trgtStudent);
                Console.WriteLine("The Student " + student.FirstName + " " + student.Surname + " " + student.SerialNumber + " got removed from the system!");
            }
            else throw new StudentDoesNotExistException("The Student " + student.FirstName + " " + student.Surname + " " + student.SerialNumber + " does not exist!");
        }

        /// <summary>
        /// Adding lesson to the model
        /// </summary>
        /// <param name="lesson"></param>
        public void addLesson(Lesson lesson)
        {
            this.lessonsList.Add(lesson);
            if (!this.daysDict.ContainsKey(lesson.Availability.Day))
                this.daysDict.Add(lesson.Availability.Day, new ArrayList());
            this.daysDict[lesson.Availability.Day.ToString()].Add(lesson);
            Console.WriteLine("The lesson on " + lesson.Availability.Day + " " + lesson.Availability.MinTime + "-" + lesson.Availability.MaxTime + " has been added successfully");
        }

        /// <summary>
        /// removing lesson from the model
        /// </summary>
        /// <param name="lesson"></param>
        public void removeLesson(Lesson lesson)
        {
            foreach(Instructor instructor in this.instructorsList)
            {
                if (instructor.Lessons.Contains(lesson))
                    instructor.Lessons.Remove(lesson);
            }
            this.lessonsList.Remove(lesson);
            this.daysDict[lesson.Availability.Day].Remove(lesson);
            Console.WriteLine("The lesson on " + lesson.Availability.Day + " " + lesson.Availability.MinTime + "-" + lesson.Availability.MaxTime + " got removed from system");
        }

        public void AddInstructor(Instructor instructor)
        {
            this.instructorsList.Add(instructor);
        }


        public ArrayList ModelGetAllInstructors()
        {
            return this.instructorsList;
        }


        public Dictionary<string, ArrayList> ModelGetAllLessonsByDays()
        {
            return this.daysDict;
        }

        public Instructor ModelGetInstrucor(string firstName, string surname, string password)
        {
            Instructor temp = new Instructor(firstName, surname, password);
            foreach(Instructor instructor in this.instructorsList)
            {
                if (instructor.Equals(temp))
                    return instructor;
            }
            throw new UserNotFoundException("Cannot find the user " + firstName + " " + surname +" , please try again");
        }

        public static SwimmingClub Instance//Part of Singleton Design Pattern
        {
            get
            {
                if (instance == null)
                    instance = new SwimmingClub();
                return instance;
            }
        }

        public IModel GetModelListener  { get { return this.modelListener; } } 
    }
}
