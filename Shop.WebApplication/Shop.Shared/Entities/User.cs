using Shop.Shared.Entities.Enums;
using Shop.Shared.Entities.Images;

namespace Shop.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public decimal Balance { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public RoleType Role { get; set; }

        public Image Image { get; set; }

        public bool InRoles(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                return false;
            }
            return Role.ToString() == role;
        }
    }
}
