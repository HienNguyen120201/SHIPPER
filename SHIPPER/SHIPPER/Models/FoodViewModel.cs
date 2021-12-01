using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class FoodViewModel
    {
        public int MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public int DonGia { get; set; }
        public string MoTa { get; set; }
        public int MaNhaHang { get; set; }
        public string ImgUrl { get; set; }
        public bool check { get; set; }
        public DonVanChuyenViewModel DonVanChuyen { get; set; }
    }
}
