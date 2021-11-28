using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class ThongTinUuDaiViewModel
    {
        public string TenMonAn { get; set; }
        public int DonGia { get; set; }
        public int GiaUuDai { get; set; }
        public string TenUuDai { get; set; }
        public double Discount { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayHetHan { get; set; }
    }
}
