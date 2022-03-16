using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Model
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewRating> ReviewRatings { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<PenaltyPoint> PenaltyPoints { get; set; }
        public DbSet<ReviewInstructions> Instructions { get; set; }
        public DbSet<Drug> Drugs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=bole3333;Database=bolnica;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //SAMO ZA KORISNIKE
            modelBuilder.Entity<User>().HasMany(u => u.Reviews).WithOne(r => r.User).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(u => u.Surveys).WithOne(s => s.User).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(u => u.PenaltyPoints).WithOne(pp => pp.User).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasData(
                new User(1, "pera", "123", "Petar", "Petrovic", "123123123", "pp@gmail.com", "Svetosavska 11", "023857197", Gender.m, false),
                new User(2, "mika", "123", "Mika", "Mikic", "321321321", "mm@gmail.com", "Dositejeva 2", "023857555", Gender.m, false),
                new User(3, "nada", "123", "Nadica", "Nadic", "98989898", "nn@gmail.com", "Pupinova 222", "023857999", Gender.z, true)
                );
            modelBuilder.Entity<User>().Property(u => u.Id).HasIdentityOptions(startValue: 100);
            
            //SAMO ZA DOKTORE
            modelBuilder.Entity<Doctor>().HasMany(d => d.Reviews).WithOne(r => r.Doctor).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor(2, "Stole", "Stosic", "stole", "ss@gmail.com", "347237942", "123", 5, 10),
                new Doctor(3, "Misa", "Misic", "misa", "misa@gmail.com", "7998237", "123", 8, 10),
                new Doctor(4, "Rada", "Radic", "rada", "rada@gmail.com", "480238048", "123", 4, 8),
                new Doctor(5, "Lale", "Lakic", "laki", "lale@gmail.com", "648236486", "123", 8, 10, true),
                new Doctor(6, "Ana", "Lakic", "ana", "anci@gmail.com", "73320220", "123", 6, 12, true)
                );
            modelBuilder.Entity<Doctor>().Property(d => d.Id).HasIdentityOptions(startValue: 100);

            //SAMO ZA PREGLEDE
            modelBuilder.Entity<Review>().HasData(
                new Review(1, new DateTime(2022, 2, 26, 10, 20, 0, 0), 30, false, 2, 1),
                new Review(2, new DateTime(2022, 2, 26, 11, 20, 0, 0), 30, false, 2, 1),
                new Review(3, new DateTime(2022, 2, 26, 12, 20, 0, 0), 30, false, 2, 1),
                new Review(4, new DateTime(2022, 12, 26, 12, 20, 0, 0), 30, false, 2, 1)
                );
            modelBuilder.Entity<Review>().Property(r => r.Id).HasIdentityOptions(startValue: 100);
            modelBuilder.Entity<Review>().HasOne(r => r.Rating).WithOne(rr => rr.Review).HasForeignKey<ReviewRating>(rr => rr.ReviewId);
            modelBuilder.Entity<Review>().HasOne(r => r.Instructions).WithOne(ri => ri.Review).HasForeignKey<ReviewInstructions>(ri => ri.ReviewId);

            //SAMO ZA OCENE PREGELDA
            modelBuilder.Entity<ReviewRating>().Property(rr => rr.Id).HasIdentityOptions(startValue: 100);

            //SAMO ZA UPUTE
            modelBuilder.Entity<ReviewInstructions>().Property(ri => ri.Id).HasIdentityOptions(startValue: 100);
            
            //SAMO ZA ANKETE
            modelBuilder.Entity<Survey>().Property(s => s.Id).HasIdentityOptions(startValue: 100);
            modelBuilder.Entity<Survey>().HasData(
                new Survey(1, 4, "Neki komentar 1", new DateTime(2021, 12, 10, 10, 10, 10), 1, false),
                new Survey(2, 3, "Neki komentar 2", new DateTime(2022, 1, 12, 12, 30, 55), 1, true),
                new Survey(3, 5, "Neki komentar 3", new DateTime(2021, 10, 1, 8, 21, 22), 1, false)
                );

            //SAMO ZA KAZNENE POENE
            modelBuilder.Entity<PenaltyPoint>().Property(pp => pp.Id).HasIdentityOptions(startValue: 100);

            //SAMO ZA LEKOVE
            modelBuilder.Entity<Drug>().HasIndex(d => d.Name).IsUnique();
            modelBuilder.Entity<Drug>().Property(d => d.Id).HasIdentityOptions(startValue: 100);
            modelBuilder.Entity<Drug>().HasData(
                new Drug(1, "Diklofenak duo", 10, "Za ublazavanje bolove u kostima"),
                new Drug(2, "Panadol", 20, "Za ublazavanje bolova" ),
                new Drug(3, "Coldrex 10", 20, "Za otklanjanje simptoma prehlade i gripa"),
                new Drug(4, "Brufen 400", 50, "Za otklanjanje povisene telesne temperature")
                );

    }
    }
}
