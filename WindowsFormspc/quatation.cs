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
    public partial class quatation : Form
    {
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();
        string user;
        public quatation()
        {
            InitializeComponent();
        }
        public quatation(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }
        private void quatation_Load(object sender, EventArgs e)
        {

            try
            {


                var quatationlist = soapClient.getdrugWeb();






                foreach (var quatation in quatationlist)
                {
                    comboBox1.Items.Add(quatation.supplier_name);
                }



                comboBox1.DataSource = quatationlist;
                comboBox1.DisplayMember = "supplier_name";
                comboBox1.ValueMember = "supplier_id";

                dataGridView1.Columns.Add("quotationDate", "Quotation Date");
                dataGridView1.Columns.Add("supplier", "Supplier");
                dataGridView1.Columns.Add("supplier_id", "Supplier_id");
               
                dataGridView1.Columns.Add("status", "Status");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }









         
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string quotationDate = textBox1.Text;

            // Safely cast the selected item to quatation type
            int selectedQuatation = int.Parse(comboBox1.SelectedValue.ToString());

            if (selectedQuatation != 0)
            {
                string supplier = comboBox1.DisplayMember.ToString();
                int supplierId = selectedQuatation;
                string status = textBox2.Text;

                // Add the values to the DataGridView
                dataGridView1.Rows.Add(quotationDate, supplier, supplierId, status);

                // Clear the input fields after adding the row (optional)
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Please select a valid supplier.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            staffhome secondForm = new staffhome();


            this.Hide();


            secondForm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int supplier_id = (int)dataGridView1.Rows[rowIndex].Cells["supplier_id"].Value;
            
                string quotationDate =dataGridView1.Rows[rowIndex].Cells["quotationDate"].Value.ToString();
                string status = dataGridView1.Rows[rowIndex].Cells["status"].Value.ToString();
                try {

                    int result = soapClient.InsertquatationWeb(quotationDate, supplier_id, status);
                    if (result == 1) {
                        MessageBox.Show("quatation submit success");
                    }
                }
                catch (Exception ex){

                    MessageBox.Show("error" + ex.ToString());
                }

            }

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
