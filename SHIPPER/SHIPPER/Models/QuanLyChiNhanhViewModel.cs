using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class QuanLyChiNhanhViewModel
    {
        public List<ChiNhanhViewModel> ListChiNhanh { get; set; }
        public List<QuanLyViewModel> ListQuanLy { get; set; }
        public ChiNhanhViewModel ChiNhanh { get; set; }
    }
    public class ChiNhanhViewModel
    {
        [Required()]
        public int MaChiNhanh { get; set; }
        [Required()]
        public string TenChiNhanh { get; set; }
        [Required()]
        public int MaSoThue { get; set; }
        [Required()]
        public string DiaChi { get; set; }
        [Required()]
        public Guid MaNhanVienQuanLy { get; set; }
        [Required()]
        public int MaChiNhanhCha { get; set; }
        [Required()]
        public int SoLuongNhanVien { get; set; }
        public bool TrangThai { get; set; }
    }
    public class QuanLyViewModel
    {
        public Guid MaNhanVienQuanLy { get; set; }
        public string HoVaTen { get; set; }
        public int Luong { get; set; }
        public DateTime NgaySinh { get; set; }
        public string LoaiNhanVien { get; set; }
    }
    public class MaQuanLyViewModel
    {
        public Guid MaNhanVienQuanLy { get; set; }
    }
}
