using Microsoft.EntityFrameworkCore;
using ODataTest.Models;
using System.Diagnostics;

namespace ODataTest.Context
{
    public class ODataTestContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sehir>()
                .HasMany(s => s.Ilceler)
                .WithOne(i => i.Sehir)
                .HasForeignKey(i => i.SehirId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
