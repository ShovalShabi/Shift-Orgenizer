namespace Asgard_Shift_Orgenizer
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.userNameLbl = new System.Windows.Forms.Label();
            this.usrTxtBox = new System.Windows.Forms.TextBox();
            this.passLbl = new System.Windows.Forms.Label();
            this.passTxtBox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.msgPanel = new System.Windows.Forms.Panel();
            this.msgLbl = new System.Windows.Forms.Label();
            this.msgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.Location = new System.Drawing.Point(692, 379);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(146, 29);
            this.userNameLbl.TabIndex = 0;
            this.userNameLbl.Text = "User name:";
            // 
            // usrTxtBox
            // 
            this.usrTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.usrTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrTxtBox.ForeColor = System.Drawing.Color.Silver;
            this.usrTxtBox.Location = new System.Drawing.Point(854, 378);
            this.usrTxtBox.Name = "usrTxtBox";
            this.usrTxtBox.Size = new System.Drawing.Size(158, 30);
            this.usrTxtBox.TabIndex = 1;
            this.usrTxtBox.TextChanged += new System.EventHandler(this.usrTxtBox_TextChanged);
            // 
            // passLbl
            // 
            this.passLbl.AutoSize = true;
            this.passLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLbl.Location = new System.Drawing.Point(692, 454);
            this.passLbl.Name = "passLbl";
            this.passLbl.Size = new System.Drawing.Size(135, 29);
            this.passLbl.TabIndex = 2;
            this.passLbl.Text = "Password:";
            // 
            // passTxtBox
            // 
            this.passTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.passTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTxtBox.ForeColor = System.Drawing.Color.Silver;
            this.passTxtBox.Location = new System.Drawing.Point(854, 453);
            this.passTxtBox.Name = "passTxtBox";
            this.passTxtBox.Size = new System.Drawing.Size(158, 30);
            this.passTxtBox.TabIndex = 3;
            this.passTxtBox.UseSystemPasswordChar = true;
            this.passTxtBox.TextChanged += new System.EventHandler(this.passTxtBox_TextChanged);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.Transparent;
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Image = ((System.Drawing.Image)(resources.GetObject("loginBtn.Image")));
            this.loginBtn.Location = new System.Drawing.Point(793, 542);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(97, 98);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // msgPanel
            // 
            this.msgPanel.Controls.Add(this.msgLbl);
            this.msgPanel.Location = new System.Drawing.Point(632, 701);
            this.msgPanel.Name = "msgPanel";
            this.msgPanel.Size = new System.Drawing.Size(656, 112);
            this.msgPanel.TabIndex = 31;
            // 
            // msgLbl
            // 
            this.msgLbl.AutoSize = true;
            this.msgLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(232)))), ((int)(((byte)(164)))));
            this.msgLbl.Location = new System.Drawing.Point(0, 0);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(52, 25);
            this.msgLbl.TabIndex = 29;
            this.msgLbl.Text = "msg";
            this.msgLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.msgLbl.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1689, 825);
            this.Controls.Add(this.msgPanel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passTxtBox);
            this.Controls.Add(this.passLbl);
            this.Controls.Add(this.usrTxtBox);
            this.Controls.Add(this.userNameLbl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "loginFormcs";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.msgPanel.ResumeLayout(false);
            this.msgPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.TextBox usrTxtBox;
        private System.Windows.Forms.Label passLbl;
        private System.Windows.Forms.TextBox passTxtBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Panel msgPanel;
        private System.Windows.Forms.Label msgLbl;
    }
}