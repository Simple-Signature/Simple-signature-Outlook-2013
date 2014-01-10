using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Simple_Signature
{

        [DirectoryRdnPrefix("CN")]
        [DirectoryObjectClass("Person")]
        public class User : UserPrincipal
        {
            // Inplement the constructor using the base class constructor. 
            public User(PrincipalContext context)
                : base(context)
            { }

            // Implement the constructor with initialization parameters.    
            public User(PrincipalContext context,
                                 string samAccountName,
                                 string password,
                                 bool enabled)
                : base(context, samAccountName, password, enabled)
            { }

            UserSearchFilter searchFilter;

            new public UserSearchFilter AdvancedSearchFilter
            {
                get
                {
                    if (null == searchFilter)
                        searchFilter = new UserSearchFilter(this);

                    return searchFilter;
                }
            }

            // Create the "Title" property.    
            [DirectoryProperty("title")]
            public string Title
            {
                get
                {
                    if (ExtensionGet("title").Length != 1)
                        return string.Empty;

                    return (string)ExtensionGet("title")[0];
                }
                set { ExtensionSet("title", value); }
            }

            // Implement the overloaded search method FindByIdentity.
            public static new User FindByIdentity(PrincipalContext context, string identityValue)
            {
                return (User)FindByIdentityWithType(context, typeof(User), identityValue);
            }

            // Implement the overloaded search method FindByIdentity. 
            public static new User FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
            {
                return (User)FindByIdentityWithType(context, typeof(User), identityType, identityValue);
            }
        }

        public class UserSearchFilter : AdvancedFilters
        {
            public UserSearchFilter(Principal p) : base(p) { }

            public void LogonCount(int value, MatchType mt)
            {
                this.AdvancedFilterSet("LogonCount", value, typeof(int), mt);
            }
        }

}
