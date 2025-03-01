using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace pharmacy_spc.data
{
    public class DataAccessLayer
    {
        static public SqlConnection CreateConnection()
        {
            string  connectionString = "Server=DESKTOP-LRIV16S\\SQLEXPRESS;Database=spcdb;Trusted_Connection=True;";

         
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}