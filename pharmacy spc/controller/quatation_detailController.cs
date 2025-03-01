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
    public class quatation_detailController
    {
        public int InsertNewquatation_detail(quatation_detail newquatation_detail)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertquatation_detailQuery = @"insert into quatation_detail
(drug_id,quantity,unit_price,quatation_id)values
(@drug_id,@quantity,@unit_price,@quatation_id)";
            SqlCommand newcom = new SqlCommand(insertquatation_detailQuery, newCon);
            newcom.Parameters.AddWithValue("@drug_id", newquatation_detail.drug_id);
            newcom.Parameters.AddWithValue("@quantity", newquatation_detail.quantity);
            newcom.Parameters.AddWithValue("@unit_price", newquatation_detail.unit_price);
            newcom.Parameters.AddWithValue("@quatation_id", newquatation_detail.quatation_id);
             newCon.Open();
            return newcom.ExecuteNonQuery();

        }



        public List<quatation_detail> Getquatation()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectquatation_detailQuery = @"SELECT q.qd_id, q.drug_id, q.quantity, q.unit_price, q.quatation_id, d.drug_name
                                                  FROM quatation_detail q
                                                  JOIN Drugs d ON q.drug_id = d.drug_id
                                                      "
;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectquatation_detailQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<quatation_detail> quatation_detaillist = new List<quatation_detail>();

            foreach (DataRow r in dt.Rows)
            {
                quatation_detaillist.Add(new quatation_detail
                {
                    qd_id = int.Parse(r[0].ToString()),
                    drug_id = int.Parse(r[1].ToString()),
                    
                    quantity = int.Parse(r[2].ToString()),
                    unit_price = int.Parse(r[3].ToString()),
                   
                    quatation_id = int.Parse(r[4].ToString()),
                    
                    drug_name = r[5].ToString()
                });
            }
            return quatation_detaillist;

        }

        public int Updatequatation(quatation_detail updatedStock)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();

            // Update query: Add new quantity to the existing quantity_in_stock for the drug_id, only if the selling price matches.
            string updateStockQuery = @"
        UPDATE quatation_detail
        SET quantity = quantity -@quantity
        WHERE drug_id = @drug_id AND unit_price = @unit_price";

            SqlCommand updateCommand = new SqlCommand(updateStockQuery, newCon);
            updateCommand.Parameters.AddWithValue("@drug_id", updatedStock.drug_id);
            updateCommand.Parameters.AddWithValue("@quantity", updatedStock.quantity);
            updateCommand.Parameters.AddWithValue("@unit_price", updatedStock.unit_price);

            newCon.Open();
            return updateCommand.ExecuteNonQuery();
        }


        public int DeleteQuatationDetail(int quatationId)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string deleteQuery = "DELETE FROM quatation_detail WHERE qd_id = @qd_id";

            SqlCommand newcom = new SqlCommand(deleteQuery, newCon);
            newcom.Parameters.AddWithValue("@qd_id", quatationId);

            newCon.Open();
            int rowsAffected = newcom.ExecuteNonQuery();
            newCon.Close();

            return rowsAffected;
        }



    }
}