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
    public class warehousecontroller
    {
        public int InsertNewwarehouse(warehouse_staff newWarehouse)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertstockQuery = @"insert into staff
(staff_name,staff_address,staff_email,staff_contact_number,password)values
(@staff_name,@staff_address,@staff_email,@staff_contact_number,@password)";
            SqlCommand newcom = new SqlCommand(insertstockQuery, newCon);
            newcom.Parameters.AddWithValue("@staff_name", newWarehouse.staff_name);
            newcom.Parameters.AddWithValue("@staff_address", newWarehouse.staff_address);
            newcom.Parameters.AddWithValue("@staff_email", newWarehouse.staff_email);
            newcom.Parameters.AddWithValue("@staff_contact_number", newWarehouse.staff_contact_number);
            newcom.Parameters.AddWithValue("@password", newWarehouse.password);
       
            newCon.Open();
            return newcom.ExecuteNonQuery();

        }
        public List<warehouse_staff> Getwarehouse()
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string selectwarehouseQuery = @"select * from staff";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectwarehouseQuery, newCon);
            DataTable dt = new DataTable();
            newCon.Open();
            da.Fill(dt);
            List<warehouse_staff> warehouselist = new List<warehouse_staff>();
          
            foreach (DataRow r in dt.Rows)
            {
                warehouselist.Add(new warehouse_staff
                {
                    staff_id = int.Parse(r[0].ToString()),
                    staff_name = r[1].ToString(),
                    staff_address = r[2].ToString(),
                    staff_email = r[3].ToString(),
                    staff_contact_number =  int.Parse(r[4].ToString()),
                    password = r[5].ToString(),
                });
            }
            return warehouselist;

        }
        public int Deletestaff(int staffId)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string deleteQuery = "DELETE FROM staff WHERE staff_id = @staff_id";

            SqlCommand newcom = new SqlCommand(deleteQuery, newCon);
            newcom.Parameters.AddWithValue("@staff_id", staffId);

            newCon.Open();
            int rowsAffected = newcom.ExecuteNonQuery();
            newCon.Close();

            return rowsAffected;
        }

    }
}