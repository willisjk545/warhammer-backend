﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _40K.Models;

namespace _40K.Models
{
    public partial class masterContext : DbContext
    {

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armies> Armies { get; set; }
        public virtual DbSet<Factions> Factions { get; set; }

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<_40K.Models.Units> Units { get; set; }
    }
}
