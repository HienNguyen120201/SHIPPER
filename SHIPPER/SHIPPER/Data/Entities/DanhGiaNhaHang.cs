using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class DanhGiaNhaHang
    {
        [Key]
        [Column("maNhaHang")]
        public int MaNhaHang { get; set; }
        [Key]
        [Column("maKhachHang")]
        public Guid MaKhachHang { get; set; }
        [Key]
        [Column("ngayDanhGia", TypeName = "datetime")]
        public DateTime NgayDanhGia { get; set; }
        [Column("moTa")]
        [StringLength(300)]
        public string MoTa { get; set; }
        [Column("rating")]
        public int Rating { get; set; }

        [ForeignKey(nameof(MaKhachHang))]
        [InverseProperty(nameof(KhachHang.DanhGiaNhaHang))]
        public virtual KhachHang MaKhachHangNavigation { get; set; }
        [ForeignKey(nameof(MaNhaHang))]
        [InverseProperty(nameof(NhaHang.DanhGiaNhaHang))]
        public virtual NhaHang MaNhaHangNavigation { get; set; }
    }
}
