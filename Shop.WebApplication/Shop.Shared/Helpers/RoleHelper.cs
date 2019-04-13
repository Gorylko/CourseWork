using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using System;

namespace Shop.Shared.Helpers
{
    public static class RoleHelper
    {
        public static RoleType ConvertToRoleType(string roleName)
        {
            return (RoleType)Enum.Parse(typeof(RoleType), roleName);
        }

        public static RoleType ConvertToRoleType(int roleid)
        {
            return (RoleType)roleid;
        }

        public static bool CheckPermissions(User user, RoleType role)
        {
            return user.Role == role;
        }

        public static bool CheckPermissions(User user, RoleType role1, RoleType role2)
        {
            return user.Role == role1 || user.Role == role2;
        }
    }
}
