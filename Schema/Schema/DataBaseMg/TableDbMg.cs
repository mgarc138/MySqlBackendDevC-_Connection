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

        public List<string>[] GetContentOfTable(string tableName, List<string> attributes)
        {
            string request = "select * from " + "`" + tableName + "`";
            int size = attributes.Count;
            List<string>[] list = new List<string>[size];

            connection.Open();
            // create Command
            MySqlCommand cmd = new MySqlCommand(request, connection);
            // Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                for (int j = 0; j < attributes.Count; j++)
                {
                    list[j].Add(dataReader[attributes[j]] + "");
                }
            }

            dataReader.Close();
            connection.Close();

            return list;
        }

        
    }
}
