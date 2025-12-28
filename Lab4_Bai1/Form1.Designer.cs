namespace Lab4_Bai1
{
    partial class Form1
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
            txtUrl = new TextBox();
            btnGet = new Button();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(12, 15);
            txtUrl.Margin = new Padding(3, 4, 3, 4);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(650, 27);
            txtUrl.TabIndex = 0;
            txtUrl.Text = "";
            // 
            // btnGet
            // 
            btnGet.Location = new Point(680, 12);
            btnGet.Margin = new Padding(3, 4, 3, 4);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(90, 32);
            btnGet.TabIndex = 1;
            btnGet.Text = "GET";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(12, 62);
            rtbContent.Margin = new Padding(3, 4, 3, 4);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(758, 562);
            rtbContent.TabIndex = 2;
            rtbContent.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(782, 641);
            Controls.Add(rtbContent);
            Controls.Add(btnGet);
            Controls.Add(txtUrl);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Bai 1";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.RichTextBox rtbContent;
    }
}