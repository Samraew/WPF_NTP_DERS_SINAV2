using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_NTP_DERS_SINAV2
{
    [Table("Kisi")]
    public partial class Kisi
    {
        public Kisi()
        {
            IslemMusteriNavigations = new HashSet<Islem>();
            IslemPersonelNavigations = new HashSet<Islem>();
        }

        [Key]
        public int Id { get; set; }
        [Column("ad")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Ad { get; set; }
        [Column("soyad")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Soyad { get; set; }
        [Column("tel")]
        [StringLength(11)]
        public string? Tel { get; set; }
        [Column("mail")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Mail { get; set; }
        [Column("adres")]
        [Unicode(false)]
        public string? Adres { get; set; }
        [Column("tur")]
        public int? Tur { get; set; }

        [ForeignKey("Tur")]
        [InverseProperty("Kisis")]
        public virtual Kisitur? TurNavigation { get; set; }
        [InverseProperty("MusteriNavigation")]
        public virtual ICollection<Islem> IslemMusteriNavigations { get; set; }
        [InverseProperty("PersonelNavigation")]
        public virtual ICollection<Islem> IslemPersonelNavigations { get; set; }
    }
}
