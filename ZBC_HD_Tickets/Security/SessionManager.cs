using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZBC_HD_Tickets.Security
{
    public static class SessionManager
    {
        private static bool isAuthenticated;

        public static bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set { isAuthenticated = value; }
        }

        public static void SetUser(string userID, string userRole)
        {
            HttpContext.Current.Session["UserID"] = userID;
            HttpContext.Current.Session["UserRole"] = userRole;
            isAuthenticated = true;
        }

        public static void LogoutUser()
        {
            HttpContext.Current.Session["UserID"] = "";
            HttpContext.Current.Session["UserRole"] = "";
            isAuthenticated = false;
        }

        public static string GetUserID()
        {
            if (!isAuthenticated)
            {
                return "";
            }

            return HttpContext.Current.Session["UserID"].ToString();
        }

        public static string GetUserRole()
        {
            if (!isAuthenticated)
            {
                return "";
            }

            return HttpContext.Current.Session["UserRole"].ToString();
        }
    }
}