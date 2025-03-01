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
    public class Manufacturing_PlantsController
    {
        public int InsertNewplantdrug(Manufacturing_Plants newstaff)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertwarehouse_staffQuery = @"insert into ManufacturingPlants
(plant_name,contact,pin)values
(@plant_name,@contact,@pin)";
            SqlCommand newcom = new SqlCommand(insertwarehouse_staffQuery, newCon);
            
            newcom.Parameters.AddWithValue("@plant_name", newstaff.plant_name);
            newcom.Parameters.AddWithValue("@contact", newstaff.contact);
            newcom.Parameters.AddWithValue("@pin", newstaff.pin);
           newCon.Open();
            return newcom.ExecuteNonQuery();

        }

       



        public List<Manufacturing_Plants> Getplant()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectsupplierQuery = @"select * from ManufacturingPlants";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectsupplierQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<Manufacturing_Plants> plantlist = new List<Manufacturing_Plants>();

            foreach (DataRow r in dt.Rows)
            {
                plantlist.Add(new Manufacturing_Plants
                {
                    plant_id = int.Parse(r[0].ToString()),
                    plant_name = r[1].ToString(),
                    contact = int.Parse(r[2].ToString()),
                    pin = int.Parse(r[3].ToString()),

                });
            }
            return plantlist;

        }


        public int Deleteplant(int plantid)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string deleteQuery = "DELETE FROM ManufacturingPlants WHERE plant_id = @plant_id";

            SqlCommand newcom = new SqlCommand(deleteQuery, newCon);
            newcom.Parameters.AddWithValue("@plant_id", plantid);

            newCon.Open();
            int rowsAffected = newcom.ExecuteNonQuery();
            newCon.Close();

            return rowsAffected;
        }

    }
}