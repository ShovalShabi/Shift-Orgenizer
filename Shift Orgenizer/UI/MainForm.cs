using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Shift_Orgenizer.Interfaces;
using Shift_Orgenizer.Classes;
using System.Collections;
using Shift_Orgenizer.UI;
using System.Resources;
using Shift_Orgenizer.Properties;

//presenter:Shoval Shabi

namespace Shift_Orgenizer
{
    /// <summary>
    /// A Form Object that hold the etire functionality of the view
    /// </summary>
    public partial class MainForm : Form, IView
    {
        private Form childForm;
        private IView viewListener;

        //For rounding the window's form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );

        public MainForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        //for window movement, controlled by the main panel within the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void buttonPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainPanel_MouseDown(sender, e);
        }

        private void userDetailsPnl_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainPanel_MouseDown(sender, e);
        }

        private void headPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainPanel_MouseDown(sender, e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainPanel_MouseDown(sender, e);
        }

        private void userNameLbl_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainPanel_MouseDown(sender, e);
        }

        private void userIconPB_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainPanel_MouseDown(sender, e);
        }

        private void bgImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainPanel_MouseDown(sender, e);
        }

        /// <summary>
        /// Viewing weekly shifts table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weeklyShiftsBtn_Click(object sender, EventArgs e)
        {
            this.headPanel.BackColor = Color.FromArgb(79, 126, 161);
            this.descriptionLbl.ForeColor = Color.FromArgb(165, 186, 201);
            this.weeklyShiftsBtn.BackColor = Color.FromArgb(46, 51, 73);
            this.changeBtnsColor(weeklyShiftsBtn);
            this.descriptionLbl.Text = "Weekly Shifts";
            this.mainPanel.Controls.Clear();
            WeeklyForm weeklyFrm = new WeeklyForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; //replacing form
            weeklyFrm.FormBorderStyle = FormBorderStyle.None;
            this.mainPanel.Controls.Add(weeklyFrm);
            weeklyFrm.Show();
            this.childForm = weeklyFrm;
        }

        /// <summary>
        /// Adding new student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            this.headPanel.BackColor = Color.FromArgb(79, 126, 161);
            this.descriptionLbl.ForeColor = Color.FromArgb(165, 186, 201);
            this.addStudentBtn.BackColor = Color.FromArgb(46, 51, 73);
            this.changeBtnsColor(addStudentBtn);
            this.descriptionLbl.Text = "Add Student";
            this.mainPanel.Controls.Clear();
            AddForm addFrm = new AddForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; //replacing form
            addFrm.FormBorderStyle = FormBorderStyle.None;
            this.mainPanel.Controls.Add(addFrm);
            addFrm.Show();
            this.childForm = addFrm;
        }

        /// <summary>
        /// Removing student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeStudentBtn_Click(object sender, EventArgs e)
        {
            this.headPanel.BackColor = Color.FromArgb(79, 126, 161);
            this.descriptionLbl.ForeColor = Color.FromArgb(165, 186, 201);
            this.removeStudentBtn.BackColor = Color.FromArgb(46, 51, 73);
            this.changeBtnsColor(removeStudentBtn);
            this.descriptionLbl.Text = "Remove Student";
            this.mainPanel.Controls.Clear();
            RemoveForm rmvFrm = new RemoveForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; //replacing form
            rmvFrm.FormBorderStyle = FormBorderStyle.None;
            this.mainPanel.Controls.Add(rmvFrm);
            rmvFrm.Show();
            this.childForm = rmvFrm;
        }

        /// <summary>
        /// Viewing instructors all lessones and availabilities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void instructorsBtn_Click(object sender, EventArgs e)
        {
            this.headPanel.BackColor = Color.FromArgb(79, 126, 161);
            this.descriptionLbl.ForeColor = Color.FromArgb(165, 186, 201);
            this.instructorsBtn.BackColor = Color.FromArgb(46, 51, 73);
            this.changeBtnsColor(this.instructorsBtn);
            this.descriptionLbl.Text = "Instructors Information";
            this.mainPanel.Controls.Clear();
            InstructorsAndLessonsForm instructorsAndLessonsForm = new InstructorsAndLessonsForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; //replacing form
            instructorsAndLessonsForm.FormBorderStyle = FormBorderStyle.None;
            this.mainPanel.Controls.Add(instructorsAndLessonsForm);
            instructorsAndLessonsForm.Show();
            this.childForm = instructorsAndLessonsForm;
        }

        /// <summary>
        /// Logging out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.buttonPanel.Visible = false;
            this.personalDeatPanel.Visible = false;
            this.bgImageBox.Visible = false;
            this.changeBtnsColor(logoutBtn);
            descriptionLbl.Text = "Login";
            this.mainPanel.Controls.Clear();
            LoginForm loginFrm = new LoginForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = false }; //replacing form
            loginFrm.FormBorderStyle = FormBorderStyle.None;
            this.mainPanel.Controls.Add(loginFrm);
            loginFrm.Show();
            this.childForm = loginFrm;
            this.headPanel.BackColor = Color.FromArgb(79, 126, 161);
            this.menuPanel.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void changeBtnsColor(Button btn)
        {
            foreach(Control control in this.buttonPanel.Controls)
            {
                if (control is Button && !control.Equals(btn))
                    control.BackColor = Color.FromArgb(24, 30, 54);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.logoutBtn_Click(sender, e);
        }
        /// <summary>
        /// Closing form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        /********************************Getters And Setters**********************************/
        public Panel MainPanel { get { return this.mainPanel; } set { this.mainPanel = value; } }

        public Panel HeadPanel { get { return this.headPanel; } set { this.headPanel = value; } }

        public Label DescriptionLabel { get { return this.descriptionLbl; } set { this.descriptionLbl = value; } }

        public Label UserNameLabel { get { return this.userNameLbl; } set { this.userNameLbl = value; } }

        public Panel ButtonPanel { get { return this.buttonPanel; } set { this.buttonPanel = value; } }

        public Panel UserPanel { get { return this.personalDeatPanel; } set { this.personalDeatPanel = value; } }

        public PictureBox BgPictureBox { get { return this.bgImageBox; } set { this.bgImageBox = value; } }

        public Panel MenuPanel { get{return this.menuPanel;} set { this.mainPanel = value; } }

        public void ViewAddViewListener(IView listener)
        {
            this.viewListener = listener;
        }
        /**********************************************UI Interface implementation*************************/
        public void ViewAddStudent(Student student, Lesson lesson)
        {
            this.viewListener.ViewAddStudent(student, lesson);
        }

        public void ViewRemoveStudent(Student student)
        {
            this.viewListener.ViewRemoveStudent(student);
        }

        public ArrayList ViewGetAllInstructors()
        {
            return this.viewListener.ViewGetAllInstructors();
        }

        public Dictionary<string, ArrayList> ViewGetAllLessonsByDays()
        {
            return this.viewListener.ViewGetAllLessonsByDays();
        }

        public Instructor ViewGetInstructor(string firstName, string surname, string password)
        {
            return this.viewListener.ViewGetInstructor(firstName, surname, password);
        }

        public IView ViewListener { get { return viewListener; } set { viewListener = value; } }


    }
}
