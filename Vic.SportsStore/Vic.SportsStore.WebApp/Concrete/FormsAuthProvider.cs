using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vic.SportsStore.WebApp.Abstract;

namespace Vic.SportsStore.WebApp.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = false;

            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "123")
            {
                result = true;
            }

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}