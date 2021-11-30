using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Models
{
    public class KhachHangViewModel
    {
        [Required(ErrorMessage = "Vui lòng điền Chứng minh hoặc căn cước")]
        public int Cmnd { get; set; }
        [Required(ErrorMessage = "Vui lòng điền Họ")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Họ chỉ được có chữ thường và chữ in hoa")]
        public string Ho { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Tên lót chỉ được có chữ thường và chữ in hoa")]
        public string TenLot { get; set; }
        [Required(ErrorMessage = "Vui lòng điền Tên")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Tên chỉ được có chữ thường và chữ in hoa")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "Vui lòng điền Ngày Sinh")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Vui lòng điền Giới Tính")]
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Vui lòng điền Tài Khoản")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Vui lòng điền Mật Khẩu")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8-20 kí tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@~%&]).{8,20}$", ErrorMessage = "Mật khẩu phải có ít nhất một ký tự in hoa, số và ký tự đặc biệt và không có khoảng cách")]
        public string MatKhau { get; set; }
        [Required(ErrorMessage = "Vui lòng điền Nhập lại mật khẩu")]
        public string ReMatKhau { get; set; }
        public string ErrorMessage { get; set; }

    }
}
