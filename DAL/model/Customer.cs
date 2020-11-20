using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.model {
    public class Customer {

        public int Id;
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }
}
