using AutoMapper;
using Devoak.Application.DataTransfer;
using Devoak.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Implementation.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
