namespace Bai6
{
    partial class Bai6_Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBoxToken = new System.Windows.Forms.GroupBox();
            this.rtbTokenInfo = new System.Windows.Forms.RichTextBox();
            this.groupBoxUserInfo = new System.Windows.Forms.GroupBox();
            this.rtbUserInfo = new System.Windows.Forms.RichTextBox();
            this.btnGetUserInfo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBoxLogin.SuspendLayout();
            this.groupBoxToken.SuspendLayout();
            this.groupBoxUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.txtPassword);
            this.groupBoxLogin.Controls.Add(this.txtUsername);
            this.groupBoxLogin.Controls.Add(this.lblPassword);
            this.groupBoxLogin.Controls.Add(this.lblUsername);
            this.groupBoxLogin.Controls.Add(this.btnLogin);
            this.groupBoxLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxLogin.Location = new System.Drawing.Point(12, 60);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(300, 180);
            this.groupBoxLogin.TabIndex = 0;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Đăng nhập";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(20, 95);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(260, 25);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(20, 45);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(260, 25);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 75);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(20, 25);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(20, 135);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(260, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(515, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "BÀI 6: HTTP GET - Hiển thị thông tin người dùng";
            // 
            // groupBoxToken
            // 
            this.groupBoxToken.Controls.Add(this.rtbTokenInfo);
            this.groupBoxToken.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxToken.Location = new System.Drawing.Point(330, 60);
            this.groupBoxToken.Name = "groupBoxToken";
            this.groupBoxToken.Size = new System.Drawing.Size(540, 180);
            this.groupBoxToken.TabIndex = 2;
            this.groupBoxToken.TabStop = false;
            this.groupBoxToken.Text = "Thông tin Token";
            // 
            // rtbTokenInfo
            // 
            this.rtbTokenInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.rtbTokenInfo.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbTokenInfo.Location = new System.Drawing.Point(10, 20);
            this.rtbTokenInfo.Name = "rtbTokenInfo";
            this.rtbTokenInfo.ReadOnly = true;
            this.rtbTokenInfo.Size = new System.Drawing.Size(520, 150);
            this.rtbTokenInfo.TabIndex = 0;
            this.rtbTokenInfo.Text = "";
            // 
            // groupBoxUserInfo
            // 
            this.groupBoxUserInfo.Controls.Add(this.rtbUserInfo);
            this.groupBoxUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxUserInfo.Location = new System.Drawing.Point(12, 260);
            this.groupBoxUserInfo.Name = "groupBoxUserInfo";
            this.groupBoxUserInfo.Size = new System.Drawing.Size(858, 290);
            this.groupBoxUserInfo.TabIndex = 3;
            this.groupBoxUserInfo.TabStop = false;
            this.groupBoxUserInfo.Text = "Thông tin người dùng";
            // 
            // rtbUserInfo
            // 
            this.rtbUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.rtbUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rtbUserInfo.Location = new System.Drawing.Point(10, 20);
            this.rtbUserInfo.Name = "rtbUserInfo";
            this.rtbUserInfo.ReadOnly = true;
            this.rtbUserInfo.Size = new System.Drawing.Size(838, 260);
            this.rtbUserInfo.TabIndex = 0;
            this.rtbUserInfo.Text = "";
            // 
            // btnGetUserInfo
            // 
            this.btnGetUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGetUserInfo.Enabled = false;
            this.btnGetUserInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGetUserInfo.ForeColor = System.Drawing.Color.White;
            this.btnGetUserInfo.Location = new System.Drawing.Point(12, 565);
            this.btnGetUserInfo.Name = "btnGetUserInfo";
            this.btnGetUserInfo.Size = new System.Drawing.Size(200, 40);
            this.btnGetUserInfo.TabIndex = 4;
            this.btnGetUserInfo.Text = "LẤY THÔNG TIN USER";
            this.btnGetUserInfo.UseVisualStyleBackColor = false;
            this.btnGetUserInfo.Click += new System.EventHandler(this.btnGetUserInfo_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(670, 565);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(200, 40);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "XÓA THÔNG TIN";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(230, 575);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(420, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bai6Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 621);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGetUserInfo);
            this.Controls.Add(this.groupBoxUserInfo);
            this.Controls.Add(this.groupBoxToken);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBoxLogin);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bai6Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 6 - HTTP GET User Info";
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.groupBoxToken.ResumeLayout(false);
            this.groupBoxUserInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxToken;
        private System.Windows.Forms.RichTextBox rtbTokenInfo;
        private System.Windows.Forms.GroupBox groupBoxUserInfo;
        private System.Windows.Forms.RichTextBox rtbUserInfo;
        private System.Windows.Forms.Button btnGetUserInfo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}