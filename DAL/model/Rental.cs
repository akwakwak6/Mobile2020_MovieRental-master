using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.model {
    public class Rental {

        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<RentalMovie> Movies { get; set; }


    }
}
