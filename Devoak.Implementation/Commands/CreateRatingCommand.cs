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
    public class CreateRatingCommand : ICreateRatingCommand
    {
        private readonly DevoakContext _context;
        private readonly RatingValidation _validator;
        private readonly IMapper _mapper;

        public CreateRatingCommand(DevoakContext context, RatingValidation validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Description => "Create Rating";

        public void Execute(RatingDto request)
        {
            _validator.ValidateAndThrow(request);

            var rating = _mapper.Map<Ratings>(request);

            _context.Ratings.Add(rating);
            _context.SaveChanges();
        }
    }
}
