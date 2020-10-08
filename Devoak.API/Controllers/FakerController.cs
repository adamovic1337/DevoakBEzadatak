using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devoak.API.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Devoak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakerController : ControllerBase
    {
        // POST api/<FakerController>
        [HttpPost]
        public IActionResult Post([FromServices] FakerData faker)
        {
            faker.AddUsers();
            faker.AddRestaurants();
            faker.AddRatings();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
