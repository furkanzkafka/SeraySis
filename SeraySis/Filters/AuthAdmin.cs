using SeraySis.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeraySis.WebApp.Filters
{
    public class AuthAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.CurrentUser != null && CurrentSession.CurrentUser.IsAdmin == false)
            {
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}