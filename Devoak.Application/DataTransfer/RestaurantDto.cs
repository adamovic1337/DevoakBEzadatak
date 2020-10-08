using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Application.DataTransfer
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Rating { get; set; }
    }
}
