using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class KhieuNai
    {
        [Key]
        [Column("maDonKhieuNai")]
        public int MaDonKhieuNai { get; set; }
        [Column("maTongDaiVien")]
        public Guid MaTongDaiVien { get; set; }
        [Column("maKhachHang")]
        public Guid MaKhachHang { get; set; }

        [ForeignKey(nameof(MaDonKhieuNai))]
        [InverseProperty(nameof(DonKhieuNai.KhieuNai))]
        public virtual DonKhieuNai MaDonKhieuNaiNavigation { get; set; }
        [ForeignKey(nameof(MaKhachHang))]
        [InverseProperty(nameof(KhachHang.KhieuNai))]
        public virtual KhachHang MaKhachHangNavigation { get; set; }
        [ForeignKey(nameof(MaTongDaiVien))]
        [InverseProperty(nameof(TongDaiVien.KhieuNai))]
        public virtual TongDaiVien MaTongDaiVienNavigation { get; set; }
    }
}
