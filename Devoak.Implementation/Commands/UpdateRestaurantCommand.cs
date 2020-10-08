using AutoMapper;
using Devoak.Application.Commands;
using Devoak.Application.DataTransfer;
using Devoak.Application.Exceptions;
using Devoak.DataAccess;
using Devoak.Domen.Entities;
using Devoak.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Implementation.Commands
{
    public class UpdateRestaurantCommand : IUpdateRestaurantCommand
    {
        private readonly DevoakContext _context;
        private readonly RestaurantValidation _validator;
        private readonly IMapper _mapper;
        public UpdateRestaurantCommand(DevoakContext context, RestaurantValidation validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 202;

        public string Description => "Update Restaurant";

        public void Execute(RestaurantDto request)
        {
            _validator.ValidateAndThrow(request);

            var restaurant = _context.Restaurants.Find(request.Id);

            if (restaurant == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Restaurant));
            }

            _mapper.Map(request, restaurant);

            _context.SaveChanges();
        }
    }
}
