using Microsoft.EntityFrameworkCore;
using Sooqak.Entities;

namespace Sooqak.Context
{
    public class SooqakDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Advertisement> advertisements { get; set; }
        public DbSet<ApartmentDetail> apartmentDetails { get; set; }
        public DbSet<CarDetail> carDetails { get; set; }
        public DbSet<ElectricalAppliance> electricalAppliances { get; set; }
        public DbSet<Work> works { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<UserFavorite> userFavorite { get; set; }
        







        public SooqakDbContext(DbContextOptions<SooqakDbContext> options)
        : base(options)
        {
        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }




     

    
}
