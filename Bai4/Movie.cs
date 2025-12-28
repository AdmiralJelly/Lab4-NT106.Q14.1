using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4 // 
{
    public class Movie
    {
        public string Title { get; set; }       // Tên phim
        public string ImageUrl { get; set; }    // Đường dẫn hình ảnh
        public string DetailUrl { get; set; }   // Link chi tiết
        public string Description { get; set; } // Mô tả
        public string Director { get; set; }    // Đạo diễn
        public string Cast { get; set; }        // Diễn viên
        public string Genre { get; set; }       // Thể loại
        public string Duration { get; set; }    // Thời lượng
    }
}