using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKPTickets.Models
{
    public class TicketModel
    {
        private string shortDescription;
        /// <summary>
        /// A short description (title) of the ticket
        /// </summary>
        public string ShortDescription
        {
            get { return shortDescription; }
            set { shortDescription = value; }
        }

        private string longDescription;

        /// <summary>
        /// Long description (content) of the ticket
        /// </summary>
        public string LongDescription
        {
            get { return longDescription; }
            set { longDescription = value; }
        }

        private int category;

        /// <summary>
        /// Category the ticket falls in
        /// </summary>
        public int Category
        {
            get { return category; }
            set { category = value; }
        }


        private int userID;

        /// <summary>
        /// The User that opened the ticket
        /// </summary>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private DateTime openDate;
        /// <summary>
        /// The date when the ticket was opened
        /// </summary>
        public DateTime OpenDate
        {
            get { return openDate; }
            set { openDate = value; }
        }

        private DateTime lastUpdate;

        /// <summary>
        /// The date of the last update
        /// </summary>
        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }

        private DateTime completedDate;

        /// <summary>
        /// Present if the ticket has been completed. Null otherwise
        /// </summary>
        public DateTime CompletedDate
        {
            get { return completedDate; }
            set { completedDate = value; }
        }

        private int statusID;

        /// <summary>
        /// The status of the ticket
        /// </summary>
        public int StatusID
        {
            get { return statusID; }
            set { statusID = value; }
        }

        private int priorityID;

        /// <summary>
        /// The priority of the ticket
        /// </summary>
        public int PriorityID
        {
            get { return priorityID; }
            set { priorityID = value; }
        }

        private List<TicketUpdate> updates;

        /// <summary>
        /// List containing all the updates (TicketUpdate) to the ticket
        /// </summary>
        public List<TicketUpdate> Updates
        {
            get { return updates; }
            set { updates = value; }
        }

    }
}
