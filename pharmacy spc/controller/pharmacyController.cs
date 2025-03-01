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
    public class pharmacyController
    {
        public int InsertNewpharmacy(Pharmacies newPharmacies)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertstockQuery = @"insert into pharmacy
(pharmacy_name,location,contact_number,email,password)values
(@pharmacy_name,@location,@contact_number,@email,@password)";
            SqlCommand newcom = new SqlCommand(insertstockQuery, newCon);

            newcom.Parameters.AddWithValue("@pharmacy_name", newPharmacies.pharmacy_name);
            newcom.Parameters.AddWithValue("@location", newPharmacies.location);
            newcom.Parameters.AddWithValue("@contact_number", newPharmacies.contact_number);
            newcom.Parameters.AddWithValue("@email", newPharmacies.email);
            newcom.Parameters.AddWithValue("@password", newPharmacies.password);
            newCon.Open();
            return newcom.ExecuteNonQuery();

        }

        public List<Pharmacies> Getpharmacie()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectsupplierQuery = @"select pharmacy_name,password from pharmacy";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectsupplierQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<Pharmacies> phamacylist = new List<Pharmacies>();

            foreach (DataRow r in dt.Rows)
            {
                phamacylist.Add(new Pharmacies
                {
                   
                    pharmacy_name = r[0].ToString(),
                 
                    password = r[1].ToString(),
                });
            }
            return phamacylist;

        }


    }
}