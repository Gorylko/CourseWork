using Shop.Shared.Entities.Enums;
using System.Security.Principal;

namespace Shop.Shared.Entities.Authorize
{
    public class UserPrinciple : IPrincipal
    {
        public UserPrinciple(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public int UserId { get; set; }

        public string Name => this.Identity.Name;

        public RoleType Role { get; set; }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return this.Role.ToString() == role;
        }
    }
}
