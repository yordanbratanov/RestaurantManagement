using RestaurantManagement.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.Core.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAll();
    }
}
