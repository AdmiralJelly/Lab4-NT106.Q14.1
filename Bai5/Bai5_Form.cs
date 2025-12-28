using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    public partial class Bai5_Form : Form
    {
        public Bai5_Form()
        {
            InitializeComponent();
            txt_url.Text = "https://nt106.uitiot.vn/auth/token";
        }

        private async void btnPost_Click(object sender, EventArgs e)
        {
            // Kiểm tra input
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                MessageBox.Show("Vui lòng nhập username!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_username.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                MessageBox.Show("Vui lòng nhập password!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pass.Focus();
                return;
            }

            // Disable button và clear result
            btnPost.Enabled = false;
            txt_response.Clear();
            txt_response.Text = "Đang đăng nhập...";

            try
            {
                string url = txt_url.Text.Trim();
                string username = txt_username.Text.Trim();
                string password = txt_pass.Text;

                using (HttpClient httpclient = new HttpClient())
                {
                    // Tạo form-data content (theo yêu cầu đề bài)
                    var content = new MultipartFormDataContent
                    {
                        { new StringContent(username), "username" },
                        { new StringContent(password), "password" }
                    };

                    // Gửi POST request
                    HttpResponseMessage response = await httpclient.PostAsync(url, content);

                    // Đọc response
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Parse JSON response
                    var json_response = JObject.Parse(responseContent);

                    // Clear result box
                    txt_response.Clear();

                    // Kiểm tra kết quả
                    if (!response.IsSuccessStatusCode)
                    {
                        // Đăng nhập thất bại - hiển thị detail
                        string detail = json_response["detail"]?.ToString() ?? "Đăng nhập không thành công";
                        txt_response.Text = detail;
                    }
                    else
                    {
                        // Đăng nhập thành công - hiển thị token_type và access_token
                        string token_type = json_response["token_type"]?.ToString() ?? "";
                        string access_token = json_response["access_token"]?.ToString() ?? "";

                        txt_response.Text = $"{token_type} {access_token}\n\n";
                        txt_response.Text += "Đăng nhập thành công";
                    }
                }
            }
            catch (Exception ex)
            {
                txt_response.Clear();
                txt_response.Text = $"Lỗi: {ex.Message}";
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPost.Enabled = true;
            }
        }
    }
}