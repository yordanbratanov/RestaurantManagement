using AutoMapper;
using RestaurantManagement.Core.Repositories;
using RestaurantManagement.Core.Services;
using RestaurantManagement.Entities;
using RestaurantManagement.Models.Common;
using RestaurantManagement.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
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
            restaurant.CreatedDate = DateTime.UtcNow;
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

        public async Task<bool> Edit(RestaurantDetailsDto restaurantDto)
        {
            var restaurant = await _restaurantsRepository.Find(restaurantDto.Id);
            MapProperties(restaurant, restaurantDto);

            var result = await _restaurantsRepository.Edit(restaurant);

            return result;
        }

        public async Task<RestaurantDetailsDto> Find(int id)
        {
            var result = await _restaurantsRepository.Find(id);

            return _mapper.Map<RestaurantDetailsDto>(result);
        }

        public async Task<IEnumerable<RestaurantDetailsDto>> GetAll(RestaurantListParams parameters)
        {
            if (string.IsNullOrEmpty(parameters.OrderBy))
            {
                parameters.OrderBy = AppConstants.Name;
            }

            var restaurants = await _restaurantsRepository.GetAll(parameters);
            return _mapper.Map<IEnumerable<RestaurantDetailsDto>>(restaurants);
        }

        private void MapProperties(Restaurant restaurant, RestaurantDetailsDto restaurantDto)
        {
            var dbProperties = typeof(Restaurant).GetProperties().ToArray();
            var dtoProperties = typeof(RestaurantDetailsDto).GetProperties().ToArray();

            for (int i = 0; i < dtoProperties.Length; i++)
            {
                var dbProperty = dbProperties.Where(s => s.Name == dtoProperties[i].Name).FirstOrDefault();
                dynamic dbValue = dbProperty.GetValue(restaurant, null);
                dynamic dtoValue = dtoProperties[i].GetValue(restaurantDto, null);

                if (dbValue != dtoValue)
                {
                    dbProperty.SetValue(restaurant, dtoValue);
                }

            }

            restaurant.ModifiedDate = DateTime.UtcNow;
        }
    }
}
