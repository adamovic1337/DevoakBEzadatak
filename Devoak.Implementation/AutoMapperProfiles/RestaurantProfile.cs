using AutoMapper;
using Devoak.Application.DataTransfer;
using Devoak.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Implementation.AutoMapperProfiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                    .ForMember(restaurant => restaurant.Rating, opt => opt.Ignore());
            CreateMap<RestaurantDto, Restaurant>();
        }
    }
}
