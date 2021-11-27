using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DanhGiaNhaHang = new HashSet<DanhGiaNhaHang>();
            DanhGiaShipper = new HashSet<DanhGiaShipper>();
            DonVanChuyen = new HashSet<DonVanChuyen>();
            KhieuNai = new HashSet<KhieuNai>();
            MaKhuyenMai = new HashSet<MaKhuyenMai>();
            SdtKhachHang = new HashSet<SdtKhachHang>();
            TuVanGiaiDap = new HashSet<TuVanGiaiDap>();
        }

        [Key]
        [Column("maKhachHang")]
        public Guid MaKhachHang { get; set; }
        [Column("CCCDorVisa")]
        public int? CccdorVisa { get; set; }
        [Required]
        [Column("ho")]
        [StringLength(20)]
        public string Ho { get; set; }
        [Column("tenLot")]
        [StringLength(20)]
        public string TenLot { get; set; }
        [Required]
        [StringLength(20)]
        public string Ten { get; set; }
        [Column("ngaySinh", TypeName = "date")]
        public DateTime? NgaySinh { get; set; }
        [Column("gioiTinh")]
        [StringLength(10)]
        public string GioiTinh { get; set; }
        [Column("taiKhoan")]
        [StringLength(20)]
        public string TaiKhoan { get; set; }
        [Column("matKhau")]
        [StringLength(20)]
        public string MatKhau { get; set; }
        [Column("diaChi")]
        [StringLength(50)]
        public string DiaChi { get; set; }
        [Column("ngayThamGia", TypeName = "datetime")]
        public DateTime? NgayThamGia { get; set; }
        [Column("loaiKhachHang")]
        [StringLength(20)]
        public string LoaiKhachHang { get; set; }
        [Column("soDonBiHuyDoKhachHang")]
        public int? SoDonBiHuyDoKhachHang { get; set; }
        [Column("soDonDaDat")]
        public int? SoDonDaDat { get; set; }

        [InverseProperty("MaKhachHangNavigation")]
        public virtual ICollection<DanhGiaNhaHang> DanhGiaNhaHang { get; set; }
        [InverseProperty("MaKhachHangNavigation")]
        public virtual ICollection<DanhGiaShipper> DanhGiaShipper { get; set; }
        [InverseProperty("MaKhachHangNavigation")]
        public virtual ICollection<DonVanChuyen> DonVanChuyen { get; set; }
        [InverseProperty("MaKhachHangNavigation")]
        public virtual ICollection<KhieuNai> KhieuNai { get; set; }
        [InverseProperty("MaKhachHangSoHuuNavigation")]
        public virtual ICollection<MaKhuyenMai> MaKhuyenMai { get; set; }
        [InverseProperty("MaKhachHangNavigation")]
        public virtual ICollection<SdtKhachHang> SdtKhachHang { get; set; }
        [InverseProperty("MaKhachHangNavigation")]
        public virtual ICollection<TuVanGiaiDap> TuVanGiaiDap { get; set; }
    }
}
