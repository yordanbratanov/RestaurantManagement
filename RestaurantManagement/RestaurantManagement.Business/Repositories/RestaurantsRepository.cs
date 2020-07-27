using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Repositories;
using RestaurantManagement.Data;
using RestaurantManagement.Entities;
using RestaurantManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var result = parameters.IsDescending ? 
                await _dbContext.Restaurants.OrderByDescending(x => parameters.OrderBy).Skip(parameters.StartIndex - 1).Take(parameters.EndIndex - parameters.StartIndex + 1).ToListAsync() :
                await _dbContext.Restaurants.OrderBy(x => parameters.OrderBy).Skip(parameters.StartIndex - 1).Take(parameters.EndIndex - parameters.StartIndex + 1).ToListAsync();

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
