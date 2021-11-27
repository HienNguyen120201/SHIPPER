using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class NhanVienChiNhanh
    {
        [Key]
        [Column("maNhanVien")]
        public Guid MaNhanVien { get; set; }
        [Column("maDonVi")]
        public int MaDonVi { get; set; }

        [ForeignKey(nameof(MaDonVi))]
        [InverseProperty(nameof(ChiNhanh.NhanVienChiNhanh))]
        public virtual ChiNhanh MaDonViNavigation { get; set; }
        [ForeignKey(nameof(MaNhanVien))]
        [InverseProperty(nameof(NhanVien.NhanVienChiNhanh))]
        public virtual NhanVien MaNhanVienNavigation { get; set; }
    }
}
