using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using pharmacy_spc.data;
using pharmacy_spc.module;

namespace pharmacy_spc.controller
{
    public class quatationController
    {
        public int InsertNewquatation(quatation newquatation)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertquatationQuery = @"insert into quatation
(quatation_date,supplier_id,status)values
(@quatation_date,@supplier_id,@status)";
            SqlCommand newcom = new SqlCommand(insertquatationQuery, newCon);
         
            newcom.Parameters.AddWithValue("@quatation_date", newquatation.quatation_date);
            newcom.Parameters.AddWithValue("@supplier_id", newquatation.supplier_id);
            newcom.Parameters.AddWithValue("@status", newquatation.status);
             newCon.Open();
            return newcom.ExecuteNonQuery();

        }

        public List<quatation> Getquatation()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectquatationQuery = @"SELECT q.quatation_id, q.quatation_date,q.supplier_id,s.username,q.status
FROM quatation q 
JOIN supplier s ON q.supplier_id = s.supplier_id
";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectquatationQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<quatation> quatationlist = new List<quatation>();

            foreach (DataRow r in dt.Rows)
            {
                quatationlist.Add(new quatation
                {
                    quatation_id= int.Parse(r[0].ToString()),
                    quatation_date = r[1].ToString(),
                   supplier_id = int.Parse(r[2].ToString()),
                    supplier_name = r[3].ToString(),
                   
                    status = r[4].ToString()
                  
                });
            }
            return quatationlist;

        }
        public List<quatation> Getsupplierquatation(string username)
        {
            List<quatation> quatationlist = new List<quatation>();

            using (SqlConnection newCon = DataAccessLayer.CreateConnection())
            {
                string selectquatationQuery = @"SELECT q.quatation_id, q.quatation_date,q.supplier_id,s.username,q.status
                                        FROM quatation q 
                                        JOIN supplier s ON q.supplier_id = s.supplier_id 
                                        WHERE s.username = @username";

                using (SqlCommand cmd = new SqlCommand(selectquatationQuery, newCon))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    newCon.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            quatationlist.Add(new quatation
                            {
                                quatation_id = reader.GetInt32(0),
                                quatation_date = reader.GetString(1),
                                supplier_id = reader.GetInt32(2),
                                supplier_name = reader.GetString(3),

                                status = reader.GetString(4)
                                
                            });
                        }
                    }
                }
            }

            return quatationlist;
        }





       








        public int DeleteQuatation(int quatationId)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string deleteQuery = "DELETE FROM quatation WHERE quatation_id = @quatation_id";

            SqlCommand newcom = new SqlCommand(deleteQuery, newCon);
            newcom.Parameters.AddWithValue("@quatation_id", quatationId);

            newCon.Open();
            int rowsAffected = newcom.ExecuteNonQuery();
            newCon.Close();

            return rowsAffected;
        }


    }
}