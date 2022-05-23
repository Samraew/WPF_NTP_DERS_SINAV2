using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_NTP_DERS_SINAV2
{
    [Table("Islem")]
    public partial class Islem
    {
        [Key]
        public int Id { get; set; }
        [Column("hizmet")]
        public int Hizmet { get; set; }
        [Column("musteri")]
        public int Musteri { get; set; }
        [Column("personel")]
        public int Personel { get; set; }
        [Column("tarih")]
        [StringLength(10)]
        [Unicode(false)]
        public string Tarih { get; set; } = null!;
        [Column("odeme")]
        public bool? Odeme { get; set; }

        [ForeignKey("Hizmet")]
        [InverseProperty("Islems")]
        public virtual Hizmet HizmetNavigation { get; set; } = null!;
        [ForeignKey("Musteri")]
        [InverseProperty("IslemMusteriNavigations")]
        public virtual Kisi MusteriNavigation { get; set; } = null!;
        [ForeignKey("Personel")]
        [InverseProperty("IslemPersonelNavigations")]
        public virtual Kisi PersonelNavigation { get; set; } = null!;
    }
}
