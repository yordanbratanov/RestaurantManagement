using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Repositories;
using RestaurantManagement.Data;
using RestaurantManagement.Entities;
using RestaurantManagement.Models.Restaurant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.Business.Repositories
{
    public class RestaurantsRepository : IRestaurantsRepository
    {
        private readonly ManagementDbContext _dbContext;

        public RestaurantsRepository(ManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Restaurant>> GetAll() => 
            await _dbContext.Restaurants.ToListAsync();

        public async Task Add(Restaurant restaurant)
        {
            await _dbContext.Restaurants.AddAsync(restaurant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Restaurant> Find(int id) =>
            await _dbContext.Restaurants.FindAsync(id);
    }
}
