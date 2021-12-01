using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class ChiTietChiNhanhViewModel
    {
        public List<ShipperChiNhanhViewModel> ListShipperCN { get; set; }
        public List<ChiNhanhQLXViewModel> ListChiNhanhQLX { get; set; }
        public List <ShipperMaxLuongViewModel> ListShipperMaxLuong { get; set; }
        public List<ThongKeShipperViewModel> ListThongKe { get; set; }
    }
    public class ShipperChiNhanhViewModel
    {
        public string HovaTen { get; set; }
        public string LoaiNhanVien { get; set; }
        public int Luong { get; set; }
        public DateTime NgayVaoLam { get; set; }
    }
    public class ChiNhanhQLXViewModel
    {
        public int MaDonVi { get; set; }
        public string TenChiNhanh { get; set; }
        public int MaSoThue { get; set; }
        public string DiaChi { get; set; }
        public int SoLuongNhanVien { get; set; }
    }
    public class ShipperMaxLuongViewModel
    {
        public Guid MaNhanVien { get; set; }
        public string HovaTen { get; set; }
        public int Luong { get; set; }
        public DateTime Ngaysinh { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public int Madonvi { get; set; }
    }
    public class ThongKeShipperViewModel
    {
        public int MaDonVi { get; set; }
        public int SoluongShipper { get; set; }
    }

}
