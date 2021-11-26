using SKPTickets.Constants;
using SKPTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKPTickets.Security
{
    public class UserStandardAuthentication
    {
        public PrivateAccountDataModel userModel { get; set; }

        public LoginResult Result { get; set; }

        public string Message { get; set; }
    }
}
