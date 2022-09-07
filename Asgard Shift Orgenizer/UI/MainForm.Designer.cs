namespace Asgard_Shift_Orgenizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.instructorsBtn = new System.Windows.Forms.Button();
            this.removeStudentBtn = new System.Windows.Forms.Button();
            this.addStudentBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.weeklyShiftsBtn = new System.Windows.Forms.Button();
            this.userDetailsPnl = new System.Windows.Forms.Panel();
            this.personalDeatPanel = new System.Windows.Forms.Panel();
            this.userIconPB = new System.Windows.Forms.PictureBox();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.logoPicBox = new System.Windows.Forms.PictureBox();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.headPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bgImageBox = new System.Windows.Forms.PictureBox();
            this.menuPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.userDetailsPnl.SuspendLayout();
            this.personalDeatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIconPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).BeginInit();
            this.headPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuPanel.Controls.Add(this.buttonPanel);
            this.menuPanel.Controls.Add(this.userDetailsPnl);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(292, 831);
            this.menuPanel.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPanel.Controls.Add(this.instructorsBtn);
            this.buttonPanel.Controls.Add(this.removeStudentBtn);
            this.buttonPanel.Controls.Add(this.addStudentBtn);
            this.buttonPanel.Controls.Add(this.logoutBtn);
            this.buttonPanel.Controls.Add(this.weeklyShiftsBtn);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 200);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(292, 631);
            this.buttonPanel.TabIndex = 5;
            this.buttonPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPanel_MouseDown);
            // 
            // instructorsBtn
            // 
            this.instructorsBtn.BackColor = System.Drawing.Color.Transparent;
            this.instructorsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.instructorsBtn.FlatAppearance.BorderSize = 0;
            this.instructorsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.instructorsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instructorsBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructorsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.instructorsBtn.Image = ((System.Drawing.Image)(resources.GetObject("instructorsBtn.Image")));
            this.instructorsBtn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.instructorsBtn.Location = new System.Drawing.Point(0, 277);
            this.instructorsBtn.Name = "instructorsBtn";
            this.instructorsBtn.Size = new System.Drawing.Size(292, 93);
            this.instructorsBtn.TabIndex = 5;
            this.instructorsBtn.Text = "All Instructors";
            this.instructorsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.instructorsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.instructorsBtn.UseVisualStyleBackColor = false;
            this.instructorsBtn.Click += new System.EventHandler(this.instructorsBtn_Click);
            // 
            // removeStudentBtn
            // 
            this.removeStudentBtn.BackColor = System.Drawing.Color.Transparent;
            this.removeStudentBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.removeStudentBtn.FlatAppearance.BorderSize = 0;
            this.removeStudentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.removeStudentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeStudentBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeStudentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.removeStudentBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeStudentBtn.Image")));
            this.removeStudentBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.removeStudentBtn.Location = new System.Drawing.Point(0, 193);
            this.removeStudentBtn.Name = "removeStudentBtn";
            this.removeStudentBtn.Size = new System.Drawing.Size(292, 84);
            this.removeStudentBtn.TabIndex = 3;
            this.removeStudentBtn.Text = "Remove Student";
            this.removeStudentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeStudentBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.removeStudentBtn.UseVisualStyleBackColor = false;
            this.removeStudentBtn.Click += new System.EventHandler(this.removeStudentBtn_Click);
            // 
            // addStudentBtn
            // 
            this.addStudentBtn.BackColor = System.Drawing.Color.Transparent;
            this.addStudentBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.addStudentBtn.FlatAppearance.BorderSize = 0;
            this.addStudentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.addStudentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStudentBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.addStudentBtn.Image = ((System.Drawing.Image)(resources.GetObject("addStudentBtn.Image")));
            this.addStudentBtn.Location = new System.Drawing.Point(0, 97);
            this.addStudentBtn.Name = "addStudentBtn";
            this.addStudentBtn.Size = new System.Drawing.Size(292, 96);
            this.addStudentBtn.TabIndex = 2;
            this.addStudentBtn.Text = "Add Student  ";
            this.addStudentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addStudentBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addStudentBtn.UseVisualStyleBackColor = false;
            this.addStudentBtn.Click += new System.EventHandler(this.addStudentBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Transparent;
            this.logoutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.logoutBtn.Image = ((System.Drawing.Image)(resources.GetObject("logoutBtn.Image")));
            this.logoutBtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.logoutBtn.Location = new System.Drawing.Point(0, 537);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(292, 94);
            this.logoutBtn.TabIndex = 4;
            this.logoutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logoutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // weeklyShiftsBtn
            // 
            this.weeklyShiftsBtn.BackColor = System.Drawing.Color.Transparent;
            this.weeklyShiftsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.weeklyShiftsBtn.FlatAppearance.BorderSize = 0;
            this.weeklyShiftsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.weeklyShiftsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.weeklyShiftsBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weeklyShiftsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.weeklyShiftsBtn.Image = ((System.Drawing.Image)(resources.GetObject("weeklyShiftsBtn.Image")));
            this.weeklyShiftsBtn.Location = new System.Drawing.Point(0, 0);
            this.weeklyShiftsBtn.Name = "weeklyShiftsBtn";
            this.weeklyShiftsBtn.Size = new System.Drawing.Size(292, 97);
            this.weeklyShiftsBtn.TabIndex = 1;
            this.weeklyShiftsBtn.Text = "Weekly Shifts";
            this.weeklyShiftsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.weeklyShiftsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.weeklyShiftsBtn.UseVisualStyleBackColor = false;
            this.weeklyShiftsBtn.Click += new System.EventHandler(this.weeklyShiftsBtn_Click);
            // 
            // userDetailsPnl
            // 
            this.userDetailsPnl.Controls.Add(this.personalDeatPanel);
            this.userDetailsPnl.Controls.Add(this.logoPicBox);
            this.userDetailsPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.userDetailsPnl.Location = new System.Drawing.Point(0, 0);
            this.userDetailsPnl.Name = "userDetailsPnl";
            this.userDetailsPnl.Size = new System.Drawing.Size(292, 200);
            this.userDetailsPnl.TabIndex = 0;
            this.userDetailsPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.userDetailsPnl_MouseDown);
            // 
            // personalDeatPanel
            // 
            this.personalDeatPanel.BackColor = System.Drawing.Color.Transparent;
            this.personalDeatPanel.Controls.Add(this.userIconPB);
            this.personalDeatPanel.Controls.Add(this.userNameLbl);
            this.personalDeatPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.personalDeatPanel.Location = new System.Drawing.Point(0, 109);
            this.personalDeatPanel.Name = "personalDeatPanel";
            this.personalDeatPanel.Size = new System.Drawing.Size(292, 91);
            this.personalDeatPanel.TabIndex = 5;
            // 
            // userIconPB
            // 
            this.userIconPB.Image = ((System.Drawing.Image)(resources.GetObject("userIconPB.Image")));
            this.userIconPB.Location = new System.Drawing.Point(24, 37);
            this.userIconPB.Name = "userIconPB";
            this.userIconPB.Size = new System.Drawing.Size(39, 25);
            this.userIconPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userIconPB.TabIndex = 2;
            this.userIconPB.TabStop = false;
            this.userIconPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.userIconPB_MouseDown);
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.userNameLbl.Location = new System.Drawing.Point(58, 37);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(119, 25);
            this.userNameLbl.TabIndex = 1;
            this.userNameLbl.Text = "User Name";
            this.userNameLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.userNameLbl_MouseDown);
            // 
            // logoPicBox
            // 
            this.logoPicBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPicBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPicBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPicBox.Image")));
            this.logoPicBox.Location = new System.Drawing.Point(0, 0);
            this.logoPicBox.Name = "logoPicBox";
            this.logoPicBox.Size = new System.Drawing.Size(292, 111);
            this.logoPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPicBox.TabIndex = 0;
            this.logoPicBox.TabStop = false;
            this.logoPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.descriptionLbl.Location = new System.Drawing.Point(3, 15);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(208, 39);
            this.descriptionLbl.TabIndex = 1;
            this.descriptionLbl.Text = "Home Page";
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(1224, 15);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(25, 25);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.closeBtn_MouseClick);
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.headPanel.Controls.Add(this.descriptionLbl);
            this.headPanel.Controls.Add(this.closeBtn);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(292, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(1274, 111);
            this.headPanel.TabIndex = 4;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainPanel.Controls.Add(this.bgImageBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1566, 831);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            // 
            // bgImageBox
            // 
            this.bgImageBox.Image = ((System.Drawing.Image)(resources.GetObject("bgImageBox.Image")));
            this.bgImageBox.Location = new System.Drawing.Point(531, 159);
            this.bgImageBox.Name = "bgImageBox";
            this.bgImageBox.Size = new System.Drawing.Size(787, 621);
            this.bgImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bgImageBox.TabIndex = 1;
            this.bgImageBox.TabStop = false;
            this.bgImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bgImageBox_MouseDown);
            // 
            // MainForm
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1566, 831);
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shift Orgenizer";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.userDetailsPnl.ResumeLayout(false);
            this.personalDeatPanel.ResumeLayout(false);
            this.personalDeatPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIconPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).EndInit();
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bgImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel userDetailsPnl;
        private System.Windows.Forms.PictureBox logoPicBox;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Button weeklyShiftsBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button removeStudentBtn;
        private System.Windows.Forms.Button addStudentBtn;
        private System.Windows.Forms.PictureBox userIconPB;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel personalDeatPanel;
        private System.Windows.Forms.PictureBox bgImageBox;
        private System.Windows.Forms.Button instructorsBtn;
    }
}

