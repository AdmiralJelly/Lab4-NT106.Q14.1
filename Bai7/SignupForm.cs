using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bai7
{
    public partial class SignUpForm : Form
    {
        private const string BASE_URL = "https://nt106.uitiot.vn";

        public SignUpForm()
        {
            InitializeComponent();
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 3)
            {
                MessageBox.Show("Username phải có ít nhất 3 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Password phải có ít nhất 8 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First name không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last name không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate phone number (9-11 digits)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{9,11}$"))
            {
                MessageBox.Show("Phone phải là 9-11 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate age (>= 13)
            DateTime selectedBirthday = dtpBirthday.Value.Date;
            int age = DateTime.Now.Year - selectedBirthday.Year;
            if (DateTime.Now.DayOfYear < selectedBirthday.DayOfYear)
                age--;

            //if (age < 13)
            //{
            //    MessageBox.Show("Bạn phải từ 13 tuổi trở lên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);

                    // OFFICIAL ENDPOINT from Swagger UI (page 5)
                    var url = $"{BASE_URL}/api/v1/user/signup";

                    // Get sex value (0, 1, or 2)
                    int sexValue = 0; // Default: Not specified
                    if (rbMale.Checked)
                        sexValue = 1;
                    else if (rbFemale.Checked)
                        sexValue = 2;

                    // Get language value
                    string languageValue = "vi"; // Default
                    if (!string.IsNullOrWhiteSpace(txtLanguage.Text))
                        languageValue = txtLanguage.Text.Trim();

                    // Build JSON request body (matching Swagger schema)
                    var requestBody = new
                    {
                        username = txtUsername.Text.Trim(),
                        email = txtEmail.Text.Trim(),
                        password = txtPassword.Text,
                        first_name = txtFirstName.Text.Trim(),
                        last_name = txtLastName.Text.Trim(),
                        sex = sexValue,
                        birthday = selectedBirthday.ToString("yyyy-MM-dd"),
                        language = languageValue,
                        phone = txtPhone.Text.Trim()
                    };

                    var jsonContent = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    System.Diagnostics.Debug.WriteLine($"[SignUp] Sending request to: {url}");
                    System.Diagnostics.Debug.WriteLine($"[SignUp] Request body: {jsonContent}");

                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    System.Diagnostics.Debug.WriteLine($"[SignUp] Status: {response.StatusCode}");
                    System.Diagnostics.Debug.WriteLine($"[SignUp] Response: {responseString}");

                    // Check if response is HTML (error page)
                    if (responseString.TrimStart().StartsWith("<") || responseString.TrimStart().StartsWith("<!DOCTYPE"))
                    {
                        MessageBox.Show($"Server trả về HTML thay vì JSON!\n\nEndpoint có thể sai: {url}\n\nStatus: {response.StatusCode}",
                            "Lỗi Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse success response
                        var userResponse = JObject.Parse(responseString);
                        string userId = userResponse["id"]?.ToString() ?? "Unknown";
                        string username = userResponse["username"]?.ToString() ?? txtUsername.Text;

                        MessageBox.Show($"Đăng ký thành công!\n\nUsername: {username}\nUser ID: {userId}\n\nBạn có thể đăng nhập ngay bây giờ!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // Parse error response
                        try
                        {
                            var errorObject = JObject.Parse(responseString);

                            // Try to get error detail (FastAPI validation error format)
                            if (errorObject["detail"] != null)
                            {
                                // Check if detail is array (validation errors)
                                if (errorObject["detail"] is JArray detailArray)
                                {
                                    StringBuilder errorMsg = new StringBuilder("Lỗi validation:\n\n");
                                    foreach (var error in detailArray)
                                    {
                                        string field = error["loc"]?[1]?.ToString() ?? "unknown";
                                        string msg = error["msg"]?.ToString() ?? "Unknown error";
                                        errorMsg.AppendLine($"- {field}: {msg}");
                                    }
                                    MessageBox.Show(errorMsg.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    // Detail is string
                                    string detail = errorObject["detail"].ToString();
                                    MessageBox.Show($"Đăng ký thất bại:\n\n{detail}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if (errorObject["message"] != null)
                            {
                                string message = errorObject["message"].ToString();
                                MessageBox.Show($"Đăng ký thất bại:\n\n{message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show($"Đăng ký thất bại!\n\nStatus: {response.StatusCode}\n\nResponse: {responseString}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (JsonException)
                        {
                            MessageBox.Show($"Đăng ký thất bại!\n\nStatus: {response.StatusCode}\n\nResponse: {responseString}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Lỗi kết nối:\n\n{ex.Message}\n\nKiểm tra:\n- Internet connection\n- Server có đang chạy?",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timeout! Server không phản hồi.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"Lỗi parse JSON:\n\n{ex.Message}\n\nServer có thể trả về HTML thay vì JSON.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định:\n\n{ex.Message}\n\nStack trace:\n{ex.StackTrace}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}