using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKPTickets.Models
{
    public class TicketUpdate
    {
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        private DateTime updatedDate;

        public DateTime UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }
    }
}
