using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Schema.DataBaseMg
{
    class TableDbMg : DataBase
    {
        public TableDbMg()
            : base()
        {

        }

        public List<string> GetListOfTableNames()
        {
            connection.Open();
            DataTable dt = connection.GetSchema("tables");
            List<string> tableNames = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string tableName = (string)row[2];
                tableNames.Add(tableName);
            }
            
            connection.Close();

            return tableNames;
        }
        
    }
}
