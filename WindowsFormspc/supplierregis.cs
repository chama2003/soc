using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormspc
{
    public partial class supplierregis : Form
    {
        string ComputeSha256Hash(int rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
               
                string rawString = rawData.ToString();

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawString));

                
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString(); 
            }
        }
        string user;
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();
       
        public supplierregis(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
                {
             string name = textBox1.Text;
            string address = textBox2.Text;
            string email = textBox3.Text;
            int contact_number = int.Parse(textBox4.Text);
            int pin = int.Parse(textBox5.Text);
           int cpin = int.Parse(textBox6.Text);
            if (pin != cpin)
            {
                
                MessageBox.Show("The PINs you entered do not match. Please try again.");
            }
            else
            {
                

                    
                    int result = soapClient.InsertsupplierWeb(name, address, email, contact_number, pin);
                    if (result == 1)
                    {

                        var supplierList = soapClient.getsupplierWeb();


                        dataGridView1.DataSource = supplierList;

                        dataGridView1.Columns["supplier_id"].HeaderText = "Supplier ID";
                        dataGridView1.Columns["username"].HeaderText = "username";
                        dataGridView1.Columns["address"].HeaderText = "Address";
                        dataGridView1.Columns["email"].HeaderText = "Email";
                        dataGridView1.Columns["contact_number"].HeaderText = "Contact Number";
                        MessageBox.Show("new supplier has been added");

                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.ToString());
            }
        }

        

        private void supplierregis_Load(object sender, EventArgs e)
        {
            try
            {
              

               
                var supplierList = soapClient.getsupplierWeb();

               
                dataGridView1.DataSource = supplierList;

                dataGridView1.Columns["supplier_id"].HeaderText = "Supplier ID";
                dataGridView1.Columns["username"].HeaderText = "username";
                dataGridView1.Columns["address"].HeaderText = "Address";
                dataGridView1.Columns["email"].HeaderText = "Email";
                dataGridView1.Columns["contact_number"].HeaderText = "Contact Number";
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {






        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            home secondForm = new home(user);


            this.Hide();


            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int supplier_id = (int)dataGridView1.Rows[rowIndex].Cells["supplier_id"].Value;

                int result = soapClient.DeletesupplierWeb(supplier_id);
                if (result == 1)
                {
                    MessageBox.Show("Supplier Delete successfully.");
                    var supplierList = soapClient.getsupplierWeb();


                    dataGridView1.DataSource = supplierList;

                    dataGridView1.Columns["supplier_id"].HeaderText = "Supplier ID";
                    dataGridView1.Columns["username"].HeaderText = "username";
                    dataGridView1.Columns["address"].HeaderText = "Address";
                    dataGridView1.Columns["email"].HeaderText = "Email";
                    dataGridView1.Columns["contact_number"].HeaderText = "Contact Number";
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
