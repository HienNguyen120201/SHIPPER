using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHIPPER.Data.Entities
{
    public partial class TrangThaiDon
    {
        public TrangThaiDon()
        {
            DonVanChuyen = new HashSet<DonVanChuyen>();
        }

        [Key]
        [Column("maTrangThai")]
        public int MaTrangThai { get; set; }
        [Required]
        [Column("trangThai")]
        [StringLength(30)]
        public string TrangThai { get; set; }

        [InverseProperty("MaTrangThaiDonHangNavigation")]
        public virtual ICollection<DonVanChuyen> DonVanChuyen { get; set; }
    }
}
