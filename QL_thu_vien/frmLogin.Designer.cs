
namespace QL_thu_vien
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.picError = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cTxtPasswd = new QL_thu_vien.customTextBox();
            this.cBtnLogin = new QL_thu_vien.customButton();
            this.cTxtUser = new QL_thu_vien.customTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 261);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picTitle
            // 
            this.picTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.picTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(0, 0);
            this.picTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(1277, 167);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitle.TabIndex = 2;
            this.picTitle.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft JhengHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.Black;
            this.lblLogin.Location = new System.Drawing.Point(156, 82);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(291, 48);
            this.lblLogin.TabIndex = 22;
            this.lblLogin.Text = "Member Login";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.picError);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 167);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 528);
            this.panel1.TabIndex = 26;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.SystemColors.Window;
            this.lblError.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(157, 127);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(49, 19);
            this.lblError.TabIndex = 29;
            this.lblError.Text = "Label";
            // 
            // picError
            // 
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.Location = new System.Drawing.Point(12, 46);
            this.picError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(515, 225);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picError.TabIndex = 28;
            this.picError.TabStop = false;
            this.picError.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.panel2.Controls.Add(this.cTxtPasswd);
            this.panel2.Controls.Add(this.cBtnLogin);
            this.panel2.Controls.Add(this.lblLogin);
            this.panel2.Controls.Add(this.cTxtUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(648, 167);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 528);
            this.panel2.TabIndex = 27;
            // 
            // cTxtPasswd
            // 
            this.cTxtPasswd.BackColor = System.Drawing.SystemColors.Window;
            this.cTxtPasswd.BorderColor = System.Drawing.Color.Red;
            this.cTxtPasswd.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cTxtPasswd.BorderRadius = 15;
            this.cTxtPasswd.BorderSize = 1;
            this.cTxtPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cTxtPasswd.ForeColor = System.Drawing.Color.DimGray;
            this.cTxtPasswd.Location = new System.Drawing.Point(125, 274);
            this.cTxtPasswd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cTxtPasswd.Multiline = false;
            this.cTxtPasswd.Name = "cTxtPasswd";
            this.cTxtPasswd.Padding = new System.Windows.Forms.Padding(7);
            this.cTxtPasswd.PasswordChar = true;
            this.cTxtPasswd.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.cTxtPasswd.PlaceholderText = "Password";
            this.cTxtPasswd.Size = new System.Drawing.Size(359, 44);
            this.cTxtPasswd.TabIndex = 25;
            this.cTxtPasswd.Texts = "";
            this.cTxtPasswd.UnderlinedStyle = false;
            // 
            // cBtnLogin
            // 
            this.cBtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cBtnLogin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cBtnLogin.BoderColor = System.Drawing.Color.PaleVioletRed;
            this.cBtnLogin.BoderRadius = 40;
            this.cBtnLogin.BoderSize = 0;
            this.cBtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cBtnLogin.FlatAppearance.BorderSize = 0;
            this.cBtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBtnLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBtnLogin.ForeColor = System.Drawing.Color.White;
            this.cBtnLogin.Location = new System.Drawing.Point(125, 377);
            this.cBtnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBtnLogin.Name = "cBtnLogin";
            this.cBtnLogin.Size = new System.Drawing.Size(359, 49);
            this.cBtnLogin.TabIndex = 23;
            this.cBtnLogin.Text = "Login";
            this.cBtnLogin.TextColor = System.Drawing.Color.White;
            this.cBtnLogin.UseVisualStyleBackColor = false;
            this.cBtnLogin.Click += new System.EventHandler(this.cBtnLogin_Click);
            // 
            // cTxtUser
            // 
            this.cTxtUser.BackColor = System.Drawing.SystemColors.Window;
            this.cTxtUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cTxtUser.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cTxtUser.BorderRadius = 15;
            this.cTxtUser.BorderSize = 1;
            this.cTxtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cTxtUser.ForeColor = System.Drawing.Color.DimGray;
            this.cTxtUser.Location = new System.Drawing.Point(125, 190);
            this.cTxtUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cTxtUser.Multiline = false;
            this.cTxtUser.Name = "cTxtUser";
            this.cTxtUser.Padding = new System.Windows.Forms.Padding(7);
            this.cTxtUser.PasswordChar = false;
            this.cTxtUser.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.cTxtUser.PlaceholderText = "User";
            this.cTxtUser.Size = new System.Drawing.Size(359, 44);
            this.cTxtUser.TabIndex = 24;
            this.cTxtUser.Texts = "";
            this.cTxtUser.UnderlinedStyle = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1277, 695);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private customTextBox cTxtPasswd;
        private customTextBox cTxtUser;
        private customButton cBtnLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Label lblError;
    }
}