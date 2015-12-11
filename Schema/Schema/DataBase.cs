using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Schema
{
    class DataBase
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DataBase()
        {
            // Initalize the database connection
            Initializer();
        }

        // Initialize database connection and creates an instace of it
        private void Initializer()
        {
            // server IP
            server = "xxx.xxx.xxx.xx";
            // database name
            database = "database_no1";
            // user Id
            uid = "user_Id";
            // User Password
            password = "xxxxxxx";
            // set up the connection with mySQlDatabase
            string connectionString;
            connectionString = "Server=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }


        //open the conncetion of the database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }

            catch (MySqlException ex)
            {
                /*  When handling errors, you can your application's response based 
                    on the error number.
                    The two most common error numbers when connecting are as follows:
                    0: Cannot connect to server.
                    1045: Invalid user name and/or password.
                */
                switch (ex.Number)
                {
                    case 0:
                        Console.Write("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        Console.Write("Invalid username/password, please try again");
                        break;
                }

                return false;
            }
        }

        // Close the connection of the database
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }

            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

    }
}
