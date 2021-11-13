using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Model
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(
                new User(1, "pera", "123", "Petar", "Petrovic", "123123123", "pp@gmail.com", "Svetosavska 11", "023857197", "muski", "pacijent"),
                new User(2, "mika", "123", "Mika", "Mikic", "321321321", "mm@gmail.com", "Dositejea 2", "023857555", "muski", "pacijent")
                );
        }
    }
}
