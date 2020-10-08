using AutoMapper;
using Devoak.Application.DataTransfer;
using Devoak.Application.Queries;
using Devoak.Application.Searches;
using Devoak.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devoak.Implementation.Queries
{
    public class GetRestaurantsQuery : IGetRestaurantsQuery
    {
        private readonly DevoakContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantsQuery(DevoakContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 404;

        public string Description => "Get Restaurants";

        public IEnumerable<RestaurantDto> Execute(RestaurantSearch search)
        {
            var query = _context.Restaurants.AsQueryable();           

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(restaurant => restaurant.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var restaurants = query.Select(r => _mapper.Map<RestaurantDto>(r)).ToList();

            
            foreach (var res in restaurants)
            {
                var rating = _context.Ratings.Where(r => r.RestaurantId == res.Id).Select(r => r.Rating);
                
                if (rating.Sum() != 0)
                {
                    res.Rating = rating.Average();
                }
                else
                {
                    res.Rating = 0;
                }
            }
            

            return restaurants;
        }
    }
}
