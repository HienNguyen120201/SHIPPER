using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class NhanVienChiNhanhViewModel
    {
        public string Hovaten { get; set; }
        public int Luong { get; set; }
        public DateTime Ngayvaolam { get; set; }
        public string Loainhanvien { get; set; }
        public bool TrangThai { get; set; }
    }
}
