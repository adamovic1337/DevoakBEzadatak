using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devoak.Application.Commands;
using Devoak.Application.DataTransfer;
using Devoak.Application.Queries;
using Devoak.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Devoak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult Get([FromQuery] RestaurantSearch search, [FromServices] IGetRestaurantsQuery query)
        {
            return Ok(query.Execute(search));
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRestaurantQuery query)
        {
            return Ok(query.Execute(id));
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult Post([FromBody] RestaurantDto dto, [FromServices] ICreateRestaurantCommand command)
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RestaurantDto dto, [FromServices] IUpdateRestaurantCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return NoContent();
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRestaurantCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
