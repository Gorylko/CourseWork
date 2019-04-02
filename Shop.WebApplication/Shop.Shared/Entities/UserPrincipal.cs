using System.Linq;
using System.Security.Principal;

namespace Shop.Shared.Entities
{
    public class UserPrincipal :  IPrincipal
    {
        public UserPrincipal(string userName)
        {
            this.Identity = new GenericIdentity(userName);
        }

        public IIdentity Identity { get; private set; }
    } //доделать!
}
