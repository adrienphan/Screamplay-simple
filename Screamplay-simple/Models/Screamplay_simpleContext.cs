using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Screamplay_simple.Models
{
    public partial class Screamplay_simpleContext : DbContext
    {
        public Screamplay_simpleContext()
        {
        }

        public Screamplay_simpleContext(DbContextOptions<Screamplay_simpleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<RealWorldLocation> RealWorldLocations { get; set; } = null!;
        public virtual DbSet<Screenplay> Screenplays { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Screamplay_simple;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Character");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.IdScreenplay).HasColumnName("Id_Screenplay");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdScreenplayNavigation)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.IdScreenplay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Character_Screenplay_FK");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.IdScreenplay).HasColumnName("Id_Screenplay");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdScreenplayNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.IdScreenplay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_Screenplay_FK");

                entity.HasMany(d => d.IdCharacters)
                    .WithMany(p => p.Ids)
                    .UsingEntity<Dictionary<string, object>>(
                        "Concerner",
                        l => l.HasOne<Character>().WithMany().HasForeignKey("IdCharacter").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Concerner_Character0_FK"),
                        r => r.HasOne<Location>().WithMany().HasForeignKey("Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Concerner_Location_FK"),
                        j =>
                        {
                            j.HasKey("Id", "IdCharacter").HasName("Concerner_PK");

                            j.ToTable("Concerner");

                            j.IndexerProperty<int>("IdCharacter").HasColumnName("Id_Character");
                        });

                entity.HasMany(d => d.IdRealWorldLocations)
                    .WithMany(p => p.Ids)
                    .UsingEntity<Dictionary<string, object>>(
                        "Fournir",
                        l => l.HasOne<RealWorldLocation>().WithMany().HasForeignKey("IdRealWorldLocation").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fournir_RealWorldLocation0_FK"),
                        r => r.HasOne<Location>().WithMany().HasForeignKey("Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fournir_Location_FK"),
                        j =>
                        {
                            j.HasKey("Id", "IdRealWorldLocation").HasName("Fournir_PK");

                            j.ToTable("Fournir");

                            j.IndexerProperty<int>("IdRealWorldLocation").HasColumnName("Id_RealWorldLocation");
                        });
            });

            modelBuilder.Entity<RealWorldLocation>(entity =>
            {
                entity.ToTable("RealWorldLocation");

                entity.Property(e => e.Adress).HasColumnType("text");

                entity.Property(e => e.Availability).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Screenplay>(entity =>
            {
                entity.ToTable("Screenplay");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
