using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class ChiTietDonMonAn
    {
        [Key]
        [Column("maDonMonAn")]
        public int MaDonMonAn { get; set; }
        [Key]
        [Column("maMonAn")]
        public int MaMonAn { get; set; }
        [Column("soLuong")]
        public int? SoLuong { get; set; }
        [Column("apDungUuDai")]
        public bool? ApDungUuDai { get; set; }
        [Column("donGiaMon")]
        public int? DonGiaMon { get; set; }
        [Column("donGiaUuDai")]
        public int? DonGiaUuDai { get; set; }

        [ForeignKey(nameof(MaDonMonAn))]
        [InverseProperty(nameof(DonMonAn.ChiTietDonMonAn))]
        public virtual DonMonAn MaDonMonAnNavigation { get; set; }
        [ForeignKey(nameof(MaMonAn))]
        [InverseProperty(nameof(MonAn.ChiTietDonMonAn))]
        public virtual MonAn MaMonAnNavigation { get; set; }
    }
}
