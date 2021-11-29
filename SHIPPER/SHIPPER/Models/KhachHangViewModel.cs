using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class KhachHangViewModel
    {
        [Required(ErrorMessage = "Vui lòng điền họ")]
        public int Cmnd { get; set; }
        [Required(ErrorMessage = "Vui lòng điền họ")]
        [RegularExpression(@"^[a-zA-Z]$", ErrorMessage = "Tên chỉ được có chữ thường và chữ in hoa")]
        public string Ho { get; set; }
        [Required(ErrorMessage = "Vui lòng điền họ")]
        public string TenLot { get; set; }
        [Required(ErrorMessage = "Vui lòng điền họ")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "Vui lòng điền họ")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Vui lòng điền họ")]
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Vui lòng điền họ")]
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string ReMatKhau { get; set; }
        public string ErrorMessage { get; set; }

    }
}
