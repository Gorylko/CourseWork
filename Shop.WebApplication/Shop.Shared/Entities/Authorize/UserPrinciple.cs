using System;
using System.Security.Principal;
using Shop.Shared.Entities.Enums;

namespace Shop.Shared.Entities.Authorize
{
    public class UserPrinciple : IPrincipal
    {
        public UserPrinciple(string username)
        {
            this.Identity = new GenericIdentity(username);
        }
        public int UserId { get; set; }

        public string Name { get; set; }

        public RoleType Role { get; set; }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return this.Role == (RoleType)Enum.Parse(typeof(RoleType), role, true); ;
        }
    }
}
