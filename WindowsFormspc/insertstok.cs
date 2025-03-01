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
    public partial class insertstok : Form
    {
        string user;
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();
      
        public insertstok(string userid)
        {
            InitializeComponent();
            this.user = userid;
        }
        public insertstok( )
        {
            InitializeComponent();
           
        }
        private void insertstok_Load(object sender, EventArgs e)
        {

          

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
      
          
           
                try
                {
                string name = textBox2.Text;
                int order = int.Parse(textBox1.Text);
                int result = soapClient.InsertdrugWeb1(name, order);
                    if (result == 1)
                    {
                        MessageBox.Show("new drug has been added");

                    var drugList = soapClient.getdrugWeb1();


                    dataGridView1.DataSource = drugList;

                    dataGridView1.Columns["drug_id"].HeaderText = "drug ID";
                    dataGridView1.Columns["drug_name"].HeaderText = "drug_name";
                    dataGridView1.Columns["minimum_order"].HeaderText = "minimum_order";
                   

                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.ToString());
                }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int quantity =int.Parse (textBox3.Text);
                int unit_price = int.Parse(textBox5.Text);
                // Get the index of the selected row
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int Drug_id = (int)dataGridView1.Rows[rowIndex].Cells["drug_id"].Value;
                
              

                    try
                    {
                       
                        int result4 = soapClient.UpdateStockWeb(Drug_id, quantity, unit_price);

                    if (result4 == 1)
                    {

                        // If update is successful, show a message and do not add stock
                        MessageBox.Show("Stock has been updated.");
                    }
                    else
                    {
                        // If update failed, add the stock

                        int result3 = soapClient.InsertstockrWeb(Drug_id, quantity, unit_price);

                        if (result3 == 1)
                        {
                            MessageBox.Show("New stock has been added.");
                        }
                        else
                        {
                            MessageBox.Show("Error while adding stock.");
                        }
                    }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.ToString());
                    }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            planthome newForm = new planthome();
            newForm.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
