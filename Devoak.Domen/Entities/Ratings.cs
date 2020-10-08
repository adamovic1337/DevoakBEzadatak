using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Domen.Entities
{
    public class Ratings : Entity
    {
        public int Rating { get; set; } 

        public int UserId { get; set; }
        public int RestaurantId { get; set; }

        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        

    }
}
