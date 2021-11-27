using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class DonGiaoHangGiup
    {
        public DonGiaoHangGiup()
        {
            HangVanChuyen = new HashSet<HangVanChuyen>();
        }

        [Key]
        [Column("maDon")]
        public int MaDon { get; set; }
        [Column("tenNguoiNhan")]
        [StringLength(50)]
        public string TenNguoiNhan { get; set; }
        [Required]
        [Column("soDienThoaiNguoiNhan")]
        [StringLength(50)]
        public string SoDienThoaiNguoiNhan { get; set; }
        [Required]
        [Column("diaChiNhan")]
        [StringLength(100)]
        public string DiaChiNhan { get; set; }
        [Column("chiTietChoGiao")]
        [StringLength(255)]
        public string ChiTietChoGiao { get; set; }
        [Column("dichVuDonHang")]
        [StringLength(255)]
        public string DichVuDonHang { get; set; }
        [Column("dichVuThem")]
        [StringLength(255)]
        public string DichVuThem { get; set; }
        [Column("ghiChuChoShipper")]
        [StringLength(255)]
        public string GhiChuChoShipper { get; set; }
        [Column("tongKhoiLuong")]
        public double? TongKhoiLuong { get; set; }

        [ForeignKey(nameof(MaDon))]
        [InverseProperty(nameof(DonVanChuyen.DonGiaoHangGiup))]
        public virtual DonVanChuyen MaDonNavigation { get; set; }
        [InverseProperty("MaDonGiaoGiupNavigation")]
        public virtual ICollection<HangVanChuyen> HangVanChuyen { get; set; }
    }
}
