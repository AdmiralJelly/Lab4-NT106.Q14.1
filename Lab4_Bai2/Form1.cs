using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Lab4_Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient myClient = new WebClient();
                string url = txtUrl.Text;
                string path = txtPath.Text;

                // 1. Tải về file
                myClient.DownloadFile(url, path);
                MessageBox.Show("Tải thành công về: " + path);

                // 2. Đọc lên màn hình 
                Stream response = myClient.OpenRead(url);
                StreamReader reader = new StreamReader(response);
                rtbContent.Text = reader.ReadToEnd();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}