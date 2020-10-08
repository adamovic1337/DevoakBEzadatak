using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devoak.Application.Commands;
using Devoak.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Devoak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        
        // POST api/<RatingController>
        [HttpPost]
        public IActionResult Post([FromBody] RatingDto dto, [FromServices] ICreateRatingCommand command)
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
