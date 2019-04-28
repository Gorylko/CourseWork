using System.Collections.Generic;

namespace Shop.Shared.Entities
{
    public class ProductFilterParameters
    {
        public string Name { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public State State { get; set; }

        public Category Category { get; set; }
    }
}
