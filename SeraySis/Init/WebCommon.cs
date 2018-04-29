using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeraySis.Common;
using SeraySis.Entities;
using SeraySis.WebApp.Models;

namespace SeraySis.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            Users user = CurrentSession.CurrentUser;

            if (user != null)
                return user.Username;
            else
                return "System";
        }
    }
}