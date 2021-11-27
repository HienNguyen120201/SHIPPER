using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class MaKhuyenMai
    {
        [Key]
        [Column("maKhuyenMai")]
        public int MaKhuyenMai1 { get; set; }
        [Column("discount")]
        public double? Discount { get; set; }
        [Column("dieuKienApDung")]
        [StringLength(200)]
        public string DieuKienApDung { get; set; }
        [Column("ngayHetHan", TypeName = "datetime")]
        public DateTime? NgayHetHan { get; set; }
        [Column("moTa")]
        [StringLength(200)]
        public string MoTa { get; set; }
        [Column("maKhachHangSoHuu")]
        public Guid? MaKhachHangSoHuu { get; set; }
        [Column("daDungChua")]
        public bool? DaDungChua { get; set; }

        [ForeignKey(nameof(MaKhachHangSoHuu))]
        [InverseProperty(nameof(KhachHang.MaKhuyenMai))]
        public virtual KhachHang MaKhachHangSoHuuNavigation { get; set; }
        [InverseProperty("MaKhuyenMaiNavigation")]
        public virtual DonKhuyenMai DonKhuyenMai { get; set; }
    }
}
