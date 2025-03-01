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
    public class SupplierController
    {
        public int InsertNewsupplier(supplier newsupplier)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertsupplierQuery = @"insert into supplier
(username,Supplieraddress,Supplieremail,Suppliercontact_number,pin)values
(@username,@Supplieraddress,@Supplieremail,@Suppliercontact_number,@pin)";
            SqlCommand newcom = new SqlCommand(insertsupplierQuery, newCon);
            newcom.Parameters.AddWithValue("@username", newsupplier.username);          
            newcom.Parameters.AddWithValue("@Supplieraddress", newsupplier.address);
            newcom.Parameters.AddWithValue("@Supplieremail", newsupplier.email);
            newcom.Parameters.AddWithValue("@Suppliercontact_number", newsupplier.contact_number);
            newcom.Parameters.AddWithValue("@pin", newsupplier.pin);
            newCon.Open();
            return newcom.ExecuteNonQuery();

        }

        public int Deletesupplier(int supplierId)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string deleteQuery = "DELETE FROM supplier WHERE supplier_id = @supplier_id";

            SqlCommand newcom = new SqlCommand(deleteQuery, newCon);
            newcom.Parameters.AddWithValue("@supplier_id", supplierId);

            newCon.Open();
            int rowsAffected = newcom.ExecuteNonQuery();
            newCon.Close();

            return rowsAffected;
        }

        public List<supplier> Getsupplier()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectsupplierQuery = @"select * from supplier";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectsupplierQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<supplier> supplierlist = new List<supplier>();
          
            foreach (DataRow r in dt.Rows)
            {
                supplierlist.Add(new supplier
                {
                    supplier_id = int.Parse(r[0].ToString()),
                    username = r[1].ToString(),
                    address = r[2].ToString(),
                    email = r[3].ToString(),
                    contact_number = int.Parse(r[4].ToString()),
                    pin = int.Parse(r[5].ToString())
                });
            }
            return supplierlist;

        }


    }
}