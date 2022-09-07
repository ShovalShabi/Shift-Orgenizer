using Asgard_Shift_Orgenizer.Classes;
using Asgard_Shift_Orgenizer.Exceptions;
using Asgard_Shift_Orgenizer.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer
{
    /// <summary>
    /// A Form object
    /// </summary>
    public partial class RemoveForm : Form
    {
        private MainForm parentForm;
       
        public RemoveForm(MainForm parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void removeForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.parentForm.mainPanel_MouseDown(sender, e);
        }

        /// <summary>
        /// Remove click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.checkFields();
                string firstName = firstNameTxtBox.Text;
                string surname = surnameTxtBox.Text;
                string serialId = SerialNumTxtBox.Text;
                Student student = new Student(firstName, surname, null, false);
                student.SerialNumber = int.Parse(serialId);
                this.parentForm.ViewRemoveStudent(student);
                this.msgLbl.Text = "Student " + student +" has been removed successfuly!";
                this.msgLbl.Visible = true;
            }
            catch (Exception ex) when (ex is FieldException ||
            ex is StudentDoesNotExistException)
            {
                SystemMessege sysMsg = new SystemMessege(ex.Message);
                sysMsg.Show();
                this.msgLbl.Visible = true;
                this.msgLbl.ForeColor = Color.FromArgb(212, 73, 63);
                this.msgLbl.Dock = DockStyle.Fill;
                this.msgLbl.Text = ex.Message;
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Checking Correction of a fields
        /// </summary>
        private void checkFields()
        {
            string msg = "Please make sure that you filled all the fields";
            if (String.IsNullOrEmpty(this.firstNameTxtBox.Text) || String.IsNullOrEmpty(this.surnameTxtBox.Text)
                || String.IsNullOrEmpty(this.SerialNumTxtBox.Text))
                throw new FieldException(msg);

            this.CheckValidationAndInjection(this.firstNameTxtBox.Text);
            this.CheckValidationAndInjection(this.surnameTxtBox.Text);
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

        private void SerialNumTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
            this.msgLbl.ForeColor = Color.FromArgb(95, 232, 164);
        }
    }
}
