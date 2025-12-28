using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class FormB4 : Form
    {
        List<Movie> movies = new List<Movie>();
        private HttpClient httpClient;

        // Controls
        private Panel pnlMovieList;
        private Label lblListTitle;
        private WebBrowser webBrowser1;  // ← WebBrowser control

        public FormB4()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");

            // Tạo giao diện
            CreateMovieListPanel();
            CreateWebBrowserPanel();
        }
            
        private void CreateMovieListPanel()
        {
            // Panel list phim bên trái
            pnlMovieList = new Panel
            {
                Location = new Point(3, 16),
                Size = new Size(420, 563),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            lblListTitle = new Label
            {
                Text = "Phim Đang Chiếu",
                Location = new Point(5, 5),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 20, 60),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlMovieList.Controls.Add(lblListTitle);

            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(pnlMovieList);
            groupBox1.Size = new Size(430, 582);
        }

        private void CreateWebBrowserPanel()
        {
            // WebBrowser để hiển thị website thực
            webBrowser1 = new WebBrowser
            {
                Location = new Point(3, 16),
                Size = new Size(694, 563),
                Dock = DockStyle.Fill,
                ScriptErrorsSuppressed = true  // Tắt popup lỗi JS
            };

            // Clear groupBox2 và thêm WebBrowser
            groupBox2.Controls.Clear();
            groupBox2.Controls.Add(webBrowser1);
            groupBox2.Location = new Point(450, 63);
            groupBox2.Size = new Size(700, 582);
            groupBox2.Text = "Chi Tiết Phim (Website)";

            // Hiển thị trang chủ BetaCinemas
            webBrowser1.Navigate("https://betacinemas.vn");
        }

        private async void btn_GetMovies_Click(object sender, EventArgs e)
        {
            btn_GetMovies.Enabled = false;

            try
            {
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
                lbl_Status.Text = "Đang kết nối đến BetaCinemas...";
                lbl_Status.ForeColor = Color.Blue;

                // Clear list
                pnlMovieList.Controls.Clear();
                pnlMovieList.Controls.Add(lblListTitle);
                movies.Clear();

                string url = "https://betacinemas.vn/phim.htm";

                lbl_Status.Text = "Đang tải dữ liệu từ website...";
                progressBar1.Value = 10;

                HtmlWeb web = new HtmlWeb();
                var doc = await Task.Run(() => web.Load(url));

                progressBar1.Value = 20;
                lbl_Status.Text = "Đang phân tích dữ liệu...";

                // Thử các XPath khác nhau
                var movieNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'film-info') and contains(@class, 'film-xs-info')]");

                if (movieNodes == null || movieNodes.Count == 0)
                {
                    movieNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'film-info')]");
                }

                if (movieNodes == null || movieNodes.Count == 0)
                {
                    movieNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-3') and contains(@class, 'col-md-3')]");
                }

                if (movieNodes == null || movieNodes.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy phim. Sẽ load dữ liệu demo.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    LoadSampleData();
                    return;
                }

                progressBar1.Maximum = movieNodes.Count + 30;
                progressBar1.Value = 25;
                int count = 0;

                lbl_Status.Text = $"Đã tìm thấy {movieNodes.Count} phim. Đang xử lý...";

                foreach (var node in movieNodes)
                {
                    try
                    {
                        Movie movie = new Movie();

                        // Lấy tên phim
                        var titleNode = node.SelectSingleNode(".//h3//a[@class='name-film']")
                                     ?? node.SelectSingleNode(".//a[@class='name-film']")
                                     ?? node.SelectSingleNode(".//h3/a");

                        if (titleNode != null)
                        {
                            movie.Title = titleNode.InnerText.Trim();
                            string href = titleNode.GetAttributeValue("href", "");

                            if (!string.IsNullOrEmpty(href))
                            {
                                movie.DetailUrl = href.StartsWith("http")
                                    ? href
                                    : "https://betacinemas.vn" + href;
                            }
                        }

                        // Lấy hình ảnh
                        var imgNode = node.SelectSingleNode(".//img")
                                   ?? node.SelectSingleNode("../preceding-sibling::div//img")
                                   ?? node.SelectSingleNode("../..//img");

                        if (imgNode != null)
                        {
                            string imgSrc = imgNode.GetAttributeValue("src", "");
                            if (string.IsNullOrEmpty(imgSrc))
                                imgSrc = imgNode.GetAttributeValue("data-src", "");

                            if (!string.IsNullOrEmpty(imgSrc))
                            {
                                movie.ImageUrl = imgSrc.StartsWith("http")
                                    ? imgSrc
                                    : imgSrc.StartsWith("/")
                                        ? "https://betacinemas.vn" + imgSrc
                                        : "https://betacinemas.vn/" + imgSrc;
                            }
                        }

                        // Lấy thông tin chi tiết
                        var infoList = node.SelectSingleNode(".//ul[contains(@class, 'movie-info')]");
                        if (infoList != null)
                        {
                            var infoNodes = infoList.SelectNodes(".//li");
                            if (infoNodes != null)
                            {
                                foreach (var info in infoNodes)
                                {
                                    string text = info.InnerText.Trim();

                                    if (text.Contains("Thể loại"))
                                        movie.Genre = text.Replace("Thể loại:", "").Trim();

                                    if (text.Contains("Thời lượng"))
                                        movie.Duration = text.Replace("Thời lượng:", "").Trim();

                                    if (text.Contains("Đạo diễn"))
                                        movie.Director = text.Replace("Đạo diễn:", "").Trim();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(movie.Title))
                        {
                            movies.Add(movie);
                            AddMovieToList(movie);

                            count++;
                            progressBar1.Value = 25 + count;
                            lbl_Status.Text = $"Đã xử lý: {count}/{movieNodes.Count} phim";

                            Application.DoEvents();
                            await Task.Delay(30);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Lỗi xử lý phim: {ex.Message}");
                    }
                }

                SaveMoviesToJson();

                progressBar1.Value = progressBar1.Maximum;
                lbl_Status.Text = $"✅ Hoàn tất! Đã tải {movies.Count} phim.";
                lbl_Status.ForeColor = Color.Green;

                MessageBox.Show(
                    $"✅ Đã tải thành công {movies.Count} phim!\n\n💡 Click vào phim để xem chi tiết trên website.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
                lbl_Status.Text = "❌ Đã xảy ra lỗi!";
                lbl_Status.ForeColor = Color.Red;
            }
            finally
            {
                btn_GetMovies.Enabled = true;
            }
        }

        private void AddMovieToList(Movie movie)
        {
            // Panel cho mỗi phim
            Panel pnlMovie = new Panel
            {
                Size = new Size(400, 80),
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = movie
            };

            // Hover effect
            pnlMovie.MouseEnter += (s, e) => pnlMovie.BackColor = Color.FromArgb(255, 240, 245);
            pnlMovie.MouseLeave += (s, e) => pnlMovie.BackColor = Color.White;
            pnlMovie.Click += (s, e) => ShowMovieDetailInBrowser(movie);

            // PictureBox - poster nhỏ
            PictureBox pbPoster = new PictureBox
            {
                Location = new Point(5, 5),
                Size = new Size(60, 70),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray
            };

            if (!string.IsNullOrEmpty(movie.ImageUrl))
            {
                try
                {
                    pbPoster.LoadAsync(movie.ImageUrl);
                }
                catch { }
            }
            pbPoster.Click += (s, e) => ShowMovieDetailInBrowser(movie);

            // Label tên phim
            Label lblTitle = new Label
            {
                Text = movie.Title,
                Location = new Point(75, 8),
                Size = new Size(315, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 20, 60),
                AutoEllipsis = true
            };
            lblTitle.Click += (s, e) => ShowMovieDetailInBrowser(movie);

            // Label link
            LinkLabel lblLink = new LinkLabel
            {
                Text = movie.DetailUrl ?? "N/A",
                Location = new Point(75, 38),
                Size = new Size(315, 35),
                Font = new Font("Segoe UI", 7),
                LinkColor = Color.Blue,
                AutoEllipsis = true
            };
            lblLink.LinkClicked += (s, e) => ShowMovieDetailInBrowser(movie);

            pnlMovie.Controls.AddRange(new Control[] { pbPoster, lblTitle, lblLink });

            // Tính toán vị trí
            int yPos = 40 + (pnlMovieList.Controls.Count - 1) * 85;
            pnlMovie.Location = new Point(5, yPos);

            pnlMovieList.Controls.Add(pnlMovie);
        }

        private void ShowMovieDetailInBrowser(Movie movie)
        {
            try
            {
                if (!string.IsNullOrEmpty(movie.DetailUrl))
                {
                    // Hiển thị link chi tiết trong WebBrowser
                    webBrowser1.Navigate(movie.DetailUrl);

                    lbl_Status.Text = $"🎬 Đang tải: {movie.Title}...";
                    lbl_Status.ForeColor = Color.Blue;

                    // Update status khi load xong
                    webBrowser1.DocumentCompleted += (s, e) =>
                    {
                        if (e.Url.ToString() == movie.DetailUrl)
                        {
                            lbl_Status.Text = $"✅ Đã tải: {movie.Title}";
                            lbl_Status.ForeColor = Color.Green;
                        }
                    };
                }
                else
                {
                    MessageBox.Show(
                        "Không có link chi tiết cho phim này.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
                lbl_Status.Text = "❌ Lỗi khi tải trang web!";
                lbl_Status.ForeColor = Color.Red;
            }
        }

        private void SaveMoviesToJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output5.json");
                File.WriteAllText(filePath, json);
            }
            catch { }
        }

        private void LoadSampleData()
        {
            var sampleMovies = new List<Movie>
            {
                new Movie
                {
                    Title = "Lật Mặt 7: Một Điều Ước",
                    ImageUrl = "https://cdn.betacinemas.vn/media/movies/lat-mat-7-mot-dieu-uoc-500.jpg",
                    Genre = "Hành Động, Tâm Lý",
                    Duration = "138 phút",
                    Director = "Lý Hải",
                    Description = "Câu chuyện về gia đình...",
                    DetailUrl = "https://betacinemas.vn/phim/lat-mat-7-mot-dieu-uoc.htm"
                },
                new Movie
                {
                    Title = "Cái Giá Của Hạnh Phúc",
                    ImageUrl = "https://cdn.betacinemas.vn/media/movies/cai-gia-cua-hanh-phuc-500.jpg",
                    Genre = "Tâm Lý, Gia Đình",
                    Duration = "120 phút",
                    Director = "Trần Bửu Lộc",
                    Description = "Một tác phẩm về...",
                    DetailUrl = "https://betacinemas.vn/phim/cai-gia-cua-hanh-phuc.htm"
                },
                new Movie
                {
                    Title = "Thanh Xuân 18x2",
                    ImageUrl = "https://cdn.betacinemas.vn/media/movies/thanh-xuan-18x2-500.jpg",
                    Genre = "Tình Cảm",
                    Duration = "110 phút",
                    Director = "Fujii Michihiko",
                    Description = "Câu chuyện tình yêu...",
                    DetailUrl = "https://betacinemas.vn/phim/thanh-xuan-18x2.htm"
                }
            };

            movies.AddRange(sampleMovies);
            foreach (var movie in sampleMovies)
            {
                AddMovieToList(movie);
            }

            SaveMoviesToJson();

            lbl_Status.Text = $"📦 Đã tải {movies.Count} phim mẫu (Demo Mode)";
            lbl_Status.ForeColor = Color.Orange;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            httpClient?.Dispose();
            webBrowser1?.Dispose();
        }
    }
}