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
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly DevoakContext _context;
        private readonly UserValidation _validator;
        private readonly IMapper _mapper;

        public UpdateUserCommand(DevoakContext context, UserValidation validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 201;

        public string Description => "Update User";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = _context.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }

            _mapper.Map(request, user);

            _context.SaveChanges();
            
        }
    }
}
