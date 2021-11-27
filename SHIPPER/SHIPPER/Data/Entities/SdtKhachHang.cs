using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class SdtKhachHang
    {
        [Key]
        [Column("maKhachHang")]
        public Guid MaKhachHang { get; set; }
        [Key]
        [Column("SDT")]
        [StringLength(11)]
        public string Sdt { get; set; }

        [ForeignKey(nameof(MaKhachHang))]
        [InverseProperty(nameof(KhachHang.SdtKhachHang))]
        public virtual KhachHang MaKhachHangNavigation { get; set; }
    }
}
