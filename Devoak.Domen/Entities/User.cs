using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Domen.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Ratings> Ratings { get; set; }        
    }
}
