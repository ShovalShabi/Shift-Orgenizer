using Shift_Orgenizer.Classes;
using Shift_Orgenizer.Exceptions;
using Shift_Orgenizer.UI;
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

namespace Shift_Orgenizer
{
    /// <summary>
    /// A form Object
    /// </summary>
    public partial class LoginForm : Form
    {
        private MainForm parentForm;
        public LoginForm(MainForm parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        /// <summary>
        /// For screen movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            parentForm.mainPanel_MouseDown(sender, e);
        }

        /// <summary>
        /// Login button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string firstName="", surname="";
            try
            {
                this.checkFields();
                char[] signs = { ' ' };
                string[] names = usrTxtBox.Text.Split(signs);// should return ["firstName","surname"]
                firstName = names[0];
                surname = names[1];
                string password = passTxtBox.Text;
                Instructor instructor=this.parentForm.ViewGetInstructor(firstName,surname,password);
                this.parentForm.MainPanel.Controls.Clear();
                this.parentForm.DescriptionLabel.Text = "Home Page";
                this.parentForm.UserNameLabel.Text = "Hello " + firstName + " " + surname + "!";
                this.parentForm.ButtonPanel.Visible = true;
                this.parentForm.UserPanel.Visible = true;
                this.parentForm.MainPanel.Controls.Add(this.parentForm.BgPictureBox);
                this.parentForm.BgPictureBox.Visible = true;
                this.parentForm.MenuPanel.BackColor = Color.FromArgb(24, 30, 54);
                this.parentForm.HeadPanel.BackColor = Color.FromArgb(46, 51, 73);
            }
            catch (Exception ex ) when (ex is FieldException || ex is UserNotFoundException || ex is IndexOutOfRangeException)
            {
                string msg;
                if (ex is IndexOutOfRangeException)
                    msg="Wrong user name or password";
                else
                    msg = ex.Message;
                SystemMessege sysMsg = new SystemMessege(msg);
                sysMsg.Show();
                this.msgLbl.Visible = true;
                this.msgLbl.ForeColor = Color.FromArgb(212, 73, 63);
                this.msgLbl.Dock = DockStyle.Fill;
                this.msgLbl.Text = msg;
                Console.WriteLine(msg);
            }
        }

        /// <summary>
        /// Checking Correction of the fields
        /// </summary>
        private void checkFields()
        {
            String msg = "Please make sure that you filled all the fields";
            if (String.IsNullOrEmpty(this.usrTxtBox.Text) || String.IsNullOrEmpty(this.passTxtBox.Text))
                throw new FieldException(msg);

            this.CheckValidationAndInjection(this.usrTxtBox.Text);
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
                if (!char.IsLetter(str[i])&&!char.IsWhiteSpace(str[i]))
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

        private void usrTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
        }

        private void passTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.msgLbl.Visible = false;
        }
    }
}
