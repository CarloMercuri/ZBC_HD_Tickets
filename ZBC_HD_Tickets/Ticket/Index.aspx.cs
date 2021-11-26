using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZBC_HD_Tickets.Models;
using ZBC_HD_Tickets.Security;

namespace ZBC_HD_Tickets.Ticket
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorizationControl.RequireAuthentication("admin");

            Person p = new Person()
            {
                ID = "isosiosis",
                Name = "Carlo",
                LastName = "Mercuri",
                Email = "somethingemail",
                Authorization = "admin",
            };

            Person p1 = new Person()
            {
                ID = "isosiosis",
                Name = "Carlo1",
                LastName = "Mercuri",
                Email = "somethingemail",
                Authorization = "admin",
            };

            Person p2 = new Person()
            {
                ID = "isosiosis",
                Name = "Carlo2",
                LastName = "Mercuri",
                Email = "somethingemail",
                Authorization = "admin",
            };

            Person p3 = new Person()
            {
                ID = "isosiosis",
                Name = "Carlo3",
                LastName = "Mercuri",
                Email = "somethingemail",
                Authorization = "admin",
            };


            List<Person> mainList = new List<Person>();

            mainList.Add(p);
            mainList.Add(p1);
            mainList.Add(p2);
            mainList.Add(p3);

            repPeople.DataSource = mainList;
            repPeople.DataBind();
           
        }

        public void ActionButtonPress(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.CommandName)
            {
                case "EditButtonClick":
                    Response.Redirect("UserAction.aspx?Type=Edit&UserID=" + btn.CommandArgument);
                    break;

                case "DeleteButtonClick":
                    break;
            }
        }
    }
}