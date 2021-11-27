using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class PhuongTien
    {
        public PhuongTien()
        {
            NhanGiaoHangDvcPtSp = new HashSet<NhanGiaoHangDvcPtSp>();
            Shipper = new HashSet<Shipper>();
        }

        [Key]
        [Column("bienKiemSoat")]
        [StringLength(20)]
        public string BienKiemSoat { get; set; }
        [Column("loaiPhuongTien")]
        [StringLength(50)]
        public string LoaiPhuongTien { get; set; }
        [Column("hinhAnhXe")]
        [StringLength(255)]
        public string HinhAnhXe { get; set; }
        [Column("giayPhepSoHuuXe")]
        [StringLength(255)]
        public string GiayPhepSoHuuXe { get; set; }

        [InverseProperty("BienKiemSoatXeGiaoNavigation")]
        public virtual ICollection<NhanGiaoHangDvcPtSp> NhanGiaoHangDvcPtSp { get; set; }
        [InverseProperty("BienKiemSoatNavigation")]
        public virtual ICollection<Shipper> Shipper { get; set; }
    }
}
