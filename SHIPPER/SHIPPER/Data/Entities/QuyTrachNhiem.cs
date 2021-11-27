using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class QuyTrachNhiem
    {
        [Key]
        [Column("maNhanVien")]
        public Guid MaNhanVien { get; set; }
        [Key]
        [Column("maDonKhieuNai")]
        public int MaDonKhieuNai { get; set; }
        [Column("maQuanLy")]
        public Guid MaQuanLy { get; set; }

        [ForeignKey(nameof(MaDonKhieuNai))]
        [InverseProperty(nameof(DonKhieuNai.QuyTrachNhiem))]
        public virtual DonKhieuNai MaDonKhieuNaiNavigation { get; set; }
        [ForeignKey(nameof(MaNhanVien))]
        [InverseProperty(nameof(NhanVien.QuyTrachNhiem))]
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        [ForeignKey(nameof(MaQuanLy))]
        [InverseProperty(nameof(QuanLi.QuyTrachNhiem))]
        public virtual QuanLi MaQuanLyNavigation { get; set; }
    }
}
