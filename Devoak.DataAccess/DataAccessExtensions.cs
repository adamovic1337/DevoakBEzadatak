using Devoak.DataAccess.Configuration;
using Devoak.Domen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.DataAccess
{
    public static class DataAccessExtensions
    {
        public static void IsDeletedQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(user => !user.IsDeleted);
            modelBuilder.Entity<Restaurant>().HasQueryFilter(restaurant => !restaurant.IsDeleted);
            modelBuilder.Entity<Ratings>().HasQueryFilter(ratings => !ratings.IsDeleted);
        }

        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
        }       
    }
}
