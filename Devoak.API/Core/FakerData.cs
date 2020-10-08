using Bogus;
using Devoak.DataAccess;
using Devoak.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devoak.API.Core
{
    public class FakerData
    {
        private readonly DevoakContext _context;

        public FakerData(DevoakContext context)
        {
            _context = context;
        }

        public void AddUsers()
        {
            var totalUsers = 10;            

            var users = new Faker<User>();
            users.RuleFor(user => user.FirstName, f => f.Name.FirstName());
            users.RuleFor(user => user.LastName, f => f.Name.LastName());
            users.RuleFor(user => user.Username, f => f.Internet.UserName());
            users.RuleFor(user => user.Email, f => f.Internet.Email());
            users.RuleFor(user => user.Password, f => f.Internet.Password());

            var fakeUsers = users.Generate(totalUsers);

            _context.Users.AddRange(fakeUsers);
            _context.SaveChanges();
        }

        public void AddRestaurants()
        {
            var totalRestaurants = 15;
           
            var restaurants = new Faker<Restaurant>();
            restaurants.RuleFor(restaurant => restaurant.Name, f => f.Company.CompanyName());
            restaurants.RuleFor(restaurant => restaurant.Address, f => f.Address.StreetAddress());
            restaurants.RuleFor(restaurant => restaurant.City, f => f.Address.City());
            restaurants.RuleFor(restaurant => restaurant.Country, f => f.Address.Country());
            restaurants.RuleFor(restaurant => restaurant.Phone, f => f.Phone.PhoneNumber());
            restaurants.RuleFor(restaurant => restaurant.Email, f => f.Internet.Email());

            var fakeRestaurants = restaurants.Generate(totalRestaurants);

            _context.Restaurants.AddRange(fakeRestaurants);
            _context.SaveChanges();            
        }

        public void AddRatings()
        {
            var totalRatings = 30;

            var userIds = _context.Users.Select(users => users.Id).ToList();
            var restaurantIds = _context.Restaurants.Select(restaurant => restaurant.Id).ToList();

            var ratings = new Faker<Ratings>();
            ratings.RuleFor(rating => rating.Rating, f => f.Random.Number(1, 5));
            ratings.RuleFor(rating => rating.UserId, f => f.PickRandom(userIds));
            ratings.RuleFor(rating => rating.RestaurantId, f => f.PickRandom(restaurantIds));

            var fakeRatings = ratings.Generate(totalRatings);

            _context.Ratings.AddRange(fakeRatings);
            _context.SaveChanges();
        }
    }
}
