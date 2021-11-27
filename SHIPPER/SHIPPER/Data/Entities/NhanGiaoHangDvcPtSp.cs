using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    [Table("NhanGiaoHang_DVC_PT_SP")]
    public partial class NhanGiaoHangDvcPtSp
    {
        [Key]
        [Column("maDon")]
        public int MaDon { get; set; }
        [Column("maShipper")]
        public Guid MaShipper { get; set; }
        [Column("bienKiemSoatXeGiao")]
        [StringLength(20)]
        public string BienKiemSoatXeGiao { get; set; }

        [ForeignKey(nameof(BienKiemSoatXeGiao))]
        [InverseProperty(nameof(PhuongTien.NhanGiaoHangDvcPtSp))]
        public virtual PhuongTien BienKiemSoatXeGiaoNavigation { get; set; }
        [ForeignKey(nameof(MaDon))]
        [InverseProperty(nameof(DonVanChuyen.NhanGiaoHangDvcPtSp))]
        public virtual DonVanChuyen MaDonNavigation { get; set; }
        [ForeignKey(nameof(MaShipper))]
        [InverseProperty(nameof(Shipper.NhanGiaoHangDvcPtSp))]
        public virtual Shipper MaShipperNavigation { get; set; }
    }
}
