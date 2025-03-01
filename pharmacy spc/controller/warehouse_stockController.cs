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
    public class warehouse_stockController
    {
        public int InsertNewstock(Warehouse_Stock newstock)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();
            string insertstockQuery = @"insert into inventorystock
(drug_id,quantity_in_stock,selling_price)values
(@drug_id,@quantity_in_stock,@selling_price)";
            SqlCommand newcom = new SqlCommand(insertstockQuery, newCon);
            newcom.Parameters.AddWithValue("@drug_id", newstock.drug_id);            
            newcom.Parameters.AddWithValue("@quantity_in_stock", newstock.quantity_in_stock);
            newcom.Parameters.AddWithValue("@selling_price", newstock.selling_price);
            newCon.Open();
            return newcom.ExecuteNonQuery();

        }


        public int UpdateStock(Warehouse_Stock updatedStock)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();

            // Update query: Add new quantity to the existing quantity_in_stock for the drug_id, only if the selling price matches.
            string updateStockQuery = @"
        UPDATE inventorystock
        SET quantity_in_stock = quantity_in_stock + @quantity_in_stock
        WHERE drug_id = @drug_id AND selling_price = @selling_price";

            SqlCommand updateCommand = new SqlCommand(updateStockQuery, newCon);
            updateCommand.Parameters.AddWithValue("@drug_id", updatedStock.drug_id);
            updateCommand.Parameters.AddWithValue("@quantity_in_stock", updatedStock.quantity_in_stock);
            updateCommand.Parameters.AddWithValue("@selling_price", updatedStock.selling_price);

            newCon.Open();
            return updateCommand.ExecuteNonQuery();
        }

        public int UpdateStock2(Warehouse_Stock updatedStock)
        {
            SqlConnection newCon = DataAccessLayer.CreateConnection();

            // Update query: Add new quantity to the existing quantity_in_stock for the drug_id, only if the selling price matches.
            string updateStockQuery = @"
        UPDATE inventorystock
        SET quantity_in_stock = quantity_in_stock -@quantity_in_stock
        WHERE drug_id = @drug_id AND selling_price = @selling_price";

            SqlCommand updateCommand = new SqlCommand(updateStockQuery, newCon);
            updateCommand.Parameters.AddWithValue("@drug_id", updatedStock.drug_id);
            updateCommand.Parameters.AddWithValue("@quantity_in_stock", updatedStock.quantity_in_stock);
            updateCommand.Parameters.AddWithValue("@selling_price", updatedStock.selling_price);

            newCon.Open();
            return updateCommand.ExecuteNonQuery();
        }


        public List<Warehouse_Stock> GetData()
            {
                SqlConnection newCon = DataAccessLayer.CreateConnection();
                string selectdrugQuery = @"SELECT i.inventory_id, i.drug_id, i.quantity_in_stock, i.selling_price, d.drug_name , d.minimum_order
                                                  FROM inventorystock i
                                                  JOIN Drugs d ON i.drug_id = d.drug_id
                                                   ";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(selectdrugQuery, newCon);
                DataTable dt = new DataTable();
                newCon.Open();
                da.Fill(dt);
                List<Warehouse_Stock> stocklist = new List<Warehouse_Stock>();

                foreach (DataRow r in dt.Rows)
                {
                    stocklist.Add(new Warehouse_Stock
                    {
                        inventory_id = int.Parse(r[0].ToString()),
                        drug_id = int.Parse(r[1].ToString()),

                        quantity_in_stock = int.Parse(r[2].ToString()),
                        selling_price = int.Parse(r[3].ToString()),
                        drug_name = r[4].ToString(),
                        minimum_order = int.Parse(r[5].ToString()),
                    });
                }
                return stocklist;

            }

        }




    }
