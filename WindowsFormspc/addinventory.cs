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
    public partial class addinventory : Form
    {
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();
        string user;
      
        public addinventory(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }
        public addinventory()
        {
            
            InitializeComponent();
        }

        private void addinventory_Load(object sender, EventArgs e)
        {
            try
            {



                var addList = soapClient.getquatation_detailWeb();


                dataGridView1.DataSource = addList;
                dataGridView1.Columns["qd_id"].HeaderText = "qd id";
                dataGridView1.Columns["drug_id"].Visible = false;
                dataGridView1.Columns["drug_name"].HeaderText = "Drug_name";
                dataGridView1.Columns["drug_id"].HeaderText = "drug_id";
                dataGridView1.Columns["drug_id"].Visible = false;
                dataGridView1.Columns["quantity"].HeaderText = "quantity";
                dataGridView1.Columns["unit_price"].HeaderText = "unit_price";
                dataGridView1.Columns["quatation_id"].HeaderText = "quatation_id";
                }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int Drug_id = (int)dataGridView1.Rows[rowIndex].Cells["Drug_id"].Value;
               
                int quantity1 = (int)dataGridView1.Rows[rowIndex].Cells["quantity"].Value;
                int unit_price = (int)dataGridView1.Rows[rowIndex].Cells["unit_price"].Value;

                try
                {
                    int quantity = int.Parse(textBox1.Text);
                    if (quantity1 >= quantity)
                    {
                        int result2 = soapClient.UpdateStockWeb(Drug_id, quantity, unit_price);

                        if (result2 == 1)
                        {
                            soapClient.UpdatequtationWeb(Drug_id, quantity, unit_price);
                            // If update is successful, show a message and do not add stock
                            MessageBox.Show("Stock has been updated.");
                            var addList = soapClient.getquatation_detailWeb();


                            dataGridView1.DataSource = addList;
                            dataGridView1.Columns["qd_id"].HeaderText = "qd id";
                            dataGridView1.Columns["drug_id"].Visible = false;
                            dataGridView1.Columns["drug_name"].HeaderText = "Drug_name";
                            dataGridView1.Columns["drug_id"].HeaderText = "drug_id";
                            dataGridView1.Columns["drug_id"].Visible = false;
                            dataGridView1.Columns["quantity"].HeaderText = "quantity";
                            dataGridView1.Columns["unit_price"].HeaderText = "unit_price";
                            dataGridView1.Columns["quatation_id"].HeaderText = "quatation_id";
                        }
                        else
                        {
                            // If update failed, add the stock
                            int result = soapClient.InsertstockrWeb(Drug_id, quantity, unit_price);

                            if (result == 1)
                            {
                                MessageBox.Show("New stock has been added.");
                                soapClient.UpdatequtationWeb(Drug_id, quantity, unit_price);
                                var addList = soapClient.getquatation_detailWeb();


                                dataGridView1.DataSource = addList;
                                dataGridView1.Columns["qd_id"].HeaderText = "qd id";
                                dataGridView1.Columns["drug_id"].Visible = false;
                                dataGridView1.Columns["drug_name"].HeaderText = "Drug_name";
                                dataGridView1.Columns["drug_id"].HeaderText = "drug_id";
                                dataGridView1.Columns["drug_id"].Visible = false;
                                dataGridView1.Columns["quantity"].HeaderText = "quantity";
                                dataGridView1.Columns["unit_price"].HeaderText = "unit_price";
                                dataGridView1.Columns["quatation_id"].HeaderText = "quatation_id";
                            }
                            else
                            {
                                MessageBox.Show("Error while adding stock.");
                            }
                        }
                    }
                    else {

                        MessageBox.Show("quanitiy is over.");
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
            staffhome newForm = new staffhome();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int qd_id = (int)dataGridView1.Rows[rowIndex].Cells["qd_id"].Value;

                int result = soapClient.DeleteQuatationDetailWeb(qd_id);
                if (result==1) {
                    MessageBox.Show("Tender Delete successfully.");
                    var addList = soapClient.getquatation_detailWeb();


                    dataGridView1.DataSource = addList;
                    dataGridView1.Columns["qd_id"].HeaderText = "qd id";
                    dataGridView1.Columns["drug_id"].Visible = false;
                    dataGridView1.Columns["drug_name"].HeaderText = "Drug_name";
                    dataGridView1.Columns["drug_id"].HeaderText = "drug_id";
                    dataGridView1.Columns["drug_id"].Visible = false;
                    dataGridView1.Columns["quantity"].HeaderText = "quantity";
                    dataGridView1.Columns["unit_price"].HeaderText = "unit_price";
                    dataGridView1.Columns["quatation_id"].HeaderText = "quatation_id";
                }
            }
        }
    }
}
