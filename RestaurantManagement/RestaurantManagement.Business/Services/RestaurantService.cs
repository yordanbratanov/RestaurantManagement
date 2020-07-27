using AutoMapper;
using RestaurantManagement.Core.Repositories;
using RestaurantManagement.Core.Services;
using RestaurantManagement.Entities;
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

        public async Task<RestaurantDetailsDto> Add(RestaurantDetailsDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            await _restaurantsRepository.Add(restaurant);
            return restaurantDto;
        }

        public async Task<RestaurantDetailsDto> Delete(int id)
        {
            var restaurant = await _restaurantsRepository.Find(id);

            if (restaurant != null)
            {
                await _restaurantsRepository.Delete(restaurant);
            }

            return _mapper.Map<RestaurantDetailsDto>(restaurant);
        }

        public async Task<RestaurantDetailsDto> Find(int id)
        {
            var result = await _restaurantsRepository.Find(id);

            return _mapper.Map<RestaurantDetailsDto>(result);
        }

        public async Task<IEnumerable<RestaurantDetailsDto>> GetAll()
        {
            var restaurants = await _restaurantsRepository.GetAll();
            return _mapper.Map<IEnumerable<RestaurantDetailsDto>>(restaurants);
        }
    }
}
