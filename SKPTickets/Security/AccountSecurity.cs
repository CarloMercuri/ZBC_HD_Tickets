using MySqlConnector;
using SKPTickets.Constants;
using SKPTickets.DataControl;
using SKPTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKPTickets.Security
{
    public static class AccountSecurity
    {
        /// <summary>
        /// Authenticates a user based on the provided username and cleartext password. Returns a complete PublicAccountDataModel if successful, or null if it failed.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static UserStandardAuthentication LoginUserPass(string email, string password)
        {
            UserStandardAuthentication authentication = new UserStandardAuthentication();
            using (MySqlConnection con = new MySqlConnection(DatabaseInterface.GetConnectionString()))
            {
                con.Open();

                string user_id = "";
                string user_email = "";
                string first_name = "";
                string last_name = "";
                string user_salt = "";
                string password_hash = "";
                bool is_active = false;

                string sql = $"SELECT * FROM users WHERE {DatabaseInterface.DB_COLUMN_ACCOUNTS_EMAIL} = @email";

                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                        {
                            authentication.Result = LoginResult.WrongCredentials;
                            authentication.Message = "Invalid username and/or password.";
                            return authentication;
                        }

                        while (rdr.Read())
                        {
                            user_id = rdr["id"].ToString();
                            user_salt = rdr[DatabaseInterface.DB_COLUMN_ACCOUNTS_USER_SALT].ToString();
                            password_hash = rdr[DatabaseInterface.DB_COLUMN_ACCOUNTS_PW_HASH].ToString();
                            user_email = rdr[DatabaseInterface.DB_COLUMN_ACCOUNTS_EMAIL].ToString();
                            first_name = rdr[DatabaseInterface.DB_COLUMN_ACCOUNTS_FIRST_NAME].ToString();
                            last_name = rdr[DatabaseInterface.DB_COLUMN_ACCOUNTS_LAST_NAME].ToString();
                            is_active = (bool)rdr[DatabaseInterface.DB_COLUMN_ACCOUNTS_IS_ACTIVE];
                        }
                    }
                }

                ZTEncryption encryption = new ZTEncryption();

                string hashedPw = encryption.HashPassword(password, Convert.FromBase64String(user_salt));

                // Main password check
                if (!hashedPw.Equals(password_hash))
                {
                    // !! Login failed !!
                    authentication.Result = LoginResult.WrongCredentials;
                    authentication.Message = "Invalid username and/or password.";
                    return authentication;
                }

                // Check that account is active
                if (!is_active)
                {
                    // !! Account inactive !!
                    authentication.Result = LoginResult.AccountInactive;
                    authentication.Message = "Account is inactive.";
                    return authentication;
                }

                // Success

                authentication.Result = LoginResult.Successful;
                authentication.Message = "Successfully logged in.";

                authentication.userModel = new PrivateAccountDataModel()
                {
                    Email = user_email,
                    FirstName = first_name,
                    LastName = last_name,
                };

                //SetUserSession(user_id);
            }

            return authentication;
        }

        //private static void SetUserSession(string id)
        //{
        //    string userRole = GetDatabaseUserRole(id);

        //    SessionManager.SetUser(id, userRole);
        //}

        private static string GetDatabaseUserRole(string id)
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

                        List<string> userRoles = new List<string>();

                        rdr.Read();
                        return rdr["role_name"].ToString();
                    }
                }


            }
        }

    }
}
