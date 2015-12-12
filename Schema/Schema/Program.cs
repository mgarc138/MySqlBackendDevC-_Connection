using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema.DataBaseMg;

namespace Schema
{
    class Program
    {
        static void Main(string[] args)
        {
            TableDbMg MySqlServer = new TableDbMg();
            bool OpenServerSQLConnection = MySqlServer.OpenConnection();
            if (OpenServerSQLConnection == true)
            {
                Console.WriteLine("Connection succeed");
                Console.ReadLine();
                
                //returns a list of all the table names from the database selected
                List<string> tables = MySqlServer.GetListOfTableNames();
            }

            else
            {
                Console.WriteLine("Coonection has been fail");
                Console.ReadLine();
            }
        }
    }
}
