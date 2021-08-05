using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _40K.Models
{
    public partial class WarhammerContext : DbContext
    {

        public WarhammerContext(DbContextOptions<WarhammerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Armies> Armies { get; set; }
        public virtual DbSet<Factions> Factions { get; set; }
        public virtual DbSet<_40K.Models.Units> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Armies>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FactionID).HasColumnName("FactionID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Factions>(entity =>
            {
                entity.ToTable("factions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.ToTable("units");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArmyID).HasColumnName("ArmyID");

                entity.Property(e => e.Name)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SessionEnd).HasColumnType("datetime");

                entity.Property(e => e.SessionStart).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
