using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using BusinessLogic.Models;

namespace Website.Filters
{
    public class CustomIdentity : IIdentity
    {
        #region from interface

        public string Name => IsAuthenticated ? Email : null;

        public string AuthenticationType => "Custom";

        public bool IsAuthenticated => Id != Guid.Empty;

        #endregion

        #region added by me

        public Guid Id { get; set; }
        public string Email { get; set; }

        public CustomIdentity(User user)
        {
            Id = user.Id;
            Email = user.Email;
        }

        #endregion
    }
}