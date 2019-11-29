using AMSRepository.Models;
using AMSRepository.Repository;
using AMSService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace NLTDAMS.Models
{
    public class UserRoleProvider : RoleProvider
    {
        AMSEntities Context = new AMSEntities();

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

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
                string Role = Context.Employee.Where(e => e.CorpId == username).Select(e => e.EmployeeRole.Designation).FirstOrDefault();
                string[] RoleName = new string[1];
                if(Role != "" && Role != null)
                {
                     for (int i = 0; i < Role.Length; i++)
                     {
                           RoleName[i] = Role;
                           Role = "";
                     }
                }                
                return RoleName;

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
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