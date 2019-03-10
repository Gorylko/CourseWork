using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Shared.Entities;

namespace Shop.WebApplication.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public User Person { get; set; }

        public string Address { get; set; }
    }
}