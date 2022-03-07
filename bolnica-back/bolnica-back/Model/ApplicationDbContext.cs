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
                new Doctor(4, "Rada", "Radic", "rada", "rada@gmail.com", "480238048", "123", 4, 8)
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
            modelBuilder.Entity<ReviewRating>().Property(rr => rr.Id).HasIdentityOptions(startValue: 100);
    }
    }
}
