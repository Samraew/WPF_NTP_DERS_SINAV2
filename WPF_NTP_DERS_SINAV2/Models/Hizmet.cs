using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_NTP_DERS_SINAV2
{
    [Table("Hizmet")]
    public partial class Hizmet
    {
        public Hizmet()
        {
            Islems = new HashSet<Islem>();
        }

        [Key]
        public int Id { get; set; }
        [Column("hizmetad")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Hizmetad { get; set; }
        [Column("fiyat")]
        public int? Fiyat { get; set; }

        [InverseProperty("HizmetNavigation")]
        public virtual ICollection<Islem> Islems { get; set; }
    }
}
