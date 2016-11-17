using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestSqlInjection
{
    class Program
    {
        static void Main()
        {
            string str = "Data Source = TESTUSER-PC\\SQLEXPRESS; " +
                "Initial Catalog=TSQL2012;" +
                "Integrated Security = True;";
            ReadOrderData(str);
        }

        private static void ReadOrderData(string connectionString)
        {
            var injection = "'%%' OR 1=1 --"; //SQL Injection
            injection = "@filter"; //prepared statement with parameter
            string queryString =
                "SELECT * FROM Sales.Orders WHERE shipname LIKE " + injection  + ";";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                SqlParameter param = new SqlParameter("@filter", injection);
                command.Parameters.Add(param);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                }

                // Call Close when done reading.
                reader.Close();
            }
        }

        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}", 
                record[0], record[1], record[2], record[3], record[4]));
        }
    }
}
