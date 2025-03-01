using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using pharmacy_spc.controller;
using pharmacy_spc.module;

namespace pharmacy_spc
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public int InsertsupplierWeb(string username, string Supplieraddress, string Supplieremail, int Suppliercontact_number, int pin)
        {
            supplier d = new supplier();
            d.username = username;
            d.address= Supplieraddress;
            d.email = Supplieremail;
            d.contact_number = Suppliercontact_number;
            d.pin = pin;
            return new SupplierController().InsertNewsupplier(d);
        }

        [WebMethod]

        public List<supplier> getsupplierWeb()
        {


            return new SupplierController().Getsupplier();
        }

       
        [WebMethod]
        public List<spc> GetSpcWeb()
        {
            // Sample credentials
            string userId = "admin";
            string password = "admin";

            // Store user credentials via the spcController class
            spcController.StoreCredentials(userId, password);

            // Return the list of stored users from spcController
            return spcController.GetUsers();
        }


        [WebMethod]
        public int InsertpharmacyWeb(string pharmacy_name, string location, int  contact_number, string email, string password)
        {
            Pharmacies d = new Pharmacies();
            d.pharmacy_name = pharmacy_name;
            d.location = location;
            d.contact_number = contact_number;
            d.email = email;
            d.password = password;
            return new pharmacyController().InsertNewpharmacy(d);
        }
        [WebMethod]
        public int InsertorderWeb(int drug_id, int Pharmacy_id, int quantity, int unit_price,string user)
        {
            Orders d = new Orders();
            d.drug_id = drug_id;
            d.Pharmacy_id = Pharmacy_id;
            d.quantity = quantity;
            d.unit_price = unit_price;
            d.logged_phr = user;
            return new orderController().InsertNeworder(d);
        }


        

        [WebMethod]
        public int InsertwarehouseWeb(string staff_name, string staff_address, string staff_email, int staff_contact_number, string password)
        {
            warehouse_staff d = new warehouse_staff();
            d.staff_name = staff_name;
            d.staff_address = staff_address;
            d.staff_email = staff_email;
            d.staff_contact_number = staff_contact_number;
            d.password = password;
            
            return new warehousecontroller().InsertNewwarehouse(d);
        }

      


        [WebMethod]
        public int InsertdrugWeb(string drug_name, int supplier_id, int minimum_order)
        {
            Drugs d = new Drugs();
            d.drug_name = drug_name;
            d.supplier_id = supplier_id;
            d.minimum_order = minimum_order;

            return new drugController().InsertNewdrug(d);
        }


        [WebMethod]
        public int InsertdrugWeb1(string drug_name, int minimum_order)
        {
            Drugs d = new Drugs();
            d.drug_name = drug_name;
         
            d.minimum_order = minimum_order;

            return new drugController().InsertNewdrug1(d);
        }

        [WebMethod]

        public List<Drugs> getdrugWeb()
        {


            return new drugController().Getdrug();
        }

        [WebMethod]

        public List<Pharmacies> getpharmaciesWeb()
        {


            return new pharmacyController().Getpharmacie();
        }

        [WebMethod]

        public List<Drugs> getdrugWeb1()
        {


            return new drugController().Getdrug1();
        }

        [WebMethod]
        public List<Drugs> getdrugWeb2()
        {


            return new drugController().Getdrug2();
        }
        [WebMethod]
        public List<warehouse_staff> GetWarehouses()
        {
            return new warehousecontroller().Getwarehouse();
        }
        [WebMethod]
        public List<Warehouse_Stock> Getstockweb()
        {
            return new warehouse_stockController().GetData();
        }
        [WebMethod]
        public List<Manufacturing_Plants> Getplantweb()
        {
            return new Manufacturing_PlantsController().Getplant();
        }

        [WebMethod]
        public int InsertstockrWeb(int drug_id,  int quantity_in_stock, int selling_price)
        {
            Warehouse_Stock d = new Warehouse_Stock();
            d.drug_id = drug_id;
            d.quantity_in_stock = quantity_in_stock;
            d.selling_price = selling_price;

            return new warehouse_stockController().InsertNewstock(d);
        }

        [WebMethod]
        public int InsertplantWeb(string plant_name, int contact, int pin)
        {
            Manufacturing_Plants d = new Manufacturing_Plants();
            d.plant_name = plant_name;
            d.contact = contact;
            d.pin = pin;

            return new Manufacturing_PlantsController().InsertNewplantdrug(d);
        }


        [WebMethod]
        public int InsertquatationWeb(string quatation_date, int supplier_id, string status)
        {
            quatation d = new quatation();
            d.quatation_date = quatation_date;
            d.supplier_id = supplier_id;
            d.status = status;

            return new quatationController().InsertNewquatation(d);
        }

        [WebMethod]

        public List<quatation> getquatationWeb()
        {


            return new quatationController().Getquatation();
        }

        [WebMethod]
        public int Insertquatation_detailWeb(int drug_id, int quantity, int unit_price,int quatation_id)
        {
            quatation_detail d = new quatation_detail();
            d.drug_id = drug_id;
            d.quantity = quantity;
            d.unit_price = unit_price;
            d.quatation_id= quatation_id;

            return new quatation_detailController().InsertNewquatation_detail(d);
        }
        [WebMethod]
        public int DeleteQuatationDetailWeb(int quatationDetailId)
        {
            return new quatation_detailController().DeleteQuatationDetail(quatationDetailId);
        }

        [WebMethod]
        public int DeleteQuatationWeb(int quatationDetailId)
        {
            return new quatationController().DeleteQuatation(quatationDetailId);
        }

        [WebMethod]
        public int DeletedrugWeb(int drugId)
        {
            return new drugController().Deletedrug(drugId);
        }
        [WebMethod]
        public int DeletesupplierWeb(int supplierId)
        {
            return new SupplierController().Deletesupplier(supplierId);
        }
       

        [WebMethod]

        public List<quatation_detail> getquatation_detailWeb()
        {


            return new quatation_detailController().Getquatation();
        }
        [WebMethod]

        public List<quatation> getsupplierquatationWeb(string username)
        {


            return new quatationController().Getsupplierquatation(username);
        }

        [WebMethod]
        public int UpdateStockWeb(int drug_id, int quantity_in_stock, int selling_price)
        {
            Warehouse_Stock updatedStock = new Warehouse_Stock();
            updatedStock.drug_id = drug_id;
            updatedStock.quantity_in_stock = quantity_in_stock;
            updatedStock.selling_price = selling_price;

            return new warehouse_stockController().UpdateStock(updatedStock);
        }
        [WebMethod]
        public int UpdatequtationWeb(int drug_id, int quantity_in_stock, int selling_price)
        {
            quatation_detail updatedStock = new quatation_detail();
            updatedStock.drug_id = drug_id;
            updatedStock.quantity = quantity_in_stock;
            updatedStock.unit_price = selling_price;

            return new quatation_detailController().Updatequatation(updatedStock);
        }
        [WebMethod]
        public int UpdateorderWeb(int drug_id, int Pharmacy_id, int quantity,int unit_price,string user)
        {
            Orders updatedStock = new Orders();
            updatedStock.drug_id = drug_id;
            updatedStock.Pharmacy_id = Pharmacy_id;
            updatedStock.quantity = quantity;
            updatedStock.unit_price = unit_price;
            updatedStock.logged_phr = user;
            Orders d = new Orders();
            
            return new orderController().Updateorder(updatedStock);
        }


        [WebMethod]
        public int UpdateStockWeb2(int drug_id, int quantity_in_stock, int selling_price)
        {
            Warehouse_Stock updatedStock = new Warehouse_Stock();
            updatedStock.drug_id = drug_id;
            updatedStock.quantity_in_stock = quantity_in_stock;
            updatedStock.selling_price = selling_price;

            return new warehouse_stockController().UpdateStock2(updatedStock);
        }




        [WebMethod]
        public int DeletestaffWeb(int staffId)
        {
            return new warehousecontroller().Deletestaff(staffId);
        }
        [WebMethod]
        public int DeleteplantWeb(int plantId)
        {
            return new Manufacturing_PlantsController().Deleteplant(plantId);
        }


    }
}
