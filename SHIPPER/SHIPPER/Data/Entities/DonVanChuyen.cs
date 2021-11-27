using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class DonVanChuyen
    {
        public DonVanChuyen()
        {
            DonKhuyenMai = new HashSet<DonKhuyenMai>();
        }

        [Key]
        [Column("maDon")]
        public int MaDon { get; set; }
        [Column("diaChiGiaoHang")]
        [StringLength(100)]
        public string DiaChiGiaoHang { get; set; }
        [Column("thoiGianGiaoHang", TypeName = "datetime")]
        public DateTime? ThoiGianGiaoHang { get; set; }
        [Column("thoiGianNhan", TypeName = "datetime")]
        public DateTime? ThoiGianNhan { get; set; }
        [Column("maTrangThaiDonHang")]
        public int? MaTrangThaiDonHang { get; set; }
        [Column("tienShip")]
        public int? TienShip { get; set; }
        [Column("maPhuongThucThanhToan")]
        public int? MaPhuongThucThanhToan { get; set; }
        [Column("maKhachHang")]
        public Guid? MaKhachHang { get; set; }

        [ForeignKey(nameof(MaKhachHang))]
        [InverseProperty(nameof(KhachHang.DonVanChuyen))]
        public virtual KhachHang MaKhachHangNavigation { get; set; }
        [ForeignKey(nameof(MaPhuongThucThanhToan))]
        [InverseProperty(nameof(PhuongThucThanhToan.DonVanChuyen))]
        public virtual PhuongThucThanhToan MaPhuongThucThanhToanNavigation { get; set; }
        [ForeignKey(nameof(MaTrangThaiDonHang))]
        [InverseProperty(nameof(TrangThaiDon.DonVanChuyen))]
        public virtual TrangThaiDon MaTrangThaiDonHangNavigation { get; set; }
        [InverseProperty("MaDonNavigation")]
        public virtual DonGiaoHangGiup DonGiaoHangGiup { get; set; }
        [InverseProperty("MaDonNavigation")]
        public virtual DonMonAn DonMonAn { get; set; }
        [InverseProperty("MaDonNavigation")]
        public virtual NhanGiaoHangDvcPtSp NhanGiaoHangDvcPtSp { get; set; }
        [InverseProperty("MaDonNavigation")]
        public virtual ICollection<DonKhuyenMai> DonKhuyenMai { get; set; }
    }
}
