using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZBC_HD_Tickets.Models
{
    public class UserStandardAuthentication
    {
        public PrivateAccountDataModel userModel { get; set; }

        public LoginResult Result { get; set; }

        public string Message { get; set; }
    }
}