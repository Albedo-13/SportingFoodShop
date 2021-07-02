using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SportingFoodShop.Models;
using System.Data.Entity;

namespace SportingFoodShop.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] result = new string[] { };
            using (SportingFoodContext db = new SportingFoodContext())
            {
                User user = db.Users.FirstOrDefault(v => v.Email == username);
                if (user != null)
                {
                    Role userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null)
                    {
                        result = new string[] { userRole.Name };
                    }
                }
            }

            return result;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool result = false;
            using (SportingFoodContext db = new SportingFoodContext())
            {
                User user = db.Users.FirstOrDefault(v => v.Email == username);
                if (user != null)
                {
                    Role userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null && userRole.Name == roleName)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}