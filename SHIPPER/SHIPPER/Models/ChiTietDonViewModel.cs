using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class ChiTietDonViewModel
    {
        public int MaMonAn { get; set; }
        public int MaDonMonAn { get; set; }
        public int SoLuong { get; set; }
        public bool ApDungUuDai { get; set; }
        public int DonGiaMon { get; set; }
        public int DonGiaUuDai { get; set; }
        public string ImgUrl { get; set; }
        public string TenMonAn { get; set; }
    }
}
