using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Entities;

namespace RestaurantManagement.Data
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options)
            : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
