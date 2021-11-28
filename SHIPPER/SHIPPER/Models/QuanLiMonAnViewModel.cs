using System.Collections.Generic;

namespace SHIPPER.Models
{
    public class QuanLiMonAnViewModel
    {
        public List<MonAnViewModel> listMonAn { get; set; }
        public List<TongSoMonAnViewModel> listTongSoMonAn { get; set; }
        public int IdNhaHang { get; set; }
        public int IdMonAn { get; set; }
        public string Type {  get; set; }
        public string Add { get; set; }
        public string NameMonAn {  get; set; }
        public int Price {  get; set; }
        public string Description {  get; set; }
        public string ImgUrl {  get; set; }
    }
    public class MonAnViewModel
    {
        public string NameNhaHang {  get; set; }
        public string NameMonAn {  get; set; }
        public int IdNhaHang {  get; set; }
        public int IdMonAn {  get; set; }
        public string Url {  get; set; }
        public int DonGia {  get; set; }
        public int isActive {  get; set; }
        public string Add {  get; set; }
    }
    public class TongSoMonAnViewModel
    {
        public string NameNhaHang {  get; set; }
        public string TongSoMonAn {  get; set; }
    }
}
