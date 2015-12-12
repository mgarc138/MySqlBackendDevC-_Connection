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

        public List<string> GetAttributeListFromTable(string tableName)
        {
            MySqlCommand command = connection.CreateCommand();
            /* Only get one row to reduce query time */
            command.CommandText = string.Format("SELECT * FROM {0} LIMIT 1", tableName);
            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();
            DataTable dt = reader.GetSchemaTable();
            List<string> attributeList = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                String columnName = row[dt.Columns["ColumnName"]].ToString();

                attributeList.Add(columnName);
            }

            reader.Close();
            connection.Close();

            return attributeList;

        }
        
    }
}
