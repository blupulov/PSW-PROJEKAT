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
            //SAMO ZA DOKTORE PITATI DA LI NULL ILI NE
            modelBuilder.Entity<Doctor>().HasMany(d => d.Reviews).WithOne(r => r.Doctor).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
