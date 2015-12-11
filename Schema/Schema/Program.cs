using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase MySqlServer = new DataBase();
            bool OpenServerSQLConnection = MySqlServer.OpenConnection();
            if (OpenServerSQLConnection == true)
            {
                Console.WriteLine("Connection succeed");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("Coonection has been fail");
                Console.ReadLine();
            }
        }
    }
}
