using Devoak.Application.DataTransfer;
using Devoak.Application.Searches;
using Devoak.Application.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Application.Queries
{
    public interface IGetRestaurantsQuery : IQuery<RestaurantSearch, IEnumerable<RestaurantDto>>
    {
    }
}
