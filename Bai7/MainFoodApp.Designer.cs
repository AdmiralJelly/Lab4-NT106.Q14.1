namespace Bai7
{
    partial class MainFoodApp
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

        private void InitializeComponent()
        {
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.lw_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_showAll = new System.Windows.Forms.Button();
            this.btn_showMine = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_randomAll = new System.Windows.Forms.Button();
            this.btn_randomMine = new System.Windows.Forms.Button();
            this.tb_rand = new System.Windows.Forms.TextBox();
            this.ptb_rand = new System.Windows.Forms.PictureBox();
            this.ptb_selected = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_prevPage = new System.Windows.Forms.Button();
            this.btn_nextPage = new System.Windows.Forms.Button();
            this.lbl_page = new System.Windows.Forms.Label();
            this.btn_logout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_rand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_selected)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_welcome.ForeColor = System.Drawing.Color.White;
            this.lbl_welcome.Location = new System.Drawing.Point(30, 20);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(200, 32);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "Welcome, User";
            // 
            // lw_list
            // 
            this.lw_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lw_list.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.lw_list.FullRowSelect = true;
            this.lw_list.GridLines = true;
            this.lw_list.HideSelection = false;
            this.lw_list.Location = new System.Drawing.Point(30, 120);
            this.lw_list.Name = "lw_list";
            this.lw_list.Size = new System.Drawing.Size(700, 300);
            this.lw_list.TabIndex = 1;
            this.lw_list.UseCompatibleStateImageBehavior = false;
            this.lw_list.View = System.Windows.Forms.View.Details;
            this.lw_list.SelectedIndexChanged += new System.EventHandler(this.lw_list_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Món Ăn";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID Người Đóng Góp";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID Món Ăn";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giá";
            this.columnHeader4.Width = 150;
            // 
            // btn_showAll
            // 
            this.btn_showAll.BackColor = System.Drawing.Color.Orange;
            this.btn_showAll.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold);
            this.btn_showAll.Location = new System.Drawing.Point(30, 70);
            this.btn_showAll.Name = "btn_showAll";
            this.btn_showAll.Size = new System.Drawing.Size(150, 35);
            this.btn_showAll.TabIndex = 2;
            this.btn_showAll.Text = "Tất Cả Món Ăn";
            this.btn_showAll.UseVisualStyleBackColor = false;
            this.btn_showAll.Click += new System.EventHandler(this.btn_showAll_Click);
            // 
            // btn_showMine
            // 
            this.btn_showMine.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold);
            this.btn_showMine.Location = new System.Drawing.Point(200, 70);
            this.btn_showMine.Name = "btn_showMine";
            this.btn_showMine.Size = new System.Drawing.Size(150, 35);
            this.btn_showMine.TabIndex = 3;
            this.btn_showMine.Text = "Món Ăn Của Tôi";
            this.btn_showMine.UseVisualStyleBackColor = true;
            this.btn_showMine.Click += new System.EventHandler(this.btn_showMine_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.LightGreen;
            this.btn_add.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold);
            this.btn_add.Location = new System.Drawing.Point(30, 440);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(120, 40);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Thêm Món";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.LightCoral;
            this.btn_delete.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold);
            this.btn_delete.Location = new System.Drawing.Point(170, 440);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(120, 40);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "Xóa Món";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_randomAll
            // 
            this.btn_randomAll.BackColor = System.Drawing.Color.Cyan;
            this.btn_randomAll.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold);
            this.btn_randomAll.Location = new System.Drawing.Point(800, 440);
            this.btn_randomAll.Name = "btn_randomAll";
            this.btn_randomAll.Size = new System.Drawing.Size(180, 40);
            this.btn_randomAll.TabIndex = 6;
            this.btn_randomAll.Text = "Random Tất Cả";
            this.btn_randomAll.UseVisualStyleBackColor = false;
            this.btn_randomAll.Click += new System.EventHandler(this.btn_randomAll_Click);
            // 
            // btn_randomMine
            // 
            this.btn_randomMine.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_randomMine.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold);
            this.btn_randomMine.Location = new System.Drawing.Point(1000, 440);
            this.btn_randomMine.Name = "btn_randomMine";
            this.btn_randomMine.Size = new System.Drawing.Size(180, 40);
            this.btn_randomMine.TabIndex = 7;
            this.btn_randomMine.Text = "Random Của Tôi";
            this.btn_randomMine.UseVisualStyleBackColor = false;
            this.btn_randomMine.Click += new System.EventHandler(this.btn_randomMine_Click);
            // 
            // tb_rand
            // 
            this.tb_rand.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.tb_rand.Location = new System.Drawing.Point(800, 120);
            this.tb_rand.Multiline = true;
            this.tb_rand.Name = "tb_rand";
            this.tb_rand.ReadOnly = true;
            this.tb_rand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_rand.Size = new System.Drawing.Size(380, 150);
            this.tb_rand.TabIndex = 8;
            // 
            // ptb_rand
            // 
            this.ptb_rand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptb_rand.Location = new System.Drawing.Point(800, 290);
            this.ptb_rand.Name = "ptb_rand";
            this.ptb_rand.Size = new System.Drawing.Size(380, 130);
            this.ptb_rand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_rand.TabIndex = 9;
            this.ptb_rand.TabStop = false;
            // 
            // ptb_selected
            // 
            this.ptb_selected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptb_selected.Location = new System.Drawing.Point(30, 530);
            this.ptb_selected.Name = "ptb_selected";
            this.ptb_selected.Size = new System.Drawing.Size(250, 200);
            this.ptb_selected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_selected.TabIndex = 10;
            this.ptb_selected.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(850, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "MÓN ĂN HÔM NAY LÀ";
            // 
            // btn_prevPage
            // 
            this.btn_prevPage.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.btn_prevPage.Location = new System.Drawing.Point(540, 440);
            this.btn_prevPage.Name = "btn_prevPage";
            this.btn_prevPage.Size = new System.Drawing.Size(80, 35);
            this.btn_prevPage.TabIndex = 12;
            this.btn_prevPage.Text = "< Prev";
            this.btn_prevPage.UseVisualStyleBackColor = true;
            this.btn_prevPage.Click += new System.EventHandler(this.btn_prevPage_Click);
            // 
            // btn_nextPage
            // 
            this.btn_nextPage.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.btn_nextPage.Location = new System.Drawing.Point(650, 440);
            this.btn_nextPage.Name = "btn_nextPage";
            this.btn_nextPage.Size = new System.Drawing.Size(80, 35);
            this.btn_nextPage.TabIndex = 13;
            this.btn_nextPage.Text = "Next >";
            this.btn_nextPage.UseVisualStyleBackColor = true;
            this.btn_nextPage.Click += new System.EventHandler(this.btn_nextPage_Click);
            // 
            // lbl_page
            // 
            this.lbl_page.AutoSize = true;
            this.lbl_page.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.lbl_page.ForeColor = System.Drawing.Color.White;
            this.lbl_page.Location = new System.Drawing.Point(540, 490);
            this.lbl_page.Name = "lbl_page";
            this.lbl_page.Size = new System.Drawing.Size(100, 20);
            this.lbl_page.TabIndex = 14;
            this.lbl_page.Text = "Page 1 / 1";
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.IndianRed;
            this.btn_logout.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold);
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.Location = new System.Drawing.Point(1050, 15);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(130, 40);
            this.btn_logout.TabIndex = 15;
            this.btn_logout.Text = "Đăng Xuất";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Hình Món Ăn Đã Chọn";
            // 
            // MainFoodApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1220, 750);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.lbl_page);
            this.Controls.Add(this.btn_nextPage);
            this.Controls.Add(this.btn_prevPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptb_selected);
            this.Controls.Add(this.ptb_rand);
            this.Controls.Add(this.tb_rand);
            this.Controls.Add(this.btn_randomMine);
            this.Controls.Add(this.btn_randomAll);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_showMine);
            this.Controls.Add(this.btn_showAll);
            this.Controls.Add(this.lw_list);
            this.Controls.Add(this.lbl_welcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainFoodApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hôm Nay Ăn Gì?";
            ((System.ComponentModel.ISupportInitialize)(this.ptb_rand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_selected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.ListView lw_list;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btn_showAll;
        private System.Windows.Forms.Button btn_showMine;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_randomAll;
        private System.Windows.Forms.Button btn_randomMine;
        private System.Windows.Forms.TextBox tb_rand;
        private System.Windows.Forms.PictureBox ptb_rand;
        private System.Windows.Forms.PictureBox ptb_selected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_prevPage;
        private System.Windows.Forms.Button btn_nextPage;
        private System.Windows.Forms.Label lbl_page;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label label2;
    }
}