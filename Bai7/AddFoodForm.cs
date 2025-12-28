using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bai7
{
    public partial class AddFoodForm : Form
    {
        private const string BASE_URL = "https://nt106.uitiot.vn";
        private string accessToken;

        public AddFoodForm(string token)
        {
            InitializeComponent();
            this.accessToken = token;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtTenMonAn.Text))
            {
                MessageBox.Show("Tên món ăn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Giá không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtGia.Text, out int gia) || gia < 0)
            {
                MessageBox.Show("Giá phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Image URL is now OPTIONAL (can be empty string)
            string imageUrl = txtImageUrl.Text.Trim();

            // If user provided URL, validate it
            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                if (!imageUrl.StartsWith("http://") && !imageUrl.StartsWith("https://"))
                {
                    MessageBox.Show("URL hình ảnh phải bắt đầu với http:// hoặc https://",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);

                    // Add Bearer token for authentication
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    var url = $"{BASE_URL}/api/v1/monan/add";

                    // Build request body (matching Swagger schema)
                    var requestBody = new
                    {
                        ten_mon_an = txtTenMonAn.Text.Trim(),
                        gia = gia,
                        mo_ta = txtMoTa.Text.Trim(),
                        hinh_anh = imageUrl,  // URL string (can be empty)
                        dia_chi = txtDiaChi.Text.Trim()
                    };

                    var jsonContent = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    System.Diagnostics.Debug.WriteLine($"[AddFood] Sending request to: {url}");
                    System.Diagnostics.Debug.WriteLine($"[AddFood] Request body: {jsonContent}");

                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    System.Diagnostics.Debug.WriteLine($"[AddFood] Status: {response.StatusCode}");
                    System.Diagnostics.Debug.WriteLine($"[AddFood] Response: {responseString}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse success response
                        var foodResponse = JObject.Parse(responseString);
                        string foodId = foodResponse["id"]?.ToString() ?? "Unknown";
                        string foodName = foodResponse["ten_mon_an"]?.ToString() ?? txtTenMonAn.Text;

                        MessageBox.Show($"Thêm món ăn thành công!\n\nMón ăn: {foodName}\nID: {foodId}",
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
                                    MessageBox.Show($"Thêm món ăn thất bại:\n\n{detail}",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if (errorObject["message"] != null)
                            {
                                string message = errorObject["message"].ToString();
                                MessageBox.Show($"Thêm món ăn thất bại:\n\n{message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show($"Thêm món ăn thất bại!\n\nStatus: {response.StatusCode}\n\nResponse: {responseString}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (JsonException)
                        {
                            MessageBox.Show($"Thêm món ăn thất bại!\n\nStatus: {response.StatusCode}\n\nResponse: {responseString}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Lỗi kết nối:\n\n{ex.Message}\n\nKiểm tra:\n- Internet connection\n- Token có hợp lệ không?",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timeout! Server không phản hồi.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định:\n\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Optional: Preview image when URL is entered
        private void txtImageUrl_TextChanged(object sender, EventArgs e)
        {
            string url = txtImageUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                pictureBoxPreview.Image = null;
                return;
            }

            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                try
                {
                    pictureBoxPreview.Load(url);
                }
                catch
                {
                    // Invalid URL or image not accessible
                    pictureBoxPreview.Image = null;
                }
            }
        }
    }
}