using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class TongDaiVien
    {
        public TongDaiVien()
        {
            KhieuNai = new HashSet<KhieuNai>();
            TuVanGiaiDap = new HashSet<TuVanGiaiDap>();
        }

        [Key]
        [Column("maNhanVien")]
        public Guid MaNhanVien { get; set; }

        [ForeignKey(nameof(MaNhanVien))]
        [InverseProperty(nameof(NhanVien.TongDaiVien))]
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        [InverseProperty("MaTongDaiVienNavigation")]
        public virtual ICollection<KhieuNai> KhieuNai { get; set; }
        [InverseProperty("MaTongDaiVienNavigation")]
        public virtual ICollection<TuVanGiaiDap> TuVanGiaiDap { get; set; }
    }
}
