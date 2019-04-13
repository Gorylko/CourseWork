using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models.ProductViewModels
{
    
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public Category Category { get; set; }

        public User Author { get; set; }

        public string LocationOfProduct { get; set; }

        public string State { get; set; }
    }
}