using MySqlConnector;
using SKPTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKPTickets.DataControl
{
    public static class DatabaseInterface
    {

        // Database strings

        public static string DB_COLUMN_ACTIVATION_EMAIL = "account_email";
        public static string DB_COLUMN_ACTIVATION_TOKEN = "activation_token";
        public static string DB_COLUMN_ACTIVATION_TOKEN_EXPIRATION = "token_expiration_datetime";

        public static string DB_COLUMN_ACCOUNTS_EMAIL = "email";
        public static string DB_COLUMN_ACCOUNTS_PW_HASH = "password_hash";
        public static string DB_COLUMN_ACCOUNTS_USER_SALT = "user_salt";
        public static string DB_COLUMN_ACCOUNTS_LAST_LOGIN_IP = "last_login_ip";
        public static string DB_COLUMN_ACCOUNTS_FIRST_NAME = "first_name";
        public static string DB_COLUMN_ACCOUNTS_LAST_NAME = "last_name";
        public static string DB_COLUMN_ACCOUNTS_IS_ACTIVE = "is_active";

        public static string GetConnectionString()
        {
            return "server=localhost;userid=root;password=;database=zbc_sp_tickets";
        }

       
        /// <summary>
        /// Returns the name of the role the user has
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetDatabaseUserRole(string id)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseInterface.GetConnectionString()))
            {
                con.Open();

                using (var cmd = new MySqlCommand("GetUserRole", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userID", id);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                        {
                            // If no match, return empty string to avoid errors
                            return string.Empty;
                        }

                        rdr.Read();
                        return rdr["name"].ToString();
                    }
                }


            }
        }

        public static bool InsertNewTicket(TicketModel model)
        {
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Open();

                string insertCommandString = $"INSERT into tickets(short_description, long_description, category_id, user_id, open_date, last_update_date, completed_date, status_id, priority_id)" +
                        " VALUES(@shortDescription, @longDescription, @category, @user, @openDate, @lastUpdate, @completedDate, @status, @priority)";


                using (var insertCommand = new MySqlCommand(insertCommandString, con))
                {
                    insertCommand.Parameters.AddWithValue("@shortDescription", model.ShortDescription);
                    insertCommand.Parameters.AddWithValue("@longDescription", model.LongDescription);
                    insertCommand.Parameters.AddWithValue("@category", model.Category);
                    insertCommand.Parameters.AddWithValue("@user", model.UserID);
                    insertCommand.Parameters.AddWithValue("@openDate", model.OpenDate);
                    insertCommand.Parameters.AddWithValue("@lastUpdate", model.LastUpdate);
                    insertCommand.Parameters.AddWithValue("@completedDate", model.CompletedDate);
                    insertCommand.Parameters.AddWithValue("@status", model.StatusID);
                    insertCommand.Parameters.AddWithValue("@priority", model.PriorityID);

                    if (insertCommand.ExecuteNonQuery() <= 0)
                    {
                        //ErrorLogger.AddError("Error with database, could not insert a new ticket");
                        // DATABASE ERROR
                        return false;
                    }


                }
            }

            // Success
            return true;
        }
    }



 }
