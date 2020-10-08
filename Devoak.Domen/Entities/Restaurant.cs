using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Domen.Entities
{
    public class Restaurant : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Ratings> Ratings { get; set; }
    }
}
