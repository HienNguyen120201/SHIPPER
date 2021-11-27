using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class TuVanGiaiDap
    {
        [Key]
        [Column("maTongDaiVien")]
        public Guid MaTongDaiVien { get; set; }
        [Key]
        [Column("maKhachHang")]
        public Guid MaKhachHang { get; set; }
        [Key]
        [Column("record")]
        [StringLength(100)]
        public string Record { get; set; }
        [Column("vanDe")]
        [StringLength(50)]
        public string VanDe { get; set; }

        [ForeignKey(nameof(MaKhachHang))]
        [InverseProperty(nameof(KhachHang.TuVanGiaiDap))]
        public virtual KhachHang MaKhachHangNavigation { get; set; }
        [ForeignKey(nameof(MaTongDaiVien))]
        [InverseProperty(nameof(TongDaiVien.TuVanGiaiDap))]
        public virtual TongDaiVien MaTongDaiVienNavigation { get; set; }
    }
}
