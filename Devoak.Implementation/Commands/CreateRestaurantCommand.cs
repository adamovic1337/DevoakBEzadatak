using AutoMapper;
using Devoak.Application.Commands;
using Devoak.Application.DataTransfer;
using Devoak.DataAccess;
using Devoak.Domen.Entities;
using Devoak.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Implementation.Commands
{
    public class CreateRestaurantCommand : ICreateRestaurantCommand
    {
        private readonly DevoakContext _context;
        private readonly RestaurantValidation _validator;
        private readonly IMapper _mapper;

        public CreateRestaurantCommand(DevoakContext context, RestaurantValidation validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Description => "Create New Restaurant";

        public void Execute(RestaurantDto request)
        {
            _validator.ValidateAndThrow(request);

            var restaurant = _mapper.Map<Restaurant>(request);

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }
    }
}
