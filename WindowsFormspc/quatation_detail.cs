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
    public partial class quatation_detail : Form
    {
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();
        string user;
        public quatation_detail()
        {
            InitializeComponent();
        }
        public quatation_detail(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }
        private void quatation_detail_Load(object sender, EventArgs e)
        {
            var detaillist = soapClient.getquatationWeb();
            try
            {



                var quatation = soapClient.getsupplierquatationWeb(user);


                dataGridView2.DataSource = quatation;

                dataGridView2.Columns["quatation_id"].HeaderText = "quatation_id ";
                dataGridView2.Columns["quatation_date"].HeaderText = "quatation_date";
                dataGridView2.Columns["supplier_id"].HeaderText = "supplier_name";
                dataGridView2.Columns["supplier_name"].HeaderText = "username";
                dataGridView2.Columns["status"].HeaderText = "status";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            dataGridView1.Columns.Clear(); // Clear any existing columns (optional)
            dataGridView1.Columns.Add("unitprice", "Unit Price");
            dataGridView1.Columns.Add("quantity", "Quantity");
            dataGridView1.Columns.Add("drug_id", "Drug ID");
            dataGridView1.Columns["drug_id"].Visible = false;
           
            dataGridView1.Columns.Add("drugname", "Drug Name");
            dataGridView1.Columns.Add("quatationId", "Quotation ID");
            dataGridView1.Columns.Add("suppliername", "Supplier ID");
            try
            {


                var quatationlist = soapClient.getdrugWeb();
           




                foreach (var quatation in detaillist)
                {
                    comboBox3.Items.Add(quatation.quatation_id);
                    
                }

                foreach (var detail in quatationlist)
                {
                    comboBox1.Items.Add(detail.drug_name);
                    comboBox2.Items.Add(detail.supplier_name);

                }
               

                comboBox3.DataSource = detaillist;
                comboBox3.DisplayMember = "quatation_id";
                comboBox3.ValueMember = "quatation_id";

                comboBox1.DataSource = quatationlist;
                comboBox1.DisplayMember = "drug_name";
                comboBox1.ValueMember = "drug_id";

                comboBox2.DataSource = quatationlist;
                comboBox2.DisplayMember = "supplier_name";
                comboBox2.ValueMember = "supplier_id";



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Use TryParse to safely convert the input to integers
            int unitprice, quantity;

            // Check if textBox1 and textBox2 contain valid integers
            bool isUnitPriceValid = int.TryParse(textBox1.Text, out unitprice);
            bool isQuantityValid = int.TryParse(textBox2.Text, out quantity);

            if (!isUnitPriceValid || !isQuantityValid)
            {
                MessageBox.Show("Please enter valid numeric values for unit price and quantity.");
                return;  // Exit the method if inputs are not valid
            }

            // Safely cast the selected item to the correct types
            var selecteddrug = comboBox1.SelectedItem as ServiceReference1.Drugs;
            var selectedsupplier = comboBox2.SelectedItem as ServiceReference1.Drugs; // Cast to Supplier
            var selectedQuatation = comboBox3.SelectedItem as ServiceReference1.quatation; // Assuming comboBox3 is for quotations

            // Check if all selected items are valid (non-null)
            if (selectedQuatation != null && selecteddrug != null && selectedsupplier != null)
            {
                string drugname = selecteddrug.drug_name;
                int drugid = selecteddrug.drug_id;
                int quatationId = selectedQuatation.quatation_id;
                string suppliername = selectedsupplier.supplier_name;

                // Add the values to the DataGridView
                dataGridView1.Rows.Add( unitprice, quantity, drugid, drugname, quatationId, suppliername);

                // Clear the input fields after adding the row (optional)
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                // Display message if any of the required selections are missing
                MessageBox.Show("Please select valid drug, supplier, and quotation.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Access the values of the selected row
                int unitprice = (int)dataGridView1.Rows[rowIndex].Cells["unitprice"].Value;
                int qty = (int)dataGridView1.Rows[rowIndex].Cells["quantity"].Value;
                
                int drug_id = (int)dataGridView1.Rows[rowIndex].Cells["drug_id"].Value;
                int quatation_id = (int)dataGridView1.Rows[rowIndex].Cells["quatationId"].Value;  // Get supplier_id from the hidden column

                try
                {
                    int result = soapClient.Insertquatation_detailWeb(drug_id, qty, unitprice, quatation_id);
                    if (result == 1)
                    {
                        MessageBox.Show("New Tender send has been Succsess.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please select a row to perform the action.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            supplierhome secondForm = new supplierhome(user);


            this.Hide();


            secondForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                int rowIndex = dataGridView2.SelectedRows[0].Index;
                int quatation_id = (int)dataGridView2.Rows[rowIndex].Cells["quatation_id"].Value;

                int result = soapClient.DeleteQuatationWeb(quatation_id);
                if (result == 1)
                {
                    MessageBox.Show("quatation Delete successfully.");
                    var quatation = soapClient.getquatationWeb();


                    dataGridView2.DataSource = quatation;

                    dataGridView2.Columns["quatation_id"].HeaderText = "quatation_id ";
                    dataGridView2.Columns["quatation_date"].HeaderText = "quatation_date";
                    dataGridView2.Columns["supplier_id"].HeaderText = "supplier_name";
                    dataGridView2.Columns["supplier_name"].HeaderText = "username";
                    dataGridView2.Columns["status"].HeaderText = "status";

                }
            }
        }
    }
}
