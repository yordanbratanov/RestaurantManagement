using AutoMapper;
using RestaurantManagement.Core.Repositories;
using RestaurantManagement.Core.Services;
using RestaurantManagement.Models.Restaurant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.Business.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantsRepository _restaurantsRepository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantsRepository restaurantsRepository,
            IMapper mapper)
        {
            _restaurantsRepository = restaurantsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantDetailsDto>> GetAll()
        {
            var restaurants = await _restaurantsRepository.GetAll();
            return _mapper.Map<IEnumerable<RestaurantDetailsDto>>(restaurants);
        }
    }
}
