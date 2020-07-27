using RestaurantManagement.Entities;
using RestaurantManagement.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.Core.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAll(RestaurantListParams parameters);

        Task Add(Restaurant restaurant);

        Task<Restaurant> Find(int id);

        Task Delete(Restaurant restaurant);

        Task<bool> Edit(Restaurant restaurant);
    }
}
