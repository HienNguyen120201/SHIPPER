using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class MonAn
    {
        public MonAn()
        {
            ChiTietDonMonAn = new HashSet<ChiTietDonMonAn>();
            UuDai = new HashSet<UuDai>();
        }

        [Key]
        [Column("maMonAn")]
        public int MaMonAn { get; set; }
        [Required]
        [Column("tenMonAn")]
        [StringLength(50)]
        public string TenMonAn { get; set; }
        [Column("donGia")]
        public int DonGia { get; set; }
        [Column("moTa")]
        [StringLength(300)]
        public string MoTa { get; set; }
        [Column("maNhaHangOffer")]
        public int MaNhaHangOffer { get; set; }
        public int  isActive { get;set;  }

        [ForeignKey(nameof(MaNhaHangOffer))]
        [InverseProperty(nameof(NhaHang.MonAn))]
        public virtual NhaHang MaNhaHangOfferNavigation { get; set; }
        [InverseProperty("MaMonAnNavigation")]
        public virtual ICollection<ChiTietDonMonAn> ChiTietDonMonAn { get; set; }
        [InverseProperty("MaMonAnNavigation")]
        public virtual ICollection<UuDai> UuDai { get; set; }
    }
}
