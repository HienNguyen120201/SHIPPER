using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class Shipper
    {
        public Shipper()
        {
            DanhGiaShipper = new HashSet<DanhGiaShipper>();
            NhanGiaoHangDvcPtSp = new HashSet<NhanGiaoHangDvcPtSp>();
        }

        [Key]
        [Column("maNhanVien")]
        public Guid MaNhanVien { get; set; }
        [Column("trangThai")]
        public bool? TrangThai { get; set; }
        [Column("rating", TypeName = "decimal(2, 1)")]
        public decimal? Rating { get; set; }
        [Required]
        [Column("soGPLX")]
        [StringLength(50)]
        public string SoGplx { get; set; }
        [Required]
        [Column("bienKiemSoat")]
        [StringLength(20)]
        public string BienKiemSoat { get; set; }

        [ForeignKey(nameof(BienKiemSoat))]
        [InverseProperty(nameof(PhuongTien.Shipper))]
        public virtual PhuongTien BienKiemSoatNavigation { get; set; }
        [ForeignKey(nameof(MaNhanVien))]
        [InverseProperty(nameof(NhanVien.Shipper))]
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        [InverseProperty("MaShipperNavigation")]
        public virtual ICollection<DanhGiaShipper> DanhGiaShipper { get; set; }
        [InverseProperty("MaShipperNavigation")]
        public virtual ICollection<NhanGiaoHangDvcPtSp> NhanGiaoHangDvcPtSp { get; set; }
    }
}
