using RestaurantManagement.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.Core.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAll();

        Task Add(Restaurant restaurant);
        Task<Restaurant> Find(int id);
    }
}
