using Shift_Orgenizer.Classes;
using Shift_Orgenizer.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//presenter:Shoval Shabi

namespace Shift_Orgenizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SwimmingClub swimmingClub = SwimmingClub.Instance;
            swimmingClub.LoadData();
            MainForm mainForm = new MainForm();
            Controller controller = new Controller(swimmingClub, mainForm);
            Application.Run(mainForm);
            DatabaseConnector dbConnector = DatabaseConnector.Instance;
            dbConnector.DisconnectFromDatabase();
        }
    }
}
;
