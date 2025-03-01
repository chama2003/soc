using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using pharmacy_spc.data;
using pharmacy_spc.module;

namespace pharmacy_spc.controller
{
    public class orderController
    {
        public int InsertNeworder(Orders neworder)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertorderQuery = @"insert into [Orderss]
(drug_id,Total_price,quantity,unit_price,logged_phr)
values
(@drug_id,@Total_price,@quantity,@unit_price,@logged_phr)
";
            SqlCommand newcom = new SqlCommand(insertorderQuery, newCon);
            newcom.Parameters.AddWithValue("@drug_id", neworder.drug_id);
            newcom.Parameters.AddWithValue("@Total_price", neworder.Pharmacy_id);
            newcom.Parameters.AddWithValue("@quantity", neworder.quantity);
            newcom.Parameters.AddWithValue("@unit_price", neworder.unit_price);
            newcom.Parameters.AddWithValue("@logged_phr", neworder.logged_phr);
            newCon.Open();
            return newcom.ExecuteNonQuery();

        }


        public int Updateorder(Orders updatedOrders)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();

            // Update query: Add new quantity to the existing quantity_in_stock for the drug_id, only if the selling price matches.
            string updateStockQuery = @"UPDATE [Orderss]
SET quantity = quantity + @quantity, unit_price = @unit_price
WHERE drug_id = @drug_id AND Total_price = @Total_price AND logged_phr = @logged_phr";

            SqlCommand updateCommand = new SqlCommand(updateStockQuery, newCon);
            updateCommand.Parameters.AddWithValue("@drug_id", updatedOrders.drug_id);
            updateCommand.Parameters.AddWithValue("@Total_price", updatedOrders.Pharmacy_id);
            updateCommand.Parameters.AddWithValue("@quantity", updatedOrders.quantity);
            updateCommand.Parameters.AddWithValue("@unit_price", updatedOrders.unit_price);
            updateCommand.Parameters.AddWithValue("@logged_phr", updatedOrders.logged_phr);
            newCon.Open();
            return updateCommand.ExecuteNonQuery();
        }



    }
}