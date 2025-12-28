using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai7
{
    public partial class LoginForm : Form
    {
        private HttpClient client;
        private const string BASE_URL = "https://nt106.uitiot.vn";

        public LoginForm()
        {
            InitializeComponent();
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btn_login.Enabled = false;
                btn_login.Text = "Đang đăng nhập...";

                var content = new MultipartFormDataContent
                {
                    { new StringContent(username), "username" },
                    { new StringContent(password), "password" }
                };

                var response = await client.PostAsync($"{BASE_URL}/auth/token", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var errorObject = JObject.Parse(responseString);
                    string detail = errorObject["detail"]?.ToString() ?? "Đăng nhập thất bại";
                    MessageBox.Show(detail, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var responseObject = JObject.Parse(responseString);
                string tokenType = responseObject["token_type"].ToString();
                string accessToken = responseObject["access_token"].ToString();

                // Store token globally
                GlobalData.AccessToken = accessToken;
                GlobalData.TokenType = tokenType;
                GlobalData.Username = username;

                MessageBox.Show("Đăng nhập thành công!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open main food app
                MainFoodApp mainApp = new MainFoodApp();
                mainApp.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_login.Enabled = true;
                btn_login.Text = "LOGIN";
            }
        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            client?.Dispose();
            base.OnFormClosing(e);
        }
    }

    // Global data storage class
    public static class GlobalData
    {
        public static string AccessToken { get; set; }
        public static string TokenType { get; set; }
        public static string Username { get; set; }
        public static HttpClient HttpClient { get; set; } = new HttpClient();
    }
}