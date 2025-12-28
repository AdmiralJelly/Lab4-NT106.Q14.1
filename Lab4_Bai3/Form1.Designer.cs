namespace Lab4_Bai3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            txtUrl = new TextBox();
            btnLoad = new Button();
            btnDownFile = new Button();
            btnDownResources = new Button();
            btnViewSource = new Button();
            panelWeb = new Panel();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(12, 12);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(500, 27);
            txtUrl.TabIndex = 5;
            txtUrl.Text = "";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(520, 10);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 25);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Go";
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDownFile
            // 
            btnDownFile.Location = new Point(600, 10);
            btnDownFile.Name = "btnDownFile";
            btnDownFile.Size = new Size(100, 25);
            btnDownFile.TabIndex = 3;
            btnDownFile.Text = "Down HTML";
            btnDownFile.Click += btnDownFile_Click;
            // 
            // btnDownResources
            // 
            btnDownResources.Location = new Point(705, 10);
            btnDownResources.Name = "btnDownResources";
            btnDownResources.Size = new Size(100, 25);
            btnDownResources.TabIndex = 2;
            btnDownResources.Text = "Down Img";
            btnDownResources.Click += btnDownResources_Click;
            // 
            // btnViewSource
            // 
            btnViewSource.Location = new Point(810, 10);
            btnViewSource.Name = "btnViewSource";
            btnViewSource.Size = new Size(100, 25);
            btnViewSource.TabIndex = 1;
            btnViewSource.Text = "View Source";
            btnViewSource.Click += btnViewSource_Click;
            // 
            // panelWeb
            // 
            panelWeb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelWeb.Location = new Point(12, 50);
            panelWeb.Name = "panelWeb";
            panelWeb.Size = new Size(950, 500);
            panelWeb.TabIndex = 0;
            // 
            // Form1
            // 
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(984, 561);
            Controls.Add(panelWeb);
            Controls.Add(btnViewSource);
            Controls.Add(btnDownResources);
            Controls.Add(btnDownFile);
            Controls.Add(btnLoad);
            Controls.Add(txtUrl);
            Name = "Form1";
            Text = "Bài 3: Web Browser";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDownFile;
        private System.Windows.Forms.Button btnDownResources;
        private System.Windows.Forms.Button btnViewSource;
        private System.Windows.Forms.Panel panelWeb;
    }
}