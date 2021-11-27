using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class DonMonAn
    {
        public DonMonAn()
        {
            ChiTietDonMonAn = new HashSet<ChiTietDonMonAn>();
        }

        [Key]
        [Column("maDon")]
        public int MaDon { get; set; }
        [Column("tongTienMon")]
        public double? TongTienMon { get; set; }

        [ForeignKey(nameof(MaDon))]
        [InverseProperty(nameof(DonVanChuyen.DonMonAn))]
        public virtual DonVanChuyen MaDonNavigation { get; set; }
        [InverseProperty("MaDonMonAnNavigation")]
        public virtual ICollection<ChiTietDonMonAn> ChiTietDonMonAn { get; set; }
    }
}
