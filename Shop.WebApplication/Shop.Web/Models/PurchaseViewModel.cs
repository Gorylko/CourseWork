using Shop.Shared.Entities;
using System;


namespace Shop.Web.Models
{
    public class PurchaseViewModel
    {
        public int PurchaseId { get; set; }

        public User Seller { get; set; }

        public User Customer { get; set; }

        public Location Location { get; set; }

        public int ProductId { get; set; }

        public DateTime Date { get; set; }
    }
}