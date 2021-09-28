using Microsoft.EntityFrameworkCore;
using Pz.Cheeseria.Api.Models;

namespace Pz.Cheeseria.Api.Data
{
    public class OrgDB : DbContext
    {
        public OrgDB(DbContextOptions<OrgDB> options) : base(options)
        {
        }

        public DbSet<Cheese> Cheese { get; set; }
        //public DbSet<Cart> Cart { get; set; }
        //public DbSet<Orders> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cheese>().ToTable("Cheese");
        }
    }
}
