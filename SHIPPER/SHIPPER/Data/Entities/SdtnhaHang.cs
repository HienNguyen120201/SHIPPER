using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    [Table("SDTNhaHang")]
    public partial class SdtnhaHang
    {
        [Key]
        [Column("maNhaHang")]
        public int MaNhaHang { get; set; }
        [Key]
        [Column("soDienThoai")]
        [StringLength(11)]
        public string SoDienThoai { get; set; }

        [ForeignKey(nameof(MaNhaHang))]
        [InverseProperty(nameof(NhaHang.SdtnhaHang))]
        public virtual NhaHang MaNhaHangNavigation { get; set; }
    }
}
