using Devoak.Domen.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.DataAccess.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(restaurant => restaurant.Name).HasMaxLength(50);
            builder.Property(restaurant => restaurant.Name).IsRequired();
            builder.Property(restaurant => restaurant.Address).HasMaxLength(50);
            builder.Property(restaurant => restaurant.City).HasMaxLength(50);
            builder.Property(restaurant => restaurant.Country).HasMaxLength(50);
            builder.Property(restaurant => restaurant.Phone).HasMaxLength(50);
            builder.Property(restaurant => restaurant.Email).IsRequired();

            builder.HasMany(restaurant => restaurant.Ratings)
                   .WithOne(ratings => ratings.Restaurant)
                   .HasForeignKey(ratings => ratings.RestaurantId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
