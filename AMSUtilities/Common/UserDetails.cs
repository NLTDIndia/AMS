﻿using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace AMSUtilities.Common
{
    public static class UserDetails
    {
        public static string GetFullName(this IIdentity userIdentity)
        {
            try
            {
                if (userIdentity == null) return null;

                using (var context = new PrincipalContext(ContextType.Domain))
                {
                    var userPrincipal = UserPrincipal.FindByIdentity(context, userIdentity.Name);
                    return userPrincipal != null ? $"{userPrincipal.GivenName} {userPrincipal.Surname}" : null;
                }
            }
            catch (System.DirectoryServices.Protocols.LdapException)
            {
                throw;
            }
        }

        public static string GetUserCorpId(this IIdentity userIdentity)
        {
            return userIdentity.Name;
        }
    }
}