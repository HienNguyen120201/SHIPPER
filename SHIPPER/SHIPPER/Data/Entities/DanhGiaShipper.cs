using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class DanhGiaShipper
    {
        [Key]
        [Column("maShipper")]
        public Guid MaShipper { get; set; }
        [Key]
        [Column("maKhachHang")]
        public Guid MaKhachHang { get; set; }
        [Key]
        [Column("ngayDanhGia", TypeName = "datetime")]
        public DateTime NgayDanhGia { get; set; }
        [Column("rating")]
        public int Rating { get; set; }
        [Column("moTa")]
        [StringLength(300)]
        public string MoTa { get; set; }

        [ForeignKey(nameof(MaKhachHang))]
        [InverseProperty(nameof(KhachHang.DanhGiaShipper))]
        public virtual KhachHang MaKhachHangNavigation { get; set; }
        [ForeignKey(nameof(MaShipper))]
        [InverseProperty(nameof(Shipper.DanhGiaShipper))]
        public virtual Shipper MaShipperNavigation { get; set; }
    }
}
