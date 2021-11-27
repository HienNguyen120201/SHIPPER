using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class UuDai
    {
        [Column("maNhaHang")]
        public int? MaNhaHang { get; set; }
        [Key]
        [Column("maMonAn")]
        public int MaMonAn { get; set; }
        [Key]
        [Column("tenUuDai")]
        [StringLength(200)]
        public string TenUuDai { get; set; }
        [Column("discount", TypeName = "decimal(3, 2)")]
        public decimal? Discount { get; set; }
        [Column("moTa")]
        [StringLength(300)]
        public string MoTa { get; set; }
        [Column("ngayHetHan", TypeName = "datetime")]
        public DateTime? NgayHetHan { get; set; }

        [ForeignKey(nameof(MaMonAn))]
        [InverseProperty(nameof(MonAn.UuDai))]
        public virtual MonAn MaMonAnNavigation { get; set; }
        [ForeignKey(nameof(MaNhaHang))]
        [InverseProperty(nameof(NhaHang.UuDai))]
        public virtual NhaHang MaNhaHangNavigation { get; set; }
    }
}
