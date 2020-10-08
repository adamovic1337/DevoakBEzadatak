using Devoak.Application.Commands;
using Devoak.Application.Exceptions;
using Devoak.DataAccess;
using Devoak.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Implementation.Commands
{
    public class SoftDeleteUserCommand : IDeleteUserCommand
    {
        private readonly DevoakContext _context;

        public SoftDeleteUserCommand(DevoakContext context)
        {
            _context = context;
        }

        public int Id => 301;

        public string Description => "Soft Delete User";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }

            user.IsDeleted = true;
            user.IsActive = false;
            user.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
