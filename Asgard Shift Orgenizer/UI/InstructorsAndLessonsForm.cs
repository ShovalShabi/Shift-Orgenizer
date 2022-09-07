using Asgard_Shift_Orgenizer.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer.UI
{
    public partial class InstructorsAndLessonsForm : Form
    {
        private MainForm parentForm;
        private ArrayList allInstructors;
        private Instructor instructor;
        private Lesson lesson;
        private bool displayOtherlessons;

        public object Arraylist { get; private set; }

        public InstructorsAndLessonsForm(MainForm mainForm, Instructor instructor, Lesson lesson)
        {
            InitializeComponent();
            this.parentForm = mainForm;
            this.instructor = instructor;
            this.lesson = lesson;
            this.displayOtherlessons = false;
            this.LoadLeftSide();
        }

        public InstructorsAndLessonsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.parentForm = mainForm;
            this.allInstructors = this.parentForm.ViewGetAllInstructors();
            this.instructor=null;
            this.lesson = null;
            this.displayOtherlessons = true;
            this.loadInstructorsForm();
            this.LoadLeftSide();
        }
        /// <summary>
        /// Loading form's data
        /// </summary>
        private void loadInstructorsForm()
        {
            this.headlineLbl.Visible = true;
            this.instructorNameLbl.Visible = false;
            this.instSpecialtyCmbBox.Visible = false;
            this.specialtiesLbl.Visible = false;
            this.availabilityLbl.Visible = false;
            this.availabiltyCmb.Visible = false;
            this.allInstructorsLbl.Visible = true;
            this.instructorsCmb.Visible = true;
            foreach (Instructor instructor in this.allInstructors)
                instructorsCmb.Items.Add(instructor.ToString());
        }

        /// <summary>
        /// This will load the form for lesson + instructor presentation or only instructor presentation
        /// </summary>
        private void LoadLeftSide()
        {
            if(instructor!=null)
            {
                if (instructor.ActualSpecialties.SpecialtiesArr.Count < 2)
                {
                    this.specialtiesLbl.Text = "Specialty:" + instructor.ActualSpecialties;
                }
                else
                {
                    foreach (String specialties in instructor.ActualSpecialties.SpecialtiesArr)
                        this.instSpecialtyCmbBox.Items.Add(specialties);
                }
                foreach (Availability availability in instructor.Availabilities)
                    this.availabiltyCmb.Items.Add(availability.Day + " " + availability.MinTime + "-" + availability.MaxTime);
                if (this.displayOtherlessons)
                {
                    this.instructorNameLbl.Text = this.instructor.ToString();
                    ArrayList allLessons = this.instructor.Lessons;
                    this.chooselessonlbl.Visible = true;
                    this.lessonsCmbBox.Visible = true;
                    if(this.instructor.Lessons.Count>0)
                    {
                        this.lesson = (Lesson)instructor.Lessons[0];
                        foreach (Lesson lesson in instructor.Lessons)
                            this.lessonsCmbBox.Items.Add(lesson.Availability.Day + "  " + lesson.Availability.MinTime + "-" + lesson.Availability.MaxTime);
                        if (lesson.StudentList.Count < 2)
                            this.studntCmbBox.Visible = false;
                    }

                }
                else
                {
                    this.instructorNameLbl.Text = this.instructor.ToString();
                }
                this.LoadRightSide();
            }
           
        }
        /// <summary>
        /// Loading left side of the form
        /// </summary>
        private void LoadRightSide()
        {
            if(this.lesson!=null)
            {
                this.lessonTypeLbl.Visible = true;
                this.lessonSpeclbl.Visible = true;
                this.studentsLbl.Visible = true;
                this.dayLbl.Visible = true;
                if (this.lesson.IsPrivate)
                {
                    this.lessonTypeLbl.Text = "Private lesson";
                    this.studentsLbl.Text = "Student: " + this.lesson.StudentList[0];
                }
                else
                {
                    this.lessonTypeLbl.Text = "Public lesson";
                    this.studentsLbl.Text = "Participating Students:";
                    foreach (Student student in lesson.StudentList)
                        this.studntCmbBox.Items.Add(student);
                    this.studntCmbBox.Visible = true;
                }

                if (lesson.Specialties.SpecialtiesArr.Count < 2)
                    this.lessonSpeclbl.Text = "Lesson's topic is " + lesson.Specialties;
                else
                {
                    foreach (String specialties in lesson.Specialties.SpecialtiesArr)
                        this.specialtiesCmbBox.Items.Add(specialties);
                    this.specialtiesCmbBox.Visible = true;
                }
                this.dayLbl.Text = "Contucted every " + lesson.Availability.Day + " at " + lesson.Availability.MinTime + "-" + lesson.Availability.MaxTime;
            }
            else
            {
                this.lessonTypeLbl.Visible = true;
                this.lessonTypeLbl.Text = "The instructor has no lessons at this moment!";
                this.specialtiesCmbBox.Visible = false;
                this.studntCmbBox.Visible = false;
                this.lessonSpeclbl.Visible = false;
                this.studentsLbl.Visible = false;
                this.dayLbl.Visible = false;
            }
            
        }
        /// <summary>
        /// For screen movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstructorsAndLessonsForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.parentForm.mainPanel_MouseDown(sender, e);
        }

        private void lessonsCmbBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.instructor.Lessons.Count > 0 && this.lessonsCmbBox.SelectedIndex != -1)
                this.lesson = (Lesson)this.instructor.Lessons[this.lessonsCmbBox.SelectedIndex];
            if (lesson!=null && lesson.StudentList.Count < 2)
                this.studntCmbBox.Visible = false;
            if(this.instructor.Lessons.Count == 0)
            {
                this.lesson = null;
                this.studntCmbBox.Visible = false;
            }
                this.specialtiesCmbBox.Text = null;
            this.specialtiesCmbBox.Items.Clear();
            this.studntCmbBox.Text = null;
            this.studntCmbBox.Items.Clear();
            this.LoadRightSide();
        }

        private void instructorsCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            this.headlineLbl.Visible = false;
            this.instructorNameLbl.Visible = true;
            this.instSpecialtyCmbBox.Visible = true;
            this.specialtiesLbl.Visible = true;
            this.availabilityLbl.Visible = true;
            this.availabiltyCmb.Visible = true;
            this.instructor = (Instructor)this.allInstructors[this.instructorsCmb.SelectedIndex];
            this.instSpecialtyCmbBox.Text = null;
            this.instSpecialtyCmbBox.Items.Clear();
            this.availabiltyCmb.Text = null;
            this.availabiltyCmb.Items.Clear();
            this.lessonsCmbBox.Text = null;
            this.lessonsCmbBox.Items.Clear();
            this.studntCmbBox.Text = null;
            this.studntCmbBox.Items.Clear();
            this.specialtiesCmbBox.Text = null;
            this.specialtiesCmbBox.Items.Clear();
            this.lesson = null;
            this.LoadLeftSide();
        }

    }
}
