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
using Asgard_Shift_Orgenizer.Classes;
using Asgard_Shift_Orgenizer.Exceptions;
using Asgard_Shift_Orgenizer.UI;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer
{
    /// <summary>
    /// A Form Object
    /// </summary>
    public partial class AddForm : Form
    {
        private MainForm parentForm;
        private ArrayList chkBoxes;
        public AddForm(MainForm parentForm)
        {
            InitializeComponent();
            this.IntializeComboBoxes();
            this.chkBoxes = new ArrayList();
            this.IntializeChkBoxList();
            this.parentForm = parentForm;
        }

        /// <summary>
        /// Clicking for form movement on the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.parentForm.mainPanel_MouseDown(sender,e);
        }

        /// <summary>
        /// Adding Student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.checkFields();
                bool privateLesson = privateRdoBtn.Checked;
                char[] signs = { ':' };
                string[] time = hourCmbBox.Text.Split(signs);// should return ["hh","mm"]
                int sHour, sMin, eHour, eMin;
                sHour = int.Parse(time[0]);
                sMin = int.Parse(time[1]);
                if (privateLesson)
                {
                    eHour = sHour + 1;
                    eMin = sMin;
                }
                    
                else
                {
                    if ((sMin + 45) / 60 != 0)
                    {
                        eHour = sHour + 1;
                        eMin = (sMin + 45) % 60;
                    }
                    else
                    {
                        eHour = sHour;
                        eMin = sMin + 45;
                    }
                }
                Time startHour = new Time(sHour, sMin);
                Time endHour = new Time(eHour, eMin);
                Specialties specialties = new Specialties();
                Specialties lessonSpecialties = new Specialties();
                foreach(CheckBox checkBox in this.chkBoxes)
                {
                    if(checkBox.Checked)
                    {
                        specialties.SpecialtiesArr.Add(checkBox.Text);
                        lessonSpecialties.SpecialtiesArr.Add(checkBox.Text);
                    }
                        
                }
                Availability availability = new Availability(dayCmbBox.Text, startHour,endHour);
                Student student = new Student(firstNameTxtBox.Text, surnameTxtBox.Text, specialties,privateLesson);
                Lesson lesson = new Lesson(availability, lessonSpecialties, privateLesson);
                this.parentForm.ViewAddStudent(student, lesson);
                this.msgLbl.Visible = true;
                this.msgLbl.Text = "The student " + student + " has been added successfuly!";
            }
            catch (Exception ex) when (ex is FieldException ||
            ex is StudentAlreadyExistException ||
            ex is AvailabilityException)
            {
                SystemMessege sysMsg = new SystemMessege(ex.Message);
                Console.WriteLine(ex);
                sysMsg.Show();
                this.msgLbl.Visible = true;
                this.msgLbl.ForeColor = Color.FromArgb(212, 73, 63);
                this.msgLbl.Dock = DockStyle.Fill;
                this.msgLbl.Text = ex.Message;
            }

        }

        /// <summary>
        /// Intializing hours comboBoxes
        /// </summary>
        private void IntializeComboBoxes()
        {
            int numDays = (int)Classes.Day.Week;
            for(int i=0; i<numDays;i++)
            {
                this.dayCmbBox.Items.Add((Classes.Day)i);
            }
            int hours = 8, min=0;
            while (hours<20)
            {
                if (min < 10)
                    this.hourCmbBox.Items.Add(hours + ":0" + min);
                else
                    this.hourCmbBox.Items.Add(hours + ":" + min);
                min += 5;
                if (min % 60 == 0)
                {
                    hours++;
                    min = 0;
                }
                    
            }
        }

        /// <summary>
        /// Intializing checkBoxes
        /// </summary>
        private void IntializeChkBoxList()
        {
            foreach(Control control in this.Controls)
            {
                if(control is CheckBox)
                {
                    this.chkBoxes.Add(control);
                }

            }
        }

        /// <summary>
        /// Checking correction of the fields
        /// </summary>
        private void checkFields()
        {
            string msg = "Please make sure that you filled all the fields";
            if(!this.groupRdoBtn.Checked && !this.privateRdoBtn.Checked)
                throw new FieldException(msg);

            if (!this.chestChkBox.Checked && !this.frontChkBox.Checked && !this.backChkBox.Checked && !this.butterflyChkBox.Checked)
                throw new FieldException(msg);

            if (String.IsNullOrEmpty(this.firstNameTxtBox.Text) || String.IsNullOrEmpty(this.surnameTxtBox.Text))
                throw new FieldException(msg);

            this.CheckValidationAndInjection(firstNameTxtBox.Text);
            this.CheckValidationAndInjection(surnameTxtBox.Text);

            if (string.IsNullOrEmpty(this.dayCmbBox.Text) || string.IsNullOrEmpty(this.hourCmbBox.Text))
                throw new FieldException(msg);
        }

        /// <summary>
        /// This function checks for valid fields and preventing SQL injection
        /// </summary>
        /// <param name="str"></param>
        private void CheckValidationAndInjection(string str)
        {
            string[] blackList = { "insert", "insert values", "delete", "delete values", "select", "select from", "drop", "drop table", "join", "table" };
            string msg = "Please enter valid first name or surname";
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]) && !char.IsWhiteSpace(str[i]))
                    throw new FieldException(msg);
            }
            char[] splitters = { ' ' };
            string[] splitStr = str.Split(splitters);
            foreach (string strTemp in splitStr)
            {
                if (blackList.Contains(strTemp.ToLower()))
                    throw new FieldException(msg);
            }
        }

        private void firstNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void surnameTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void chestChkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void frontChkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void backChkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void butterflyChkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void privateRdoBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void groupRdoBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void dayCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

        private void hourCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }

    }
}
