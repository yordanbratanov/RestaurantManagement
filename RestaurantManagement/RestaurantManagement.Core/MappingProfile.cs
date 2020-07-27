using AutoMapper;
using RestaurantManagement.Entities;
using RestaurantManagement.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantDetailsDto>();
        }
    }
}
