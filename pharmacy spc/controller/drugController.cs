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
    public class drugController
    {
        public int InsertNewdrug(Drugs newdrug)
        {        
       
        SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertstockQuery = @"insert into Drugs
(drug_name,supplier_id,minimum_order)values
(@drug_name,@supplier_id,@minimum_order)";
            SqlCommand newcom = new SqlCommand(insertstockQuery, newCon);
            newcom.Parameters.AddWithValue("@drug_name", newdrug.drug_name);
            newcom.Parameters.AddWithValue("@supplier_id", newdrug.supplier_id);
            newcom.Parameters.AddWithValue("@minimum_order", newdrug.minimum_order);
        
            newCon.Open();
            return newcom.ExecuteNonQuery();

        }

        public int InsertNewdrug1(Drugs newdrug)
        {

            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertstockQuery = @"insert into Drugs
(drug_name,minimum_order)values
(@drug_name,@minimum_order)";
            SqlCommand newcom = new SqlCommand(insertstockQuery, newCon);
            newcom.Parameters.AddWithValue("@drug_name", newdrug.drug_name);
            
            newcom.Parameters.AddWithValue("@minimum_order", newdrug.minimum_order);

            newCon.Open();
            return newcom.ExecuteNonQuery();

        }

        public List<Drugs> Getdrug()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectdrugQuery = 
                @"SELECT d.drug_id, d.drug_name,d.supplier_id,d.minimum_order,s.username
FROM Drugs d
JOIN supplier s ON d.supplier_id = s.supplier_id
";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectdrugQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<Drugs> druglist = new List<Drugs>();
           
            foreach (DataRow r in dt.Rows)
            {
                druglist.Add(new Drugs
                {
                    drug_id = int.Parse(r[0].ToString()),
                    drug_name = r[1].ToString(),
                    supplier_id = int.Parse(r[2].ToString()),
                    minimum_order = int.Parse(r[3].ToString()),
                    supplier_name = r[4].ToString()

                });
            }
            return druglist;

        }


        public List<Drugs> Getdrug1()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectdrugQuery = @"SELECT d.drug_id, d.drug_name, d.minimum_order
FROM Drugs d
WHERE d.supplier_id IS NULL

";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectdrugQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<Drugs> druglist = new List<Drugs>();

            foreach (DataRow r in dt.Rows)
            {
                druglist.Add(new Drugs
                {
                    drug_id = int.Parse(r[0].ToString()),
                    drug_name = r[1].ToString(),
                    
                    minimum_order = int.Parse(r[2].ToString()),
                   

                });
            }
            return druglist;

        }

        public List<Drugs> Getdrug2()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectdrugQuery = @"SELECT d.drug_id, d.drug_name, d.minimum_order
FROM Drugs d


";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectdrugQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<Drugs> druglist = new List<Drugs>();

            foreach (DataRow r in dt.Rows)
            {
                druglist.Add(new Drugs
                {
                    drug_id = int.Parse(r[0].ToString()),
                    drug_name = r[1].ToString(),

                    minimum_order = int.Parse(r[2].ToString()),


                });
            }
            return druglist;

        }


        public int Deletedrug(int drugId)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string deleteQuery = "DELETE FROM Drugs WHERE drug_id = @drug_id";

            SqlCommand newcom = new SqlCommand(deleteQuery, newCon);
            newcom.Parameters.AddWithValue("@drug_id", drugId);

            newCon.Open();
            int rowsAffected = newcom.ExecuteNonQuery();
            newCon.Close();

            return rowsAffected;
        }

    }
}