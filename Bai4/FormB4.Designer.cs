namespace Bai4
{
    partial class FormB4
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
            this.btn_GetMovies = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.flp_Movies = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_Duration = new System.Windows.Forms.Label();
            this.lbl_Genre = new System.Windows.Forms.Label();
            this.lbl_Director = new System.Windows.Forms.Label();
            this.rtb_Description = new System.Windows.Forms.RichTextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pb_Poster = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Poster)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GetMovies
            // 
            this.btn_GetMovies.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_GetMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GetMovies.ForeColor = System.Drawing.Color.White;
            this.btn_GetMovies.Location = new System.Drawing.Point(12, 12);
            this.btn_GetMovies.Name = "btn_GetMovies";
            this.btn_GetMovies.Size = new System.Drawing.Size(186, 45);
            this.btn_GetMovies.TabIndex = 0;
            this.btn_GetMovies.Text = "Lấy Danh Sách Phim";
            this.btn_GetMovies.UseVisualStyleBackColor = false;
            this.btn_GetMovies.Click += new System.EventHandler(this.btn_GetMovies_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(204, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(950, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.Location = new System.Drawing.Point(204, 39);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(65, 15);
            this.lbl_Status.TabIndex = 2;
            this.lbl_Status.Text = "Sẵn sàng...";
            // 
            // flp_Movies
            // 
            this.flp_Movies.AutoScroll = true;
            this.flp_Movies.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flp_Movies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Movies.Location = new System.Drawing.Point(3, 16);
            this.flp_Movies.Name = "flp_Movies";
            this.flp_Movies.Size = new System.Drawing.Size(830, 563);
            this.flp_Movies.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.flp_Movies);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 582);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phim đang chiếu";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbl_Duration);
            this.groupBox2.Controls.Add(this.lbl_Genre);
            this.groupBox2.Controls.Add(this.lbl_Director);
            this.groupBox2.Controls.Add(this.rtb_Description);
            this.groupBox2.Controls.Add(this.lbl_Title);
            this.groupBox2.Controls.Add(this.pb_Poster);
            this.groupBox2.Location = new System.Drawing.Point(854, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 582);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết phim";
            // 
            // lbl_Duration
            // 
            this.lbl_Duration.AutoSize = true;
            this.lbl_Duration.Location = new System.Drawing.Point(15, 360);
            this.lbl_Duration.Name = "lbl_Duration";
            this.lbl_Duration.Size = new System.Drawing.Size(60, 13);
            this.lbl_Duration.TabIndex = 5;
            this.lbl_Duration.Text = "Thời lượng:";
            // 
            // lbl_Genre
            // 
            this.lbl_Genre.AutoSize = true;
            this.lbl_Genre.Location = new System.Drawing.Point(15, 340);
            this.lbl_Genre.Name = "lbl_Genre";
            this.lbl_Genre.Size = new System.Drawing.Size(48, 13);
            this.lbl_Genre.TabIndex = 4;
            this.lbl_Genre.Text = "Thể loại:";
            // 
            // lbl_Director
            // 
            this.lbl_Director.AutoSize = true;
            this.lbl_Director.Location = new System.Drawing.Point(15, 320);
            this.lbl_Director.Name = "lbl_Director";
            this.lbl_Director.Size = new System.Drawing.Size(53, 13);
            this.lbl_Director.TabIndex = 3;
            this.lbl_Director.Text = "Đạo diễn:";
            // 
            // rtb_Description
            // 
            this.rtb_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Description.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Description.Location = new System.Drawing.Point(15, 390);
            this.rtb_Description.Name = "rtb_Description";
            this.rtb_Description.ReadOnly = true;
            this.rtb_Description.Size = new System.Drawing.Size(273, 180);
            this.rtb_Description.TabIndex = 2;
            this.rtb_Description.Text = "";
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_Title.Location = new System.Drawing.Point(6, 260);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(288, 50);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Tên Phim";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_Poster
            // 
            this.pb_Poster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Poster.Location = new System.Drawing.Point(40, 20);
            this.pb_Poster.Name = "pb_Poster";
            this.pb_Poster.Size = new System.Drawing.Size(220, 300); // Điều chỉnh kích thước hiển thị
            this.pb_Poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; // Thay đổi mode để không bị méo ảnh
            this.pb_Poster.TabIndex = 0;
            this.pb_Poster.TabStop = false;
            // 
            // Bai4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 657);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_GetMovies);
            this.Name = "Bai4";
            this.Text = "Quản lý phòng vé - Lab 4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Poster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GetMovies;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.FlowLayoutPanel flp_Movies;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pb_Poster;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.RichTextBox rtb_Description;
        private System.Windows.Forms.Label lbl_Director;
        private System.Windows.Forms.Label lbl_Duration;
        private System.Windows.Forms.Label lbl_Genre;
    }
}