using Bai7;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai7
{
    public partial class MainFoodApp : Form
    {
        private HttpClient client;
        private const string BASE_URL = "https://nt106.uitiot.vn";
        private int currentPage = 1;
        private int pageSize = 5;
        private int totalPages = 1;
        private bool showingMyFoods = false;
        private List<FoodItem> allFoods = new List<FoodItem>();

        private string accessToken;

        public MainFoodApp()
        {
            InitializeComponent();
            InitializeHttpClient();

            // ✅ FIX: Assign token from GlobalData
            this.accessToken = GlobalData.AccessToken;

            LoadUserInfo();
            LoadFoods();
        }

        private void InitializeHttpClient()
        {
            client = GlobalData.HttpClient;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(GlobalData.TokenType, GlobalData.AccessToken);
        }

        private async void LoadUserInfo()
        {
            try
            {
                var response = await client.GetAsync($"{BASE_URL}/api/v1/user/me");
                if (response.IsSuccessStatusCode)
                {
                    var userJson = await response.Content.ReadAsStringAsync();
                    var user = JObject.Parse(userJson);
                    lbl_welcome.Text = $"Welcome, {user["username"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin: {ex.Message}", "Lỗi");
            }
        }

        private async void LoadFoods()
        {
            try
            {
                // ✅ FIX: Use correct endpoints from Swagger
                string endpoint = showingMyFoods
                    ? $"{BASE_URL}/api/v1/monan/my-dishes"
                    : $"{BASE_URL}/api/v1/monan/all";

                // ✅ FIX: Use POST with JSON body (not GET with query params)
                var requestBody = new
                {
                    current = currentPage,
                    pageSize = pageSize
                };

                var jsonContent = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Không thể tải danh sách món ăn!\n\nStatus: {response.StatusCode}\nError: {errorMsg}", "Lỗi");
                    return;
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(jsonResponse);

                allFoods.Clear();
                lw_list.Items.Clear();

                // ✅ FIX: Response has "data" array, not "items"
                var items = data["data"] as JArray;
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        var food = new FoodItem
                        {
                            Id = item["id"]?.ToString(),
                            Ten = item["ten_mon_an"]?.ToString(),
                            Gia = item["gia"]?.ToObject<int>() ?? 0,
                            DiaChiQuanAn = item["dia_chi"]?.ToString(),  // ✅ "dia_chi" not "dia_chi_quan_an"
                            MoTa = item["mo_ta"]?.ToString(),
                            HinhAnh = item["hinh_anh"]?.ToString(),
                            IdNguoiDongGop = item["nguoi_dong_gop"]?.ToString()  // ✅ "nguoi_dong_gop" not "id_nguoi_dong_gop"
                        };
                        allFoods.Add(food);

                        var listItem = new ListViewItem(food.Ten);
                        listItem.SubItems.Add(food.IdNguoiDongGop);
                        listItem.SubItems.Add(food.Id);
                        listItem.SubItems.Add(food.Gia.ToString("N0") + " VND");
                        listItem.Tag = food;
                        lw_list.Items.Add(listItem);
                    }
                }

                // ✅ FIX: Response has "pagination" object
                var pagination = data["pagination"];
                totalPages = pagination["total"]?.ToObject<int>() ?? 0;
                int total = totalPages;
                totalPages = (int)Math.Ceiling((double)total / pageSize);

                lbl_page.Text = $"Page {currentPage} / {totalPages}";

                btn_prevPage.Enabled = currentPage > 1;
                btn_nextPage.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\n\nStack: {ex.StackTrace}", "Lỗi");
            }
        }

        private void btn_showAll_Click(object sender, EventArgs e)
        {
            showingMyFoods = false;
            currentPage = 1;
            btn_showAll.BackColor = Color.Orange;
            btn_showMine.BackColor = SystemColors.Control;
            LoadFoods();
        }

        private void btn_showMine_Click(object sender, EventArgs e)
        {
            showingMyFoods = true;
            currentPage = 1;
            btn_showMine.BackColor = Color.Orange;
            btn_showAll.BackColor = SystemColors.Control;
            LoadFoods();
        }

        private void btn_nextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadFoods();
            }
        }

        private void btn_prevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadFoods();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            // ✅ FIX: Pass accessToken to AddFoodForm
            AddFoodForm addForm = new AddFoodForm(this.accessToken);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadFoods();
            }
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (lw_list.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông báo");
                return;
            }

            var food = lw_list.SelectedItems[0].Tag as FoodItem;
            var result = MessageBox.Show($"Bạn có chắc muốn xóa món '{food.Ten}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var response = await client.DeleteAsync($"{BASE_URL}/api/v1/monan/{food.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa món ăn thành công!", "Thành công");
                        LoadFoods();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Không thể xóa: {error}", "Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
                }
            }
        }

        private async void btn_randomAll_Click(object sender, EventArgs e)
        {
            await RandomFood(false);
        }

        private async void btn_randomMine_Click(object sender, EventArgs e)
        {
            await RandomFood(true);
        }

        private async Task RandomFood(bool onlyMine)
        {
            try
            {
                // ✅ Note: Random endpoints might not exist in API
                // Using workaround: Load all foods and pick random locally
                string endpoint = showingMyFoods
                    ? $"{BASE_URL}/api/v1/monan/my-dishes"
                    : $"{BASE_URL}/api/v1/monan/all";

                var requestBody = new
                {
                    current = 1,
                    pageSize = 100  // Get more items for better random selection
                };

                var jsonContent = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không thể lấy món ăn ngẫu nhiên!", "Lỗi");
                    return;
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(jsonResponse);
                var items = data["data"] as JArray;

                if (items == null || items.Count == 0)
                {
                    MessageBox.Show("Chưa có món ăn nào!", "Thông báo");
                    return;
                }

                // Pick random item
                var random = new Random();
                int index = random.Next(0, items.Count);
                var food = items[index];

                // ✅ FIX: Use correct field names from API
                tb_rand.Text = $"Tên món: {food["ten_mon_an"]}\r\n" +
                              $"Giá: {food["gia"]:N0} VND\r\n" +
                              $"Địa chỉ: {food["dia_chi"]}\r\n" +  // ✅ "dia_chi" not "dia_chi_quan_an"
                              $"Mô tả: {food["mo_ta"]}";

                // Load image if available
                string imageUrl = food["hinh_anh"]?.ToString();
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    await LoadImage(imageUrl, ptb_rand);
                }
                else
                {
                    ptb_rand.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

        private async Task LoadImage(string url, PictureBox pictureBox)
        {
            try
            {
                var httpClient = new HttpClient();
                var imageBytes = await httpClient.GetByteArrayAsync(url);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    pictureBox.Image = Image.FromStream(ms);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch
            {
                pictureBox.Image = null;
            }
        }

        private async void lw_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lw_list.SelectedItems.Count > 0)
            {
                var food = lw_list.SelectedItems[0].Tag as FoodItem;
                if (food != null && !string.IsNullOrEmpty(food.HinhAnh))
                {
                    await LoadImage(food.HinhAnh, ptb_selected);
                }
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GlobalData.AccessToken = null;
                GlobalData.TokenType = null;
                GlobalData.Username = null;

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
            base.OnFormClosing(e);
        }
    }

    // Food item model
    public class FoodItem
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int Gia { get; set; }
        public string DiaChiQuanAn { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string IdNguoiDongGop { get; set; }
    }
}