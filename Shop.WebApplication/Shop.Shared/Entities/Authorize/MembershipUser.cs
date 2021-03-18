using Shop.Shared.Entities.Enums;

namespace Shop.Shared.Entities.Authorize
{
    public class MembershipUser
    {
        public MembershipUser() { }

        public MembershipUser(int id, string name, RoleType role)
        {
            this.UserId = id;
            this.Name = name;
            this.Role = role;
        }

        public int UserId { get; set; }

        public string Name { get; set; }

        public RoleType Role { get; set; }
    }
}
