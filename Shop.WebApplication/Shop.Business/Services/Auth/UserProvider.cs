//using Shop.Data.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;

//namespace Shop.Business.Services.Auth
//{
//    public class UserProvider : IPrincipal
//    {
//        private UserIndentity userIdentity { get; set; }

//        #region IPrincipal Members

//        public IIdentity Identity
//        {
//            get
//            {
//                return userIdentity;
//            }
//        }

//        public bool IsInRole(string role)
//        {
//            if (userIdentity.User == null)
//            {
//                return false;
//            }
//            return userIdentity.User.InRoles(role);
//        }

//        #endregion


//        public UserProvider(string name, UserRepository repository)
//        {
//            userIdentity = new UserIndentity();
//            userIdentity.Init(name, repository);
//        }


//        public override string ToString()
//        {
//            return userIdentity.Name;
//        }
//    }
//}
