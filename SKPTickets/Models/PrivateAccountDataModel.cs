using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKPTickets.Models
{
    public class PrivateAccountDataModel
    {
        /// <summary>
        /// The Email associated with this account
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The First name of the owner of this account
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The Last name of the owner of this account
        /// </summary>
        public string LastName { get; set; }
    }
}
