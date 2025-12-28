using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 
using System.Net;
using System.IO;

namespace Lab4_Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Hàm lấy nội dung HTML từ URL (Dựa trên tài liệu trang 8)
        private string getHTML(string szURL)
        {

            WebRequest request = WebRequest.Create(szURL);

 
            WebResponse response = request.GetResponse();


            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);


            string responseFromServer = reader.ReadToEnd();

            response.Close();

            return responseFromServer; 
        }

        // Sự kiện khi nhấn nút GET
        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy đường dẫn từ ô TextBox
                string url = txtUrl.Text;

                // Gọi hàm xử lý và hiển thị kết quả ra RichTextBox
                string htmlContent = getHTML(url);
                rtbContent.Text = htmlContent;
            }
            catch (Exception ex)
            {
                // Thông báo nếu có lỗi (ví dụ: sai đường dẫn, mất mạng)
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}