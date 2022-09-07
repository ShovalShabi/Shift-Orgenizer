using Asgard_Shift_Orgenizer.Classes;
using Asgard_Shift_Orgenizer.Exceptions;
using Asgard_Shift_Orgenizer.UI;
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
using Day = Asgard_Shift_Orgenizer.Classes.Day;

//presenter:Shoval Shabi

namespace Asgard_Shift_Orgenizer
{

    /// <summary>
    /// /A Form object
    /// </summary>
    public partial class WeeklyForm : Form
    {
        /// <summary>
        /// My type for location of a cell on grid for better performence
        /// </summary>
        new internal class Location
        {
            private int rowI;
            private int colJ;

            public Location(int rowIndex, int colIndex)
            {
                this.rowI = rowIndex;
                this.colJ = colIndex;
            }
            public int RowI { get { return this.rowI; } set { this.rowI = value; } }

            public int ColJ { get { return this.colJ; } set { this.colJ = value; } }

            public override int GetHashCode()
            {
                return this.rowI.GetHashCode() ^ this.colJ.GetHashCode();
            }


            public override bool Equals(object obj)
            {
                if (obj is Location)
                {
                    Location temp = (Location)obj;
                    if (this.rowI == temp.RowI && this.colJ == temp.ColJ)
                        return true;
                }
                return false;
            }
        }

        private MainForm parentForm;
        private Dictionary<string, int> daysIndexes; //Storing days strings as keys and their index columns as values 
        private ArrayList allHours;  //List of Time objects for hour ranges
        private Dictionary<string, ArrayList> lessonsByDays;  //Storing days strings as keys and lists of the lessons by each day as values
        private Dictionary<Location, ArrayList> comboLessones;  //Storing cells locations as keys ,and list of lessons as by storing order within the the comboBox
        private int countSelectedCells;
        private Lesson selectedLesson;

        public WeeklyForm(MainForm parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.daysIndexes = new Dictionary<string, int>();
            this.allHours = new ArrayList();
            this.comboLessones = new Dictionary<Location, ArrayList>();
            this.countSelectedCells = 0;
            this.selectedLesson = null;
            this.createTable();
        }

        /// <summary>
        /// Designed for page movement on the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeeklyForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.parentForm.mainPanel_MouseDown(sender, e);
        }

        /// <summary>
        /// This method creates the table by current day to week ahead by relvent opening hours and booked lessons
        /// </summary>
        private void createTable()
        {
            DateTime thisTime = DateTime.Now;
            string currentDay = thisTime.DayOfWeek.ToString();//Getting value of Enum "DayOfWeek" that represnt the current day string
            int indexDay =(int) Enum.Parse(typeof(Day), currentDay, true);//Parsing index of Enum "Day" that represnt the string
            int countDays = 0;
            string[] daysOfWeek = Enum.GetNames(typeof(Day)); // Orgenized array of the strings by the number of days in the week
            while (countDays < (int)Day.Week)
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                col.HeaderText = daysOfWeek[indexDay];
                col.FlatStyle = FlatStyle.Flat;
                col.Width = 120;
                this.dataGridView.Columns.Add(col);
                this.daysIndexes.Add(daysOfWeek[indexDay], countDays);//Orgenaizing the string of the days by their column indexes
                countDays++;
                indexDay++;
                if (indexDay == (int)Day.Week)
                    indexDay = 0;
            }
            Time time = new Time(8, 0); //This will start from the earliest hour of the week
            Time maxHour = new Time(21, 0); //This will be the latest hour of the week 
            int from = time.Hours;
            for (int i = from; i < maxHour.Hours; i++)
            {
                this.allHours.Add(new Time(time.Hours, time.Minutes));
                this.dataGridView.Rows.Add();
                this.dataGridView.Rows[i - from].HeaderCell.Value = time.ToString();
                time.Hours += 1;
            }
            this.lessonsByDays = this.parentForm.ViewGetAllLessonsByDays();
            foreach(string day in this.daysIndexes.Keys)
            {
                int colIndex = this.daysIndexes[day];
                if(this.lessonsByDays.ContainsKey(day))
                {
                    foreach (Lesson lesson in this.lessonsByDays[day])
                    {
                        int rowIndex = this.allHours.IndexOf(new Time(lesson.Availability.MinTime.Hours, 0));
                        DataGridViewComboBoxCell cell =(DataGridViewComboBoxCell) this.dataGridView.Rows[rowIndex].Cells[colIndex];
                        Location location = new Location(cell.RowIndex, cell.ColumnIndex);  //Cell's location
                        if (!this.comboLessones.ContainsKey(new Location(cell.RowIndex, cell.ColumnIndex)))
                            this.comboLessones.Add(location, new ArrayList()); //Creating Cell's ArrayListB
                        comboLessones[location].Add(lesson);//Adding information to dictionay for easy acceses for user selection
                        cell.Items.Add((cell.Items.Count+1)+"."+lesson.Instructor.ToString());
                        cell.Style.BackColor = Color.FromArgb(113, 42, 245);

                    }
                }
               
            }
            if(this.comboLessones.Count==0)
            {
                this.colorExmpLbl.Visible = false;
                this.instructionLbl.Text = "There are no booked lessons";
            }

        }

        /// <summary>
        /// Event that happens on every form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeeklyForm_Load(object sender, EventArgs e)
        {
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 30, 54);
            this.dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 30, 54);
            this.dataGridView.RowTemplate.Height = 300;
        }

        /// <summary>
        /// This event handler manually raises the CellValueChanged event by calling the CommitEdit method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                this.dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// This event designed for item selection within combo box cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView.CurrentCell;
            if (cell != null) this.dataGridView.EndEdit();
            if (cell != null && cell.Value != null)
            {
                this.dataGridView.CancelEdit();
                this.selectedLesson =(Lesson)this.comboLessones[new Location(cell.RowIndex,cell.ColumnIndex)][cell.Items.IndexOf(cell.Value)];  // Accessing the dictionary of Locations that holds lessons by comboBox indexing
                this.countSelectedCells++;
                this.clearBtn.Visible = true;
                this.dataGridView.Invalidate();
            }
        }

        /// <summary>
        /// Clearing lesson selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.allHours.Count; i++)
            {
                for (int j = 0; j < (int)Day.Week; j++)
                {
                    this.dataGridView.Rows[i].Cells[j].Value = null;
                }
            }
            this.countSelectedCells = 0;
            this.clearBtn.Visible = false;
        }

        /// <summary>
        /// Switching form for lesson's deatils and instrucort information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboLessones.Count == 0)
                    throw new NoLessonsException("There are no lessons yet, try again when there is");
                if (this.countSelectedCells == 0)
                    throw new LessonSelectionException("Please select any lesson to see it's details");
                else if (this.countSelectedCells != 1)
                    throw new LessonSelectionException("Please select only one lesson to see it's details!");
                this.parentForm.DescriptionLabel.Text = "Lesson Details";
                this.parentForm.MainPanel.Controls.Clear();
                InstructorsAndLessonsForm lessonDetailsFrm = new InstructorsAndLessonsForm(this.parentForm,this.selectedLesson.Instructor,this.selectedLesson) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; //replacing form
                lessonDetailsFrm.FormBorderStyle = FormBorderStyle.None;
                this.parentForm.MainPanel.Controls.Add(lessonDetailsFrm);
                lessonDetailsFrm.Show();
            }
            catch (Exception ex) when(ex is LessonSelectionException ||
            ex is NoLessonsException)
            {
                SystemMessege sysMsg = new SystemMessege(ex.Message);
                Console.WriteLine(ex);
                sysMsg.Show();

            }
        }


    }
}
