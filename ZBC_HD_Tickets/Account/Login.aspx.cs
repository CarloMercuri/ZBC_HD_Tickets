using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZBC_HD_Tickets.Models;
using ZBC_HD_Tickets.Security;

namespace ZBC_HD_Tickets.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_Submit.Click += (snder, args) =>
            {
                UserStandardAuthentication authentication = AccountSecurity.LoginUserPass(input_Username.Value, input_Password.Value);

                if(authentication.Result == LoginResult.Successful)
                {
                    Response.Redirect("../Ticket/Index.aspx");
                }
            };
        }
    }
}