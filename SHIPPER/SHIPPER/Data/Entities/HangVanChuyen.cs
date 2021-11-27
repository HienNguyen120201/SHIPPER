using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class HangVanChuyen
    {
        [Key]
        [Column("maDonGiaoGiup")]
        public int MaDonGiaoGiup { get; set; }
        [Key]
        [Column("maHang")]
        public int MaHang { get; set; }
        [Column("moTa")]
        [StringLength(300)]
        public string MoTa { get; set; }
        [Column("tongKhoiLuong")]
        public int? TongKhoiLuong { get; set; }
        [StringLength(20)]
        public string LoaiHang { get; set; }

        [ForeignKey(nameof(MaDonGiaoGiup))]
        [InverseProperty(nameof(DonGiaoHangGiup.HangVanChuyen))]
        public virtual DonGiaoHangGiup MaDonGiaoGiupNavigation { get; set; }
    }
}
