using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_NTP_DERS_SINAV2
{
    [Table("Kisitur")]
    public partial class Kisitur
    {
        public Kisitur()
        {
            Kisis = new HashSet<Kisi>();
        }

        [Key]
        public int Id { get; set; }
        [Column("tur")]
        [StringLength(50)]
        [Unicode(false)]
        public string Tur { get; set; } = null!;

        [InverseProperty("TurNavigation")]
        public virtual ICollection<Kisi> Kisis { get; set; }
    }
}
