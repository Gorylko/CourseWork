using System;

namespace Shop.Shared.Entities
{
    public class Purchase
    {
        public int Id { get; set; }

        public User Seller { get; set; }

        public User Customer { get; set; }

        public Location Location { get; set; }

        public Product Product { get; set; }

        public DateTime Date { get; set; }
    }
}
