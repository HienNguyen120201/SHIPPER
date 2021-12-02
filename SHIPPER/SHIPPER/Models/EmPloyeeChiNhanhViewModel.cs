using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class EmPloyeeChiNhanhViewModel
    {
        public List<EmployeeNowork> ListEmployeeNowork { get; set; }
        public List<DonVi> ListDonVi { get; set; }
        public InsertNhanVienChiNhanh InsertNVCN { get; set; }
    }
    public class UpdateEmployeeViewModel
    {
        public List<DonVi> ListDonVi { get; set; }
        public InsertNhanVienChiNhanh InsertNVCN { get; set; }
    }
    public class EmployeeNowork
    {
        public Guid MaNhanVien { get; set; }
        public string Hovaten { get; set; }
        public int Luong { get; set; }
        public string Loainhanvien { get; set; }
        public bool TrangThai { get; set; }
    }
    public class DonVi
    {
        public int MaDonVi { get; set; }
        public string TenChiNhanh { get; set; }
        public int MaSoThue { get; set; }
        public string DiaChi { get; set; }
        public int SoLuongNhanVien { get; set; }
    }
    public class InsertNhanVienChiNhanh
    {
        public Guid MaNhanVien { get; set; }
        public int MaDonVi { get; set; }
    }
}
