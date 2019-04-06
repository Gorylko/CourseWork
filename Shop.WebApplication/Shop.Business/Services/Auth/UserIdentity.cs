//using Ninject;
//using Shop.Business.Services.Auth.Interfaces;
//using Shop.Data.Repositories;
//using Shop.Shared.Entities;
//using System.Security.Principal;

//namespace Shop.Business.Services.Auth
//{
//    public class UserIndentity : IIdentity, IUserProvider
//    {
//        public User User { get; set; }

//        [Inject]
//        public IAuthentication Auth { get; set; }

//        public User CurrentUser
//        {
//            get
//            {
//                return ((IUserProvider)Auth.CurrentUser.Identity).User;
//            }
//        }
//        public string AuthenticationType
//        {
//            get
//            {
//                return typeof(User).ToString();
//            }
//        }

//        public bool IsAuthenticated
//        {
//            get
//            {
//                return User != null;
//            }
//        }

//        public string Name
//        {
//            get
//            {
//                if (User != null)
//                {
//                    return User.Email;
//                }
//                //иначе аноним
//                return "anonym";
//            }
//        }

//        public void Init(string login, UserRepository repository)
//        {
//            if (!string.IsNullOrEmpty(login))
//            {
//                User = repository.Login(login);
//            }
//        }
//    }
//}
