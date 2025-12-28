namespace Lab4_Bai2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            txtUrl = new TextBox();
            txtPath = new TextBox();
            btnDownload = new Button();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(12, 12);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(550, 27);
            txtUrl.TabIndex = 3;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(12, 40);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(550, 27);
            txtPath.TabIndex = 2;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(580, 12);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(120, 50);
            btnDownload.TabIndex = 1;
            btnDownload.Text = "Download";
            btnDownload.Click += btnDownload_Click;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(12, 80);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(688, 350);
            rtbContent.TabIndex = 0;
            rtbContent.Text = "";
            // 
            // Form1
            // 
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(712, 450);
            Controls.Add(rtbContent);
            Controls.Add(btnDownload);
            Controls.Add(txtPath);
            Controls.Add(txtUrl);
            Name = "Form1";
            Text = "Bài 2: Download File";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.RichTextBox rtbContent;
    }
}