using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using HtmlAgilityPack; // Thư viện để phân tích HTML lấy ảnh

namespace Lab4_Bai3
{
    public partial class Form1 : Form
    {
        private WebView2 webView;

        public Form1()
        {
            InitializeComponent();
            // Khởi tạo WebView2
            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            panelWeb.Controls.Add(webView);
            InitializeWebView();
        }

        async void InitializeWebView()
        {
            await webView.EnsureCoreWebView2Async(null);
        }

        // 1. Load Website
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView != null && webView.CoreWebView2 != null)
                    webView.CoreWebView2.Navigate(txtUrl.Text);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi URL: " + ex.Message); }
        }

        // 2. Download File HTML
        private void btnDownFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "HTML File|*.html";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(txtUrl.Text, sfd.FileName);
                        MessageBox.Show("Đã lưu file thành công!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // 3. Download Resources (Tải toàn bộ ảnh)
        private void btnDownResources_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string saveDir = fbd.SelectedPath;
                    string url = txtUrl.Text;

                    // Dùng HtmlAgilityPack tải HTML về để quét thẻ <img>
                    HtmlWeb web = new HtmlWeb();
                    var doc = web.Load(url);
                    var imgNodes = doc.DocumentNode.SelectNodes("//img");

                    if (imgNodes == null) { MessageBox.Show("Không tìm thấy ảnh nào."); return; }

                    int count = 0;
                    using (WebClient client = new WebClient())
                    {
                        foreach (var node in imgNodes)
                        {
                            string src = node.GetAttributeValue("src", "");
                            if (string.IsNullOrEmpty(src)) continue;

                            // Xử lý đường dẫn tương đối thành tuyệt đối
                            Uri baseUri = new Uri(url);
                            Uri fullUri = new Uri(baseUri, src);

                            string fileName = Path.GetFileName(fullUri.LocalPath);
                            if (string.IsNullOrEmpty(fileName)) fileName = "img" + count + ".jpg";

                            try
                            {
                                client.DownloadFile(fullUri, Path.Combine(saveDir, fileName));
                                count++;
                            }
                            catch { /* Bỏ qua ảnh lỗi */ }
                        }
                    }
                    MessageBox.Show($"Đã tải xong {count} ảnh!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // 4. View Source
        private void btnViewSource_Click(object sender, EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string html = client.DownloadString(txtUrl.Text);
                    // Hiển thị source trong cửa sổ mới
                    Form frmSource = new Form();
                    frmSource.Size = new System.Drawing.Size(800, 600);
                    RichTextBox rtb = new RichTextBox { Dock = DockStyle.Fill, Text = html };
                    frmSource.Controls.Add(rtb);
                    frmSource.Show();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}