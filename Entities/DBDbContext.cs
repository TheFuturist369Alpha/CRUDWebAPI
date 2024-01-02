using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUdemy.Models;

namespace WebAPIUdemy.Entities
{

    public class DBDbContext : DbContext
    {
        public DBDbContext(DbContextOptions opts) : base(opts)
        {

        }

        public virtual DbSet<City> city { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City()
            {
                Id = Guid.Parse("5822B3E4-F50A-4BB5-BE5E-70A6474DC041"),
                CityName="Glasgow"
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                Id = Guid.Parse("F65DEE5C-A3BB-4B8E-A12C-78B6E3E7E517"),
                CityName = "Aberdeen"
            });
        }

    }
}
