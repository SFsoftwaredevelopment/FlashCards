using System.Drawing;
namespace WindowsFormsApplication1
{
    partial class Login2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login2));
            this.usernameP = new System.Windows.Forms.Panel();
            this.usernameL = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.passwordP = new System.Windows.Forms.Panel();
            this.passwordL = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.loginP = new System.Windows.Forms.Panel();
            this.ExitP = new System.Windows.Forms.Panel();
            this.usernameP.SuspendLayout();
            this.passwordP.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameP
            // 
            this.usernameP.BackColor = System.Drawing.Color.Transparent;
            this.usernameP.Controls.Add(this.usernameL);
            this.usernameP.Controls.Add(this.linkLabel1);
            this.usernameP.Location = new System.Drawing.Point(130, 278);
            this.usernameP.Name = "usernameP";
            this.usernameP.Size = new System.Drawing.Size(748, 107);
            this.usernameP.TabIndex = 5;
            // 
            // usernameL
            // 
            this.usernameL.AutoSize = true;
            this.usernameL.Location = new System.Drawing.Point(35, 92);
            this.usernameL.Name = "usernameL";
            this.usernameL.Size = new System.Drawing.Size(55, 13);
            this.usernameL.TabIndex = 2;
            this.usernameL.Text = "Username";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(683, 92);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(34, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Erase";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // passwordP
            // 
            this.passwordP.BackColor = System.Drawing.Color.Transparent;
            this.passwordP.Controls.Add(this.passwordL);
            this.passwordP.Controls.Add(this.linkLabel2);
            this.passwordP.Location = new System.Drawing.Point(130, 435);
            this.passwordP.Name = "passwordP";
            this.passwordP.Size = new System.Drawing.Size(748, 107);
            this.passwordP.TabIndex = 6;
            // 
            // passwordL
            // 
            this.passwordL.AutoSize = true;
            this.passwordL.Location = new System.Drawing.Point(35, 92);
            this.passwordL.Name = "passwordL";
            this.passwordL.Size = new System.Drawing.Size(53, 13);
            this.passwordL.TabIndex = 2;
            this.passwordL.Text = "Password";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(683, 92);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(34, 13);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Erase";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 5000;
            this.toolTip1.ReshowDelay = 100;
            // 
            // loginP
            // 
            this.loginP.BackColor = System.Drawing.Color.Transparent;
            this.loginP.Location = new System.Drawing.Point(181, 566);
            this.loginP.Name = "loginP";
            this.loginP.Size = new System.Drawing.Size(234, 113);
            this.loginP.TabIndex = 7;
            // 
            // ExitP
            // 
            this.ExitP.BackColor = System.Drawing.Color.Transparent;
            this.ExitP.Location = new System.Drawing.Point(592, 566);
            this.ExitP.Name = "ExitP";
            this.ExitP.Size = new System.Drawing.Size(231, 113);
            this.ExitP.TabIndex = 9;
            this.ExitP.Click += new System.EventHandler(this.exitB_Click);
            // 
            // Login2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.ExitP);
            this.Controls.Add(this.loginP);
            this.Controls.Add(this.passwordP);
            this.Controls.Add(this.usernameP);
            this.Name = "Login2";
            this.Size = new System.Drawing.Size(1000, 700);
            //this.Load += new System.EventHandler(this.Login2_Load);
            this.usernameP.ResumeLayout(false);
            this.usernameP.PerformLayout();
            this.passwordP.ResumeLayout(false);
            this.passwordP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //public System.Windows.Forms.TextBox usernameTB;
        //public System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Panel usernameP;
        private System.Windows.Forms.Panel passwordP;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label usernameL;
        private System.Windows.Forms.Label passwordL;
        private System.Windows.Forms.Panel loginP;
        private System.Windows.Forms.Panel ExitP;
    }
}