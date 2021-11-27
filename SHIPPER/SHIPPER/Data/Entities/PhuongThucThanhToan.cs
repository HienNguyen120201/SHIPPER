using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class PhuongThucThanhToan
    {
        public PhuongThucThanhToan()
        {
            DonVanChuyen = new HashSet<DonVanChuyen>();
        }

        [Key]
        [Column("maPhuongThuc")]
        public int MaPhuongThuc { get; set; }
        [Required]
        [Column("phuongThucThanhToan")]
        [StringLength(30)]
        public string PhuongThucThanhToan1 { get; set; }

        [InverseProperty("MaPhuongThucThanhToanNavigation")]
        public virtual ICollection<DonVanChuyen> DonVanChuyen { get; set; }
    }
}
