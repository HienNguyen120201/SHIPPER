using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class ChiNhanh
    {
        public ChiNhanh()
        {
            InverseMaChiNhanhChaNavigation = new HashSet<ChiNhanh>();
            NhanVienChiNhanh = new HashSet<NhanVienChiNhanh>();
        }

        [Key]
        [Column("maDonVi")]
        public int MaDonVi { get; set; }
        [Column("maSoThue")]
        public int? MaSoThue { get; set; }
        [Column("tenChiNhanh")]
        [StringLength(50)]
        public string TenChiNhanh { get; set; }
        [Column("diaChi")]
        [StringLength(50)]
        public string DiaChi { get; set; }
        [Column("maNVQuanLy")]
        public Guid? MaNvquanLy { get; set; }
        [Column("maChiNhanhCha")]
        public int? MaChiNhanhCha { get; set; }

        [ForeignKey(nameof(MaChiNhanhCha))]
        [InverseProperty(nameof(ChiNhanh.InverseMaChiNhanhChaNavigation))]
        public virtual ChiNhanh MaChiNhanhChaNavigation { get; set; }
        [ForeignKey(nameof(MaNvquanLy))]
        [InverseProperty(nameof(QuanLi.ChiNhanh))]
        public virtual QuanLi MaNvquanLyNavigation { get; set; }
        [InverseProperty(nameof(ChiNhanh.MaChiNhanhChaNavigation))]
        public virtual ICollection<ChiNhanh> InverseMaChiNhanhChaNavigation { get; set; }
        [InverseProperty("MaDonViNavigation")]
        public virtual ICollection<NhanVienChiNhanh> NhanVienChiNhanh { get; set; }
    }
}
