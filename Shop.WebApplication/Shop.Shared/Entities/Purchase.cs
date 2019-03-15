using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Shared.Entities
{
    public class Purchase
    {
        public int Id { get; set; }

        public User Seller { get; set; }

        public User Customer { get; set; }

        public string Address { get; set; }

        public Product Product { get; set; }

        public DateTime Date { get; set; }
    }
}
