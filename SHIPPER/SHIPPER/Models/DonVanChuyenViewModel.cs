using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class DonVanChuyenViewModel
    {
        public string DiaChiGiaoHang { get; set; }
        public DateTime ThoiGianGiaoHang { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public int MaTrangThaiDonHang { get; set; }
        public int TienShip { get; set; }
        public int MaPhuongThucThanhToan { get; set; }
        public Guid MaKhachHang { get; set; }
    }
}
