using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class DonKhuyenMai
    {
        [Key]
        [Column("maKhuyenMai")]
        public int MaKhuyenMai { get; set; }
        [Column("maDon")]
        public int MaDon { get; set; }

        [ForeignKey(nameof(MaDon))]
        [InverseProperty(nameof(DonVanChuyen.DonKhuyenMai))]
        public virtual DonVanChuyen MaDonNavigation { get; set; }
        [ForeignKey(nameof(MaKhuyenMai))]
        [InverseProperty("DonKhuyenMai")]
        public virtual MaKhuyenMai MaKhuyenMaiNavigation { get; set; }
    }
}
