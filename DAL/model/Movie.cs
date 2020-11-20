using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.model {
    class Movie {

        public int Id;
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public int RentalDuration { get; set; }
        public decimal Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public decimal Rating { get; set; }



    }
}
