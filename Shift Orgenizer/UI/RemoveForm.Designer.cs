namespace Shift_Orgenizer
{
    partial class RemoveForm
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
            this.removeBtn = new System.Windows.Forms.Button();
            this.surnameTxtBox = new System.Windows.Forms.TextBox();
            this.firstNameTxtBox = new System.Windows.Forms.TextBox();
            this.surnameLbl = new System.Windows.Forms.Label();
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.SerialNumTxtBox = new System.Windows.Forms.TextBox();
            this.serialNumLbl = new System.Windows.Forms.Label();
            this.msgPanel = new System.Windows.Forms.Panel();
            this.msgLbl = new System.Windows.Forms.Label();
            this.msgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.removeBtn.FlatAppearance.BorderSize = 0;
            this.removeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.removeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBtn.ForeColor = System.Drawing.Color.Silver;
            this.removeBtn.Location = new System.Drawing.Point(912, 486);
            this.removeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(118, 39);
            this.removeBtn.TabIndex = 25;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // surnameTxtBox
            // 
            this.surnameTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.surnameTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameTxtBox.ForeColor = System.Drawing.Color.Silver;
            this.surnameTxtBox.Location = new System.Drawing.Point(969, 359);
            this.surnameTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.surnameTxtBox.Name = "surnameTxtBox";
            this.surnameTxtBox.Size = new System.Drawing.Size(170, 34);
            this.surnameTxtBox.TabIndex = 18;
            this.surnameTxtBox.TextChanged += new System.EventHandler(this.surnameTxtBox_TextChanged);
            // 
            // firstNameTxtBox
            // 
            this.firstNameTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.firstNameTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTxtBox.ForeColor = System.Drawing.Color.Silver;
            this.firstNameTxtBox.Location = new System.Drawing.Point(969, 305);
            this.firstNameTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameTxtBox.Name = "firstNameTxtBox";
            this.firstNameTxtBox.Size = new System.Drawing.Size(170, 34);
            this.firstNameTxtBox.TabIndex = 17;
            this.firstNameTxtBox.TextChanged += new System.EventHandler(this.firstNameTxtBox_TextChanged);
            // 
            // surnameLbl
            // 
            this.surnameLbl.AutoSize = true;
            this.surnameLbl.BackColor = System.Drawing.Color.Transparent;
            this.surnameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameLbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.surnameLbl.Location = new System.Drawing.Point(756, 364);
            this.surnameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.surnameLbl.Name = "surnameLbl";
            this.surnameLbl.Size = new System.Drawing.Size(124, 29);
            this.surnameLbl.TabIndex = 14;
            this.surnameLbl.Text = "Surname:";
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.firstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.firstNameLbl.Location = new System.Drawing.Point(756, 305);
            this.firstNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(143, 29);
            this.firstNameLbl.TabIndex = 13;
            this.firstNameLbl.Text = "First name:";
            // 
            // SerialNumTxtBox
            // 
            this.SerialNumTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.SerialNumTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialNumTxtBox.ForeColor = System.Drawing.Color.Silver;
            this.SerialNumTxtBox.Location = new System.Drawing.Point(969, 413);
            this.SerialNumTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.SerialNumTxtBox.Name = "SerialNumTxtBox";
            this.SerialNumTxtBox.Size = new System.Drawing.Size(170, 34);
            this.SerialNumTxtBox.TabIndex = 27;
            this.SerialNumTxtBox.TextChanged += new System.EventHandler(this.SerialNumTxtBox_TextChanged);
            // 
            // serialNumLbl
            // 
            this.serialNumLbl.AutoSize = true;
            this.serialNumLbl.BackColor = System.Drawing.Color.Transparent;
            this.serialNumLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumLbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.serialNumLbl.Location = new System.Drawing.Point(756, 418);
            this.serialNumLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serialNumLbl.Name = "serialNumLbl";
            this.serialNumLbl.Size = new System.Drawing.Size(189, 29);
            this.serialNumLbl.TabIndex = 26;
            this.serialNumLbl.Text = "Serial Number:";
            // 
            // msgPanel
            // 
            this.msgPanel.Controls.Add(this.msgLbl);
            this.msgPanel.Location = new System.Drawing.Point(652, 572);
            this.msgPanel.Name = "msgPanel";
            this.msgPanel.Size = new System.Drawing.Size(719, 112);
            this.msgPanel.TabIndex = 32;
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
            // RemoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1591, 725);
            this.Controls.Add(this.msgPanel);
            this.Controls.Add(this.SerialNumTxtBox);
            this.Controls.Add(this.serialNumLbl);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.surnameTxtBox);
            this.Controls.Add(this.firstNameTxtBox);
            this.Controls.Add(this.surnameLbl);
            this.Controls.Add(this.firstNameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoveForm";
            this.Text = "removeForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.removeForm_MouseDown);
            this.msgPanel.ResumeLayout(false);
            this.msgPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.TextBox surnameTxtBox;
        private System.Windows.Forms.TextBox firstNameTxtBox;
        private System.Windows.Forms.Label surnameLbl;
        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.TextBox SerialNumTxtBox;
        private System.Windows.Forms.Label serialNumLbl;
        private System.Windows.Forms.Panel msgPanel;
        private System.Windows.Forms.Label msgLbl;
    }
}
