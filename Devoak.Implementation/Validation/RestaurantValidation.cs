using Devoak.Application.DataTransfer;
using Devoak.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devoak.Implementation.Validation
{
    public class RestaurantValidation : AbstractValidator<RestaurantDto>
    {
        public RestaurantValidation(DevoakContext context)
        {
            RuleFor(restaurant => restaurant.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter");

            RuleFor(restaurant => restaurant.Phone)
                .NotEmpty()
                .WithMessage("Phone is required parameter");

            RuleFor(restaurant => restaurant.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter")
                .Must(email => !context.Restaurants.Any(restaurant => restaurant.Email == email))
                .WithMessage("Email must be unique")
                .EmailAddress();


        }
    }
}
