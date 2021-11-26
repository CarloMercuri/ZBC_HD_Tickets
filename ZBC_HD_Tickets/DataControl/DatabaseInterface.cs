using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZBC_HD_Tickets.DataControl
{
    public static class DatabaseInterface
    {
        public static string GetConnectionString()
        {
            return "server=localhost;userid=root;password=;database=zbc_sp_tickets";
        }

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
    }
}