using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WPF_NTP_DERS_SINAV2
{
    public partial class VT2022_sinav2Context : DbContext
    {
        public VT2022_sinav2Context()
        {
        }

        public VT2022_sinav2Context(DbContextOptions<VT2022_sinav2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Hizmet> Hizmets { get; set; } = null!;
        public virtual DbSet<Islem> Islems { get; set; } = null!;
        public virtual DbSet<Kisi> Kisis { get; set; } = null!;
        public virtual DbSet<Kisitur> Kisiturs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VT2022_sinav2;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Islem>(entity =>
            {
                entity.Property(e => e.Odeme).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.HizmetNavigation)
                    .WithMany(p => p.Islems)
                    .HasForeignKey(d => d.Hizmet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Islem_Hizmet");

                entity.HasOne(d => d.MusteriNavigation)
                    .WithMany(p => p.IslemMusteriNavigations)
                    .HasForeignKey(d => d.Musteri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Islem_Musteri");

                entity.HasOne(d => d.PersonelNavigation)
                    .WithMany(p => p.IslemPersonelNavigations)
                    .HasForeignKey(d => d.Personel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Islem_Personel");
            });

            modelBuilder.Entity<Kisi>(entity =>
            {
                entity.Property(e => e.Tel).IsFixedLength();

                entity.Property(e => e.Tur).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.TurNavigation)
                    .WithMany(p => p.Kisis)
                    .HasForeignKey(d => d.Tur)
                    .HasConstraintName("FK_Kisi_Tur");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
