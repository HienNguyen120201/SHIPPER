using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class DonKhieuNai
    {
        public DonKhieuNai()
        {
            QuyTrachNhiem = new HashSet<QuyTrachNhiem>();
        }

        [Key]
        [Column("maDonKhieuNai")]
        public int MaDonKhieuNai { get; set; }
        [Column("noiDung")]
        [StringLength(500)]
        public string NoiDung { get; set; }
        [Column("maQuanLyKiemDuyet")]
        public Guid? MaQuanLyKiemDuyet { get; set; }
        [Required]
        [Column("vanDe")]
        [StringLength(50)]
        public string VanDe { get; set; }

        [ForeignKey(nameof(MaQuanLyKiemDuyet))]
        [InverseProperty(nameof(QuanLi.DonKhieuNai))]
        public virtual QuanLi MaQuanLyKiemDuyetNavigation { get; set; }
        [InverseProperty("MaDonKhieuNaiNavigation")]
        public virtual KhieuNai KhieuNai { get; set; }
        [InverseProperty("MaDonKhieuNaiNavigation")]
        public virtual ICollection<QuyTrachNhiem> QuyTrachNhiem { get; set; }
    }
}
