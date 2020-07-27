using RestaurantManagement.Models.Restaurant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.Core.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDetailsDto>> GetAll();
    }
}
