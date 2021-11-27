using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class QuanLi
    {
        public QuanLi()
        {
            ChiNhanh = new HashSet<ChiNhanh>();
            DonKhieuNai = new HashSet<DonKhieuNai>();
            QuyTrachNhiem = new HashSet<QuyTrachNhiem>();
        }

        [Key]
        [Column("maNhanVien")]
        public Guid MaNhanVien { get; set; }

        [ForeignKey(nameof(MaNhanVien))]
        [InverseProperty(nameof(NhanVien.QuanLi))]
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        [InverseProperty("MaNvquanLyNavigation")]
        public virtual ICollection<ChiNhanh> ChiNhanh { get; set; }
        [InverseProperty("MaQuanLyKiemDuyetNavigation")]
        public virtual ICollection<DonKhieuNai> DonKhieuNai { get; set; }
        [InverseProperty("MaQuanLyNavigation")]
        public virtual ICollection<QuyTrachNhiem> QuyTrachNhiem { get; set; }
    }
}
