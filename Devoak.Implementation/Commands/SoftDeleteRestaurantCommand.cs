using Devoak.Application.Commands;
using Devoak.Application.Exceptions;
using Devoak.DataAccess;
using Devoak.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Implementation.Commands
{
    public class SoftDeleteRestaurantCommand : IDeleteRestaurantCommand
    {
        private readonly DevoakContext _context;

        public SoftDeleteRestaurantCommand(DevoakContext context)
        {
            _context = context;
        }

        public int Id => 302;

        public string Description => "Soft Delete Restaurant";

        public void Execute(int request)
        {
            var restaurant = _context.Restaurants.Find(request);

            if (restaurant == null)
            {
                throw new EntityNotFoundException(request, typeof(Restaurant));
            }

            restaurant.IsDeleted = true;
            restaurant.IsActive = false;
            restaurant.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
