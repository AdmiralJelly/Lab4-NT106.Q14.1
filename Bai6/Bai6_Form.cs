using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai6
{
    public partial class Bai6_Form : Form
    {
        private HttpClient client;
        private string accessToken;
        private string tokenType;

        public Bai6_Form()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable button during login
                btnLogin.Enabled = false;
                lblStatus.Text = "Đang đăng nhập...";

                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ username và password!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call login API
                var loginUrl = "https://nt106.uitiot.vn/auth/token";
                var content = new MultipartFormDataContent
                {
                    { new StringContent(username), "username" },
                    { new StringContent(password), "password" }
                };

                var response = await client.PostAsync(loginUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var errorObject = JObject.Parse(responseString);
                    string detail = errorObject["detail"]?.ToString() ?? "Đăng nhập thất bại";
                    lblStatus.Text = "Lỗi: " + detail;
                    MessageBox.Show(detail, "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse token response
                var responseObject = JObject.Parse(responseString);
                tokenType = responseObject["token_type"]?.ToString();
                accessToken = responseObject["access_token"]?.ToString();

                lblStatus.Text = "Đăng nhập thành công!";

                // Show token info
                rtbTokenInfo.Clear();
                rtbTokenInfo.AppendText("=== TOKEN INFORMATION ===\n\n");
                rtbTokenInfo.AppendText($"Token Type: {tokenType}\n\n");
                rtbTokenInfo.AppendText($"Access Token:\n{accessToken}\n\n");

                // Enable user info button
                btnGetUserInfo.Enabled = true;

                MessageBox.Show("Đăng nhập thành công!\nBạn có thể xem thông tin người dùng.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi kết nối";
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private async void btnGetUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(accessToken))
                {
                    MessageBox.Show("Vui lòng đăng nhập trước!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGetUserInfo.Enabled = false;
                lblStatus.Text = "Đang lấy thông tin người dùng...";

                // Set authorization header
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, accessToken);

                // Call GET user info API
                var getUserUrl = "https://nt106.uitiot.vn/api/v1/user/me";
                var getUserResponse = await client.GetAsync(getUserUrl);

                if (!getUserResponse.IsSuccessStatusCode)
                {
                    var errorString = await getUserResponse.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi lấy thông tin: {errorString}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Lỗi khi lấy thông tin";
                    return;
                }

                var getUserResponseString = await getUserResponse.Content.ReadAsStringAsync();

                // Parse user information
                var userObject = JObject.Parse(getUserResponseString);

                // Display user information in the form
                DisplayUserInfo(userObject);

                lblStatus.Text = "Đã tải thông tin người dùng thành công!";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi";
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGetUserInfo.Enabled = true;
            }
        }

        private void DisplayUserInfo(JObject userObject)
        {
            rtbUserInfo.Clear();
            rtbUserInfo.AppendText("=== THÔNG TIN NGƯỜI DÙNG ===\n\n");

            // Display all available fields
            if (userObject["username"] != null)
                rtbUserInfo.AppendText($"Username: {userObject["username"]}\n\n");

            if (userObject["email"] != null)
                rtbUserInfo.AppendText($"Email: {userObject["email"]}\n\n");

            if (userObject["first_name"] != null)
                rtbUserInfo.AppendText($"First Name: {userObject["first_name"]}\n\n");

            if (userObject["last_name"] != null)
                rtbUserInfo.AppendText($"Last Name: {userObject["last_name"]}\n\n");

            if (userObject["phone"] != null)
                rtbUserInfo.AppendText($"Phone: {userObject["phone"]}\n\n");

            if (userObject["birthday"] != null)
                rtbUserInfo.AppendText($"Birthday: {userObject["birthday"]}\n\n");

            if (userObject["sex"] != null)
                rtbUserInfo.AppendText($"Sex: {userObject["sex"]}\n\n");

            if (userObject["language"] != null)
                rtbUserInfo.AppendText($"Language: {userObject["language"]}\n\n");

            if (userObject["id"] != null)
                rtbUserInfo.AppendText($"User ID: {userObject["id"]}\n\n");

            // Display raw JSON
            rtbUserInfo.AppendText("\n=== RAW JSON RESPONSE ===\n\n");
            rtbUserInfo.AppendText(userObject.ToString());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            rtbTokenInfo.Clear();
            rtbUserInfo.Clear();
            lblStatus.Text = "Sẵn sàng";
            accessToken = null;
            tokenType = null;
            btnGetUserInfo.Enabled = false;

            // Clear authorization header
            client.DefaultRequestHeaders.Authorization = null;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            client?.Dispose();
            base.OnFormClosing(e);
        }
    }
}