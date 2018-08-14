using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestProject3
{
    public partial class PizzaPalacedbContext : DbContext
    {
        public PizzaPalacedbContext()
        {
        }

        public PizzaPalacedbContext(DbContextOptions<PizzaPalacedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room", "Pizzeria");

                entity.Property(e => e.Address)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("Users", "Pizzeria");

                entity.Property(e => e.Address)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });
        }
    }
}
