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
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly DevoakContext _context;
        private readonly UserValidation _validator;
        private readonly IMapper _mapper;

        public CreateUserCommand(DevoakContext context, UserValidation validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;
        public string Description => "Create New User";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = _mapper.Map<User>(request);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
