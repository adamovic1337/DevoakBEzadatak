using AutoMapper;
using Devoak.Application.DataTransfer;
using Devoak.Application.Queries;
using Devoak.DataAccess;
using Devoak.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devoak.Implementation.Queries
{
    public class GetRestaurantQuery : IGetRestaurantQuery
    {
        private readonly DevoakContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantQuery(DevoakContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 402;

        public string Description => "Get Restaurant";

        public IEnumerable<RestaurantDto> Execute(int search)
        {
            var query = _context.Restaurants.AsQueryable();
            query = query.Where(restaurant => restaurant.Id == search);

            var rating = _context.Ratings.Where(r => r.RestaurantId == search).Select(r => r.Rating);
            var restaurant = new RestaurantDto();

            if (rating.Sum() != 0)
            {
                restaurant.Rating = rating.Average();
            }
            else
            {
                restaurant.Rating = 0;
            }

                       

            return query.Select(r => _mapper.Map(r, restaurant)).ToList();
        }
    }
}
