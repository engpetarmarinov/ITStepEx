using System;
using System.Data;
using System.Data.SqlClient;

namespace TestSqlInjection
{
    class Program
    {
        static void Main()
        {
            string str = 
                "Data Source = TESTUSER-PC\\SQLEXPRESS; " +
                //"Data Source = WILDALMIGHTY; " + 
                "Initial Catalog=TSQL2012;" +
                "Integrated Security = True;";
            ReadOrderData(str);
        }

        private static void ReadOrderData(string connectionString)
        {
            var injectionString = "'%%' OR 1=1 --"; //SQL Injection
            var injection = injectionString;
            //injection = "@filter"; //prepared statement with parameter
            string queryString =
                "SELECT * FROM Sales.Orders WHERE shipname LIKE " + injection  + ";";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                SqlParameter param = new SqlParameter("@filter", injectionString);
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
            Console.WriteLine(
                $"{record[0]}, {record[1]}, {record[2]}, {record[3]}, {record[4]}, {record[5]}, {record[6]}"
            );
        }
    }
}
