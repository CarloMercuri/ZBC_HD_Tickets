using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZBC_HD_Tickets.Security
{
    public static class AuthorizationControl
    {
        public static void RequireAuthentication(string requiredRole = "")
        {
            if (!SessionManager.IsAuthenticated)
            {
                HttpContext.Current.Response.Redirect("../Account/Login.aspx");
                return;
            }

            if(requiredRole.Length > 0)
            {
                if (!SessionManager.GetUserRole().Equals(requiredRole))
                {
                    HttpContext.Current.Response.Redirect("../Account/Login.aspx");
                    return;
                }
            }

            // authorized

        }

        
    }
}