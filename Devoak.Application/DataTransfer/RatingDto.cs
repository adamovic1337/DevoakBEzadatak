using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Application.DataTransfer
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
