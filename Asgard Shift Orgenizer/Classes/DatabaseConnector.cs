using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer.Classes
{
    /// <summary>
    /// A MySQL Connetcor designed in Singleton design pattern.
    /// *Connects to a localhost*
    /// </summary>
    public class DatabaseConnector
    {
        private static DatabaseConnector instance = null;
        private MySqlConnection connection;
        private MySqlCommand command;
        private string serverName;
        private string databaseName;
        private string userName;
        private string password;
        private Dictionary<int, Time> timeIds;
        private Dictionary<int, Availability> availabiltyIds;//For easy id access
        private Dictionary<int, Specialties> speciltiesIds;//For easy id access
        private Dictionary<int, Student> studentIds;//For easy id access
        private Dictionary<int, Instructor> instructorsIds;//For easy id access
        private Dictionary<int, Lesson> lessonIds;//For easy id access
        private SortedSet<int> unusedTimeIds; //For storing ids bu order
        private SortedSet<int> unusedAvailabiltyIds;//For storing ids bu order
        private SortedSet<int> unusedSpecialtiesIds;//For storing ids bu order
        private SortedSet<int> unusedStudentsIds;//For storing ids bu order
        private SortedSet<int> unusedLessonsIds;//For storing ids bu order

        private DatabaseConnector()
        {
            this.serverName = "your_server_name";
            this.databaseName = "swimmingclub";
            this.userName = "your_username";
            this.password = "your_password";
            this.timeIds = new Dictionary<int, Time>();
            this.availabiltyIds = new Dictionary<int, Availability>();
            this.speciltiesIds = new Dictionary<int, Specialties>();
            this.speciltiesIds = new Dictionary<int, Specialties>();
            this.studentIds = new Dictionary<int, Student>();
            this.instructorsIds = new Dictionary<int, Instructor>();
            this.lessonIds = new Dictionary<int, Lesson>();
            this.unusedTimeIds = new SortedSet<int>();
            this.unusedAvailabiltyIds = new SortedSet<int>();
            this.unusedSpecialtiesIds = new SortedSet<int>();
            this.unusedStudentsIds = new SortedSet<int>();
            this.unusedLessonsIds = new SortedSet<int>();            
        }
        /// <summary>
        /// The main loading part when the app starts.
        /// </summary>
        /// <param name="allInstrucors"></param>
        /// <param name="allStudents"></param>
        /// <param name="allLessons"></param>
        /// <param name="dayDict"></param>
        /// <param name="studentsDict">referenced from Swimming club Object!!</param>
        /// <param name="lessonsDict"></param>
        public void DatabaseGetData(ref ArrayList allInstrucors , ref ArrayList allStudents , ref ArrayList allLessons,
            ref Dictionary<string,ArrayList> dayDict,ref Dictionary<int,Student> studentsDict,ref Dictionary<int, Lesson> lessonsDict)
        {
            this.GetAllTimesFromDB();
            this.GetAllAvailabilitiesFromDB();
            this.GetAllSpecialtiesFromDB();
            allStudents = this.GetAllStudentsFromDB();
            allInstrucors = this.GetAllInstructorsFromDB();
            allLessons = this.GetAllLessonsFromDB();
            this.AssignStudentsToLessons(allStudents, allLessons);
            this.MatchInstructorsAvailabilities();
            this.OrganizeDaysForlessons(dayDict, allLessons);
            studentsDict = this.studentIds;
            lessonsDict = this.lessonIds;

        }
        /// <summary>
        /// Adding Student To DB, all the procedure
        /// </summary>
        /// <param name="student"></param>
        /// <param name="lesson"></param>
        public void AddStudentProcedure(Student student,ref Lesson lesson)
        {
            if(!lessonIds.ContainsKey(lesson.SqlId))
                this.AddLessonToDB(lesson);
            this.AddStudentToDB(student);
            this.AddStudentToStudentLessonTable(student,lesson);
        }

        /// <summary>
        /// Removing Student from the DB procedure
        /// </summary>
        /// <param name="student"></param>
        public void RemoveStudentProcedure(Student student)
        {
            this.RemoveStudentFromLessonStudentTable(student);
            this.RemoveStudentFromDB(student);
        }

        /// <summary>
        /// Creating general command for queries
        /// </summary>
        public void createCommand()
        {
            this.command = this.connection.CreateCommand();
        }

        /// <summary>
        /// Loading all the Objects time from DB
        /// </summary>
        public void GetAllTimesFromDB()
        {
            string cmdStr = "select * from timeTable;";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            int maxId = 1000;
            while(reader.Read())
            {
                int tid= int.Parse(reader["tid"].ToString());
                int hours= int.Parse(reader["hours"].ToString());
                int minutes= int.Parse(reader["minutes"].ToString());
                Time time = new Time(hours, minutes);
                time.SqlId = tid;
                this.timeIds.Add(tid, time);
                if(tid==maxId)
                    maxId = tid+1;
            }
            reader.Close();
            this.unusedTimeIds.Add(maxId);
        }

        /// <summary>
        /// Storing Time Object To Db
        /// </summary>
        /// <param name="time"></param>
        public void AddTimeToDB(Time time)
        {
            int id = this.unusedTimeIds.ElementAt(0);//the minimal id as possible
            if (this.unusedTimeIds.Count == 1)
            {
                time.SqlId = id;
                this.unusedTimeIds.Remove(id);
                this.unusedTimeIds.Add(id+1);
            }
            else
            {
                time.SqlId = id;
                this.unusedTimeIds.Remove(id);
            }
            string cmdStr = "insert into timeTable values("+time.SqlId+"," + time.Hours + "," + time.Minutes + ");";
            this.command = new MySqlCommand(cmdStr,this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.unusedTimeIds.Remove(time.SqlId);
        }

        /// <summary>
        /// Removing Time Object from DB
        /// </summary>
        /// <param name="time"></param>
        public void RemoveTimeFromDB(Time time)
        {
            string cmdStr = "delete from timeTable where tid="+time.SqlId+ ";";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.unusedTimeIds.Add(time.SqlId);
            this.timeIds.Remove(time.SqlId);
        }

        /// <summary>
        /// loading all availabilties objects from DB
        /// </summary>
        public void GetAllAvailabilitiesFromDB()
        {
            string cmdStr = "select * from availabilityTable;";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            int maxId = 1000;
            while (reader.Read())
            {
                int av_id = int.Parse(reader["av_id"].ToString());
                string day = reader["day"].ToString();
                int tid_min = int.Parse(reader["tid_min"].ToString());
                int tid_max = int.Parse(reader["tid_max"].ToString());
                Time minTime = this.timeIds[tid_min];
                Time maxTime = this.timeIds[tid_max];
                Availability availability = new Availability(day, minTime, maxTime);
                availability.SqlId = av_id;
                this.availabiltyIds.Add(av_id, availability);
                if (av_id == maxId)
                    maxId = av_id+1;
            }
            reader.Close();
            this.unusedAvailabiltyIds.Add(maxId);
        }

        /// <summary>
        /// Adding Availability Object to DB
        /// </summary>
        /// <param name="availability"></param>
        public void AddAvialabilityToDB(Availability availability)
        {
            int id = this.unusedAvailabiltyIds.ElementAt(0);//the minimal id as possible
            if (this.unusedAvailabiltyIds.Count == 1)
            {
                availability.SqlId = id;
                this.unusedAvailabiltyIds.Remove(id);
                this.unusedAvailabiltyIds.Add(id+1);
            }
            else
            {
                availability.SqlId = id;
                this.unusedAvailabiltyIds.Remove(id);
            }
            this.AddTimeToDB(availability.MinTime);
            this.AddTimeToDB(availability.MaxTime);
            string cmdStr = "insert into availabilityTable values("+availability.SqlId+",'" +availability.Day+"',"+ availability.MinTime.SqlId + "," + availability.MaxTime.SqlId + ");";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.availabiltyIds.Add(availability.SqlId, availability);
            this.unusedAvailabiltyIds.Remove(availability.SqlId);
        }

        /// <summary>
        /// Removing Availability Object from Db
        /// </summary>
        /// <param name="availability"></param>
        public void RemoveAvailabilityFromDB(Availability availability)
        {
            string cmdStr = "delete from availabilityTable where av_id=" + availability.SqlId + ";";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.RemoveTimeFromDB(availability.MinTime);
            this.RemoveTimeFromDB(availability.MaxTime);
            this.unusedAvailabiltyIds.Add(availability.SqlId);
            this.availabiltyIds.Remove(availability.SqlId);
        }

        /// <summary>
        /// loading all specialties objects from DB
        /// </summary>
        public void GetAllSpecialtiesFromDB()
        {
            string cmdStr = "select * from specialtyTable;";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            int maxId = 1000;
            ArrayList specialtiesArr = new ArrayList();
            ArrayList boolArr = new ArrayList();
            ArrayList trgtSpecialties = new ArrayList();
            while (reader.Read())
            {
                specialtiesArr.Add("Chest");
                specialtiesArr.Add("Front Crawl");
                specialtiesArr.Add("Back Stroke");
                specialtiesArr.Add("Butterfly Stroke");
                int sp_id = int.Parse(reader["sp_id"].ToString());
                boolArr.Add(reader["chest"].ToString());
                boolArr.Add(reader["front_crawl"].ToString());
                boolArr.Add(reader["back_stroke"].ToString());
                boolArr.Add(reader["butterfly_stroke"].ToString());
                for (int i = 0; i < boolArr.Count; i++)
                {
                    if (bool.Parse((string)boolArr[i]))
                        trgtSpecialties.Add(specialtiesArr[i]);
                }
                Specialties specialties = new Specialties();
                specialties.SpecialtiesArr = new ArrayList(trgtSpecialties);
                specialties.SqlId = sp_id;
                this.speciltiesIds.Add(sp_id, specialties);
                if (sp_id == maxId)
                    maxId = sp_id+1;
                specialtiesArr.Clear();
                boolArr.Clear();
                trgtSpecialties.Clear();
            }
            reader.Close();
            this.unusedSpecialtiesIds.Add(maxId);
        }

        /// <summary>
        /// Adding Specialties Object to Db
        /// </summary>
        /// <param name="specialties"></param>
        public void AddSpecialtiesToDB(Specialties specialties)
        {
            ArrayList tempSpecilties = new ArrayList();
            ArrayList specialtiesStrs = new ArrayList();
            specialtiesStrs.Add("Chest");
            specialtiesStrs.Add("Front Crawl");
            specialtiesStrs.Add("Back Stroke");
            specialtiesStrs.Add("Butterfly Stroke");
            foreach (string specialty in specialtiesStrs)
            {
                if (specialties.SpecialtiesArr.Contains(specialty))
                    tempSpecilties.Add(true);
                else
                    tempSpecilties.Add(false);
            }
            int id = this.unusedSpecialtiesIds.ElementAt(0);//the minimal id as possible
            if (this.unusedSpecialtiesIds.Count == 1)
            {
                specialties.SqlId = id;
                this.unusedSpecialtiesIds.Remove(id);
                this.unusedSpecialtiesIds.Add(1000+this.speciltiesIds.Count + 2);
            }
            else
            {
                specialties.SqlId = id;
                this.unusedSpecialtiesIds.Remove(id);
            }
            string cmdStr = "insert into specialtyTable values(" + specialties.SqlId+"," + tempSpecilties[0] + "," + tempSpecilties[1] + "," + tempSpecilties[2]+ "," + tempSpecilties[3] + ");";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.speciltiesIds.Add(specialties.SqlId, specialties);
            this.unusedSpecialtiesIds.Remove(specialties.SqlId);
            
        }

        /// <summary>
        /// Removing Specilties Object from DB
        /// </summary>
        /// <param name="specialties"></param>
        public void RemoveSpecialtiesFromDB(Specialties specialties)
        {

            string cmdStr = "delete from specialtyTable where sp_id=" + specialties.SqlId + ";";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.unusedSpecialtiesIds.Add(specialties.SqlId);
            this.speciltiesIds.Remove(specialties.SqlId);
        }

        /// <summary>
        /// Getting all students objects from DB
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllStudentsFromDB()
        {
            ArrayList studentList = new ArrayList();
            string cmdStr = "select * from studentTable;";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            int maxId = 1000;
            while (reader.Read())
            {
                int sid= int.Parse(reader["sid"].ToString());
                string firstName = reader["firstname"].ToString();
                string surname = reader["surname"].ToString();
                int sp_id = int.Parse(reader["sp_id"].ToString());
                Student student = new Student(firstName,surname,this.speciltiesIds[sp_id],false);// for initial creation
                student.SerialNumber = sid;
                if (sid == maxId)
                    maxId = sid+1;
                this.studentIds.Add(student.SerialNumber, student);
                studentList.Add(student);
            }
            reader.Close();
            this.unusedStudentsIds.Add(maxId);
            return studentList;
        }

        /// <summary>
        /// Adding student object to DB
        /// </summary>
        /// <param name="student"></param>
        public void AddStudentToDB(Student student)
        {
            int id = this.unusedStudentsIds.ElementAt(0);//the minimal id as possible
            if (this.unusedStudentsIds.Count == 1)
            {
                student.SerialNumber = id;
                this.unusedStudentsIds.Remove(id);
                this.unusedStudentsIds.Add(id+1);
            }
            else
            {
                student.SerialNumber = id;
                this.unusedStudentsIds.Remove(id);
            }
            this.unusedStudentsIds.Add(student.SerialNumber);
            this.AddSpecialtiesToDB(student.Specialties);
            string cmdStr = "insert into studentTable values("+student.SerialNumber+",'" + student.FirstName + "','" + student.Surname + "'," + student.Specialties.SqlId + ");";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.studentIds.Add(student.SerialNumber, student);
            this.unusedStudentsIds.Remove(student.SerialNumber);
        }

        /// <summary>
        /// removing Student object from DB
        /// </summary>
        /// <param name="student"></param>
        public void RemoveStudentFromDB(Student student)
        {
            string cmdStr = "delete from studentTable where sid=" + student.SerialNumber + ";";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.RemoveSpecialtiesFromDB(student.Specialties);
            this.unusedStudentsIds.Add(student.SerialNumber);
            this.studentIds.Remove(student.SerialNumber);

        }

        /// <summary>
        /// Loading all instructors objects drom DB
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllInstructorsFromDB()
        {
            ArrayList instructorList = new ArrayList();
            string cmdStr = "select * from instructorTable;";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            while (reader.Read())
            {
                int instructor_id = int.Parse(reader["instructor_id"].ToString());
                string firstName = reader["firstname"].ToString();
                string surname = reader["surname"].ToString();
                string password = reader["password"].ToString();
                int sp_id = int.Parse(reader["sp_id"].ToString());
                Instructor instructor = new Instructor(firstName, surname, password);// for initial creation
                instructor.SqlId = instructor_id;
                instructor.ActualSpecialties = speciltiesIds[sp_id];
                instructorsIds.Add(instructor_id, instructor);
                instructorList.Add(instructor);
            }
            reader.Close();
            return instructorList;
        }

        /// <summary>
        /// Loading all lessons objects drom DB
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllLessonsFromDB()
        {
            ArrayList lessonsList = new ArrayList();
            string cmdStr = "select * from lessonTable";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            int maxId = 1000;
            while (reader.Read())
            {
                int lid = int.Parse(reader["lid"].ToString());
                bool isPrivate = bool.Parse(reader["isprivate"].ToString());
                int av_id = int.Parse(reader["av_id"].ToString());
                int sp_id = int.Parse(reader["sp_id"].ToString());
                int instructor_id = int.Parse(reader["instructor_id"].ToString());
                Lesson lesson = new Lesson(instructorsIds[instructor_id], availabiltyIds[av_id], speciltiesIds[sp_id], isPrivate);// for initial creation
                lesson.SqlId = lid;
                this.instructorsIds[instructor_id].Lessons.Add(lesson);
                if (lid == maxId)
                    maxId =lid+1;
                lessonsList.Add(lesson);
                this.lessonIds.Add(lid, lesson);
            }
            reader.Close();
            this.unusedLessonsIds.Add(maxId);
            return lessonsList;
        }

        /// <summary>
        /// Adding lesson Object to DB
        /// </summary>
        /// <param name="lesson"></param>
        public void AddLessonToDB(Lesson lesson)
        {
            int id = this.unusedLessonsIds.ElementAt(0);//the minimal id as possible
            if (this.unusedLessonsIds.Count == 1)
            {
                lesson.SqlId = id;
                this.unusedLessonsIds.Remove(id);
                this.unusedLessonsIds.Add(id+1);
            }
            else
            {
                lesson.SqlId = id;
                this.unusedLessonsIds.Remove(id);
            }
            this.AddAvialabilityToDB(lesson.Availability);
            this.AddSpecialtiesToDB(lesson.Specialties);
            string cmdStr = "insert into lessonTable values("+lesson.SqlId+"," + lesson.IsPrivate + "," + lesson.Availability.SqlId + "," + lesson.Specialties.SqlId +","+lesson.Instructor.SqlId +");";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.lessonIds.Add(lesson.SqlId, lesson);
            this.unusedLessonsIds.Remove(lesson.SqlId);
        }

        /// <summary>
        /// Removing Lesson object From DB
        /// </summary>
        /// <param name="lesson"></param>
        public void RemovelessonFromDB(Lesson lesson)
        {
            this.RemoveLessonFromLessonStudentTable(lesson);
            string cmdStr = "delete from lessonTable where lid=" + lesson.SqlId + ";";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
            this.RemoveAvailabilityFromDB(lesson.Availability);
            this.RemoveSpecialtiesFromDB(lesson.Specialties);
            this.unusedLessonsIds.Add(lesson.SqlId);
            this.lessonIds.Remove(lesson.SqlId);
        }

        /// <summary>
        /// Assigning student to lessons by MySQl Table:lessonStudentTable
        /// </summary>
        /// <param name="studentsList"></param>
        /// <param name="lessonsList"></param>
        public void AssignStudentsToLessons(ArrayList studentsList,ArrayList lessonsList)
        {
            string cmdStr = "select * from lessonStudentTable;";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            while(reader.Read())
            {
                int lid = int.Parse(reader["lid"].ToString());
                int sid = int.Parse(reader["sid"].ToString());
                this.lessonIds[lid].AddStudent(this.studentIds[sid]);
            }
            reader.Close();
        }

        /// <summary>
        /// Adding student to MySQl Table:lessonStudentTable
        /// </summary>
        /// <param name="student"></param>
        /// <param name="lesson"></param>
        public void AddStudentToStudentLessonTable(Student student, Lesson lesson)
        {
            string cmdStr = "insert into lessonStudentTable values(" + lesson.SqlId + "," + student.SerialNumber + ");";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
        }
        /// <summary>
        /// Removing student from  MySQl Table:lessonStudentTable
        /// </summary>
        /// <param name="student"></param>
        public void RemoveStudentFromLessonStudentTable(Student student)
        {
            string cmdStr = "delete from lessonStudentTable where sid=" + student.SerialNumber + ";";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
        }

        public void RemoveLessonFromLessonStudentTable(Lesson lesson)
        {
            string cmdStr = "delete from lessonStudentTable where lid=" + lesson.SqlId + ";";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            reader.Close();
        }

        /// <summary>
        /// Matching instructors to their availabilities
        /// </summary>
        public void MatchInstructorsAvailabilities()
        {
            string cmdStr = "select * from instructorAvailabilityTable;";
            this.command = new MySqlCommand(cmdStr, this.connection);
            MySqlDataReader reader = this.command.ExecuteReader();
            while (reader.Read())
            {
                int instructor_id = int.Parse(reader["instructor_id"].ToString());
                int av_id = int.Parse(reader["av_id"].ToString());
                this.instructorsIds[instructor_id].Availabilities.Add(availabiltyIds[av_id]);
            }
            reader.Close();
        }

        /// <summary>
        /// Organizing lessons by days
        /// </summary>
        /// <param name="daysDict"></param>
        /// <param name="lessons"></param>
        public void OrganizeDaysForlessons(Dictionary<string,ArrayList>daysDict, ArrayList lessons)
        {
            foreach(Lesson lesson in lessons)
            {
                if (!daysDict.ContainsKey(lesson.Availability.Day))
                    daysDict.Add(lesson.Availability.Day, new ArrayList());
                daysDict[lesson.Availability.Day].Add(lesson);
            }
        }
        /********************************Getters and Setters******************************************************/
        public string ServerName { get { return this.serverName; } set { this.serverName = value; } }
        public string DatabaseName { get { return this.databaseName; } set { this.databaseName = value; } }
        public string UserName { get { return this.userName; } set { this.userName = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }

        public static DatabaseConnector Instance
        {
            get
            {
                if (instance == null)
                    instance = new DatabaseConnector();
                return instance;
            }
        }

        /// <summary>
        /// Connecting to DB
        /// </summary>
        public void ConnectToDatabase()
        {
            if (this.connection == null)
            {
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", ServerName, DatabaseName, UserName, Password);
                this.connection = new MySqlConnection(connstring);
                this.connection.Open();
                Console.WriteLine("database connected!" + this.connection);
            }
        }

        /// <summary>
        /// Disconnecting from DB
        /// </summary>
        public void DisconnectFromDatabase()
        {
            this.connection.Close();
        }
    }
}
