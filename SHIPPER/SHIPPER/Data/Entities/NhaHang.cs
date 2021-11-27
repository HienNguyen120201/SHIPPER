using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class NhaHang
    {
        public NhaHang()
        {
            DanhGiaNhaHang = new HashSet<DanhGiaNhaHang>();
            MonAn = new HashSet<MonAn>();
            SdtnhaHang = new HashSet<SdtnhaHang>();
            UuDai = new HashSet<UuDai>();
        }

        [Key]
        [Column("maNhaHang")]
        public int MaNhaHang { get; set; }
        [Required]
        [Column("tenNhaHang")]
        [StringLength(50)]
        public string TenNhaHang { get; set; }
        [Required]
        [Column("diaChi")]
        [StringLength(50)]
        public string DiaChi { get; set; }
        [Column("maSoGPKD")]
        [StringLength(50)]
        public string MaSoGpkd { get; set; }
        [Column("taiKhoan")]
        [StringLength(50)]
        public string TaiKhoan { get; set; }
        [Column("matKhau")]
        [StringLength(50)]
        public string MatKhau { get; set; }
        [Column("hoChuNhaHang")]
        [StringLength(50)]
        public string HoChuNhaHang { get; set; }
        [Column("tenLotChuNhaHang")]
        [StringLength(50)]
        public string TenLotChuNhaHang { get; set; }
        [Column("tenChuNhaHang")]
        [StringLength(40)]
        public string TenChuNhaHang { get; set; }
        [Column("trangThaiNhaHang")]
        public bool? TrangThaiNhaHang { get; set; }
        [Column("rating", TypeName = "decimal(2, 1)")]
        public decimal? Rating { get; set; }

        [InverseProperty("MaNhaHangNavigation")]
        public virtual ICollection<DanhGiaNhaHang> DanhGiaNhaHang { get; set; }
        [InverseProperty("MaNhaHangOfferNavigation")]
        public virtual ICollection<MonAn> MonAn { get; set; }
        [InverseProperty("MaNhaHangNavigation")]
        public virtual ICollection<SdtnhaHang> SdtnhaHang { get; set; }
        [InverseProperty("MaNhaHangNavigation")]
        public virtual ICollection<UuDai> UuDai { get; set; }
    }
}
