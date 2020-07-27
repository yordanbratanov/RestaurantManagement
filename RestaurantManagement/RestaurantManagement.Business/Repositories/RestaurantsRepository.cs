using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Repositories;
using RestaurantManagement.Data;
using RestaurantManagement.Entities;
using RestaurantManagement.Models.Common;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Restaurant>> GetAll(RestaurantListParams parameters)
        {
            IQueryable<Restaurant> query = _dbContext.Restaurants;

            switch (parameters.OrderBy)
            {
                case AppConstants.Name:
                    query = parameters.IsDescending ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                    break;
                case "Location":
                    query = parameters.IsDescending ? query.OrderByDescending(x => x.Location) : query.OrderBy(x => x.Location);
                    break;
                case "Rating":
                    query = parameters.IsDescending ? query.OrderByDescending(x => x.Rating) : query.OrderBy(x => x.Rating);
                    break;
            }

            var result = await query.Skip(parameters.StartIndex - 1).Take(parameters.EndIndex - parameters.StartIndex + 1).ToListAsync();

            return result;
        }
        public async Task Add(Restaurant restaurant)
        {
            await _dbContext.Restaurants.AddAsync(restaurant);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Restaurant> Find(int id) =>
            await _dbContext.Restaurants.FindAsync(id);

        public async Task Delete(Restaurant restaurant)
        {
            _dbContext.Restaurants.Remove(restaurant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Edit(Restaurant restaurant)
        {
            _dbContext.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Restaurants.Any(e => e.Id == restaurant.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
    }
}
