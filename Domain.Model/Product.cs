using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // HIDDEN, OUTOFSTOCK, LISTED
        public string State { get; set; }
        public Category Category { get; set; }
        public Price Price { get; set; }
        public List<Price> Prices { get; set; } = new List<Price>();
    }
}
