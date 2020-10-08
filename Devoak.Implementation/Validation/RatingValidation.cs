using Devoak.Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Implementation.Validation
{
    public class RatingValidation : AbstractValidator<RatingDto>
    {
        public RatingValidation()
        {
            RuleFor(rating => rating.Rating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rating must be in inclusive range between 1-5");
        }
    }
}
