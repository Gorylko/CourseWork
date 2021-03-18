using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class UserListViewModel
    {
        public IReadOnlyCollection<User> Users { get; set; }
    }
}