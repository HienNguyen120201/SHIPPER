using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            QuyTrachNhiem = new HashSet<QuyTrachNhiem>();
        }

        [Key]
        [Column("maNhanVien")]
        public Guid MaNhanVien { get; set; }
        [Required]
        [Column("ho")]
        [StringLength(20)]
        public string Ho { get; set; }
        [Column("tenLot")]
        [StringLength(20)]
        public string TenLot { get; set; }
        [Required]
        [Column("ten")]
        [StringLength(20)]
        public string Ten { get; set; }
        [Column("ngayVaoLam", TypeName = "date")]
        public DateTime? NgayVaoLam { get; set; }
        [Column("luong", TypeName = "decimal(18, 0)")]
        public decimal? Luong { get; set; }
        [Column("taiKhoan")]
        [StringLength(50)]
        public string TaiKhoan { get; set; }
        [Column("matKhau")]
        [StringLength(50)]
        public string MatKhau { get; set; }
        [Column("loaiNhanVien")]
        [StringLength(20)]
        public string LoaiNhanVien { get; set; }
        [Column("chiSoUyTin", TypeName = "decimal(2, 1)")]
        public decimal? ChiSoUyTin { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("ngaySinh", TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [InverseProperty("MaNhanVienNavigation")]
        public virtual NhanVienChiNhanh NhanVienChiNhanh { get; set; }
        [InverseProperty("MaNhanVienNavigation")]
        public virtual QuanLi QuanLi { get; set; }
        [InverseProperty("MaNhanVienNavigation")]
        public virtual Shipper Shipper { get; set; }
        [InverseProperty("MaNhanVienNavigation")]
        public virtual TongDaiVien TongDaiVien { get; set; }
        [InverseProperty("MaNhanVienNavigation")]
        public virtual ICollection<QuyTrachNhiem> QuyTrachNhiem { get; set; }
    }
}
