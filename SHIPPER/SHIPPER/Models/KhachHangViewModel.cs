using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class KhachHangViewModel
    {
        public int Cmnd { get; set; }
        public string Ho { get; set; }
        public string TenLot { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string ReMatKhau { get; set; }

    }
}
