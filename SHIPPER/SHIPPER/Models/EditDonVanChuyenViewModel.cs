using System;

namespace SHIPPER.Models
{
    public class EditDonVanChuyenViewModel
    {
        public int ID { get; set; }
        public string Add { get; set; }
        public DateTime Giao { get; set; }
        public DateTime Nhan { get; set; }
        public int TienShip { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string TrangThai { get; set; }
        public string CCCD { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string TenLot { get; set; }
        public string Action {  get; set; }
        public int maTrangThai {  get; set; }
    }
}
