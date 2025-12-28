using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Bai5
{
    partial class Bai5_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            url = new Label();
            username = new Label();
            password = new Label();
            txt_pass = new TextBox();
            txt_username = new TextBox();
            txt_url = new TextBox();
            txt_response = new RichTextBox();
            btnPost = new Button();
            SuspendLayout();
            // 
            // url
            // 
            url.AutoSize = true;
            url.Location = new Point(35, 65);
            url.Name = "url";
            url.Size = new Size(47, 25);
            url.TabIndex = 0;
            url.Text = "URL:";
            // 
            // username
            // 
            username.AutoSize = true;
            username.Location = new Point(35, 141);
            username.Name = "username";
            username.Size = new Size(91, 25);
            username.TabIndex = 1;
            username.Text = "Username:";
            // 
            // password
            // 
            password.AutoSize = true;
            password.Location = new Point(35, 228);
            password.Name = "password";
            password.Size = new Size(91, 25);
            password.TabIndex = 2;
            password.Text = "Password:";
            // 
            // txt_pass
            // 
            txt_pass.Location = new Point(163, 222);
            txt_pass.Name = "txt_pass";
            txt_pass.PasswordChar = '●';
            txt_pass.Size = new Size(532, 31);
            txt_pass.TabIndex = 3;
            // 
            // txt_username
            // 
            txt_username.Location = new Point(163, 135);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(532, 31);
            txt_username.TabIndex = 4;
            // 
            // txt_url
            // 
            txt_url.Location = new Point(163, 59);
            txt_url.Name = "txt_url";
            txt_url.Size = new Size(532, 31);
            txt_url.TabIndex = 5;
            // 
            // txt_response
            // 
            txt_response.Location = new Point(35, 282);
            txt_response.Name = "txt_response";
            txt_response.ReadOnly = true;
            txt_response.Size = new Size(630, 156);
            txt_response.TabIndex = 6;
            txt_response.Text = "";
            // 
            // btnPost
            // 
            btnPost.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnPost.FlatStyle = FlatStyle.Flat;
            btnPost.ForeColor = System.Drawing.Color.White;
            btnPost.Location = new Point(676, 282);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(112, 156);
            btnPost.TabIndex = 7;
            btnPost.Text = "LOGIN";
            btnPost.UseVisualStyleBackColor = false;
            btnPost.Click += btnPost_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPost);
            Controls.Add(txt_response);
            Controls.Add(txt_url);
            Controls.Add(txt_username);
            Controls.Add(txt_pass);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(url);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 5 - HTTP POST Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label url;
        private Label username;
        private Label password;
        private TextBox txt_pass;
        private TextBox txt_username;
        private TextBox txt_url;
        private RichTextBox txt_response;
        private Button btnPost;
    }
}