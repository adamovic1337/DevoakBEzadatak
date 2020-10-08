using Devoak.Domen.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(user => user.Username).IsUnique();
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.FirstName).HasMaxLength(50);
            builder.Property(user => user.LastName).HasMaxLength(50);
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.Username).HasMaxLength(50);
            builder.Property(user => user.Username).IsRequired();

            builder.HasMany(user => user.Ratings)
                   .WithOne(ratings => ratings.User)
                   .HasForeignKey(ratings => ratings.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
