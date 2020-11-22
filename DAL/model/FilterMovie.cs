using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.model {
    public class FilterMovie {

        public int? Category { get; set; } = null;
        public int? Actor { get; set; } = null;
        public String Title { get; set; } = null;
        public int? Langage { get; set; } = null;
        public String KeyWord { get; set; } = null;

    }
}
