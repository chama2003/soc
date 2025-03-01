using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormspc
{
    public partial class search_drug : Form
    {
        string userid;
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();

        public search_drug()
        {
            InitializeComponent();
        }
        public search_drug(string user)
        {
            this.userid = user;
            InitializeComponent();
        }
        private void search_drug_Load(object sender, EventArgs e)
        {
            try
            {


                var drugList = soapClient.getdrugWeb2();
               





                foreach (var drug in drugList)
                {
                    comboBox1.Items.Add(drug.drug_name);
                }
               


                comboBox1.DataSource = drugList;
                comboBox1.DisplayMember = "drug_name";
                comboBox1.ValueMember = "drug_id";




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Please select a drug.");
                    return;
                }


                int selectedDrug = Convert.ToInt32(comboBox1.SelectedValue);


                var stockList = soapClient.Getstockweb();


                var filteredStockList = stockList
                    .Where(stock => stock.drug_id == selectedDrug)
                    .Select(stock => new
                    {
                        stock.inventory_id,
                        stock.drug_name,
                        stock.drug_id,
                        stock.quantity_in_stock,
                        stock.selling_price,
                        stock.minimum_order
                    })
                    .ToList();

                if (filteredStockList.Any())
                {
                    dataGridView1.DataSource = filteredStockList;

                    // Set column headers
                    dataGridView1.Columns["inventory_id"].HeaderText = "inventory_id ";
                    dataGridView1.Columns["drug_name"].HeaderText = "drug_name";
                    dataGridView1.Columns["drug_id"].HeaderText = "drug_id";
                    dataGridView1.Columns["drug_id"].Visible = false;
                    dataGridView1.Columns["quantity_in_stock"].HeaderText = "quantity_in_stock";
                    dataGridView1.Columns["selling_price"].HeaderText = "selling_price";
                    dataGridView1.Columns["minimum_order"].HeaderText = "minimum_order";
                }
                else
                {
                    MessageBox.Show("No stock information available for the selected drug.");
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching stock data: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)


        {

            try
            {if (userid == "admin")
                {
                    int qty = int.Parse(textBox1.Text);

                    // Validate that a row is selected in the DataGridView
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        string logged = "SPC";
                        // Get the index of the selected row
                        int rowIndex = dataGridView1.SelectedRows[0].Index;
                        int drugId = (int)dataGridView1.Rows[rowIndex].Cells["drug_id"].Value;
                        int minimumOrder = (int)dataGridView1.Rows[rowIndex].Cells["minimum_order"].Value;
                        int quantityInStock = (int)dataGridView1.Rows[rowIndex].Cells["quantity_in_stock"].Value;
                        int unitPrice = (int)dataGridView1.Rows[rowIndex].Cells["selling_price"].Value;

                        // Validation for stock quantity and minimum order
                        if (qty <= 0)
                        {
                            MessageBox.Show("Please enter a valid quantity.");
                            return;
                        }

                        if (quantityInStock < qty)
                        {
                            MessageBox.Show("Stock is insufficient for the requested quantity.");
                        }
                        else if (qty < minimumOrder)
                        {
                            MessageBox.Show($"The selected quantity is below the minimum required level of {minimumOrder}.");
                        }



                        else
                        {
                            // If validation passes, proceed with stock update or order creation
                            int totalPrice = unitPrice * qty;

                            int updateResult = soapClient.UpdateorderWeb(drugId, totalPrice, qty, unitPrice, logged);
                            int stockUpdateResult = soapClient.UpdateStockWeb2(drugId, qty, unitPrice);

                            if (updateResult == 1)
                            {
                                MessageBox.Show("Stock has been updated.");
                            }
                            else
                            {
                                int insertResult = soapClient.InsertorderWeb(drugId, totalPrice, qty, unitPrice, logged);
                                if (insertResult == 1)
                                {
                                    MessageBox.Show("New stock has been added.");
                                }
                                else
                                {
                                    MessageBox.Show("Error while adding stock.");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a stock entry from the list.");
                    }
                }
                else {

                    int qty = int.Parse(textBox1.Text);

                    // Validate that a row is selected in the DataGridView
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Get the index of the selected row
                        int rowIndex = dataGridView1.SelectedRows[0].Index;
                        int drugId = (int)dataGridView1.Rows[rowIndex].Cells["drug_id"].Value;
                        int minimumOrder = (int)dataGridView1.Rows[rowIndex].Cells["minimum_order"].Value;
                        int quantityInStock = (int)dataGridView1.Rows[rowIndex].Cells["quantity_in_stock"].Value;
                        int unitPrice = (int)dataGridView1.Rows[rowIndex].Cells["selling_price"].Value;

                        // Validation for stock quantity and minimum order
                        if (qty <= 0)
                        {
                            MessageBox.Show("Please enter a valid quantity.");
                            return;
                        }

                        if (quantityInStock < qty)
                        {
                            MessageBox.Show("Stock is insufficient for the requested quantity.");
                        }
                        else if (qty < minimumOrder)
                        {
                            MessageBox.Show($"The selected quantity is below the minimum required level of {minimumOrder}.");
                        }



                        else
                        {
                            // If validation passes, proceed with stock update or order creation
                            int totalPrice = unitPrice * qty;

                            int updateResult = soapClient.UpdateorderWeb(drugId, totalPrice, qty, unitPrice, userid);
                            int stockUpdateResult = soapClient.UpdateStockWeb2(drugId, qty, unitPrice);

                            if (updateResult == 1)
                            {
                                MessageBox.Show("Stock has been updated.");
                            }
                            else
                            {
                                int insertResult = soapClient.InsertorderWeb(drugId, totalPrice, qty, unitPrice, userid);
                                if (insertResult == 1)
                                {
                                    MessageBox.Show("New stock has been added.");
                                }
                                else
                                {
                                    MessageBox.Show("Error while adding stock.");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a stock entry from the list.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var users = soapClient.getpharmaciesWeb();
            var usernames = users.Select(user => user.pharmacy_name).ToList();

            if (userid == "admin")
            {
                home home = new home(userid);
                this.Hide();
                home.Show();
            }
            else if (usernames.Contains(userid)) 
            {
                pharmacyhome home = new pharmacyhome(userid);
                this.Hide();
                home.Show();
            }
            

        }
    }
}