using System;
using System.Linq;
using System.Web.Security;
using WebSite.Classes.BLogic;

namespace WebSite.Classes
{
    public class RolProviderX:RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var userId = Convert.ToInt32(username);
            return UserManagement.Query().Any(u => u.ID == userId && u.Role.Name == roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            int userId = Convert.ToInt32(username);
            var user = UserManagement.Query().FirstOrDefault(u => u.ID == userId);
            if (user != null)
                return
                    user.Role.Name.Split((new char[] {','}));
            return new string[]{};
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}