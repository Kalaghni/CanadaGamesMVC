using Microsoft.EntityFrameworkCore;
using CanadaGamesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanadaGamesMVC.ViewModels;

namespace CanadaGamesMVC.Data
{
    public class CanadaGamesContext : DbContext
    {
        public CanadaGamesContext(DbContextOptions<CanadaGamesContext> options) : base(options)
        {

        }

        #region DbSet Objects
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Contingent> Contingents { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Hometown> Hometowns { get; set; }
        public DbSet<AthleteDocument> AthleteDocuments { get; set; }
        public DbSet<AthleteSport> AthleteSports { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<AthletePhoto> AthletePhotos { get; set; }
        public DbSet<AthleteThumbnail> AthleteThumbnails { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Placement> Placements { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CG");

            modelBuilder.Entity<Coach>()
                .HasMany<Athlete>(c => c.Athletes)
                .WithOne(a => a.Coach)
                .HasForeignKey(a => a.CoachID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contingent>()
                .HasMany<Athlete>(c => c.Athletes)
                .WithOne(a => a.Contingent)
                .HasForeignKey(a => a.ContingentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contingent>()
                .HasMany<Hometown>(c => c.Hometowns)
                .WithOne(h => h.Contingent)
                .HasForeignKey(h => h.ContingentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gender>()
                .HasMany<Athlete>(g => g.Athletes)
                .WithOne(a => a.Gender)
                .HasForeignKey(a => a.GenderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Athlete>()
                .HasIndex(a => a.AthleteCode)
                .IsUnique();

            modelBuilder.Entity<AthleteSport>()
            .HasKey(t => new { t.SportID, t.AthleteID });

            modelBuilder.Entity<AthleteSport>()
                .HasOne(pc => pc.Sport)
                .WithMany(c => c.AthleteSports)
                .HasForeignKey(pc => pc.SportID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hometown>()
                .HasIndex(a => a.ID)
                .IsUnique();

            modelBuilder.Entity<Hometown>()
                .HasMany<Athlete>(h => h.Athletes)
                .WithOne(a => a.Hometown)
                .HasForeignKey(a => a.HometownID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Placement>()
            .HasIndex(p => new { p.AthleteID, p.EventID })
            .IsUnique();

            modelBuilder.Entity<Event>()
            .HasMany<Placement>(d => d.Placements)
            .WithOne(p => p.Event)
            .HasForeignKey(p => p.EventID)
            .OnDelete(DeleteBehavior.Restrict);

        }


        public DbSet<CanadaGamesMVC.ViewModels.PlacementReport> PlacementReport { get; set; }


    }
}
