using Devoak.Application.DataTransfer;
using Devoak.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devoak.Implementation.Validation
{
    public class UserValidation : AbstractValidator<UserDto>
    {
        public UserValidation(DevoakContext context)
        {
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required parameter");

            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required parameter");

            RuleFor(user => user.Username)
                .NotEmpty()
                .WithMessage("Username is required parameter")
                .Must(username => !context.Users.Any(u => u.Username == username))
                .WithMessage("Username must be unique")
                .MaximumLength(15)
                .WithMessage("Max length 15 characters");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter")
                .Must(email => !context.Users.Any(u => u.Email == email))
                .WithMessage("Email must be unique")
                .EmailAddress();

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password is required parameter")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")
                .WithMessage("Password must have at least: 1 lower case letter, 1 uppercase letter, 1 number, 1 special character, min length 8 characters ");

        }
    }
}
