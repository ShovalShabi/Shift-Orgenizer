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

namespace Shift_Orgenizer.UI
{
    /// <summary>
    /// System messege window
    /// </summary>
    public partial class SystemMessege : Form
    {
        public SystemMessege(string msg)
        {
            InitializeComponent();
            this.msgLbl.Text = msg;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Label MsgLbl { get { return this.msgLbl; } set { this.msgLbl=value; } }

    }
}
