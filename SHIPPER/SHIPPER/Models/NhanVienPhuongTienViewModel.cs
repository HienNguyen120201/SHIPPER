using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class NhanVienPhuongTienViewModel
    {
        public string Ho { get; set; }
        public string TenLot { get; set; }
        public string Ten { get; set; }
        public string SoGPLX { get; set; }
        public string BienKiemSoat { get; set; }
        public Decimal Rating { get; set; }
        public string ImgUrl { get; set; }
        public bool check { get; set; }
    }
}
