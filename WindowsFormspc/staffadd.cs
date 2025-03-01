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
    public partial class staffadd : Form
    {

        string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert byte to hexadecimal
                }
                return builder.ToString();
            }
        }

        string user;
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();
        public staffadd()
        {
            InitializeComponent();
        }
        public staffadd(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            string address = textBox2.Text;
            string email = textBox3.Text;
            int contact_number = int.Parse(textBox4.Text);
            string pin = textBox5.Text;
            string cpin = textBox6.Text;
            if (pin != cpin)
            {

                MessageBox.Show("The password you entered do not match. Please try again.");
            }
            else
            {
                try
                {
                    
                    int result = soapClient.InsertwarehouseWeb(name, address, email, contact_number, pin);
                    if (result == 1)
                    {
                        MessageBox.Show("new staff has been added");

                        var supplierList = soapClient.GetWarehouses();

                        dataGridView1.DataSource = supplierList;

                        dataGridView1.Columns["staff_id"].HeaderText = "staff_id";
                        dataGridView1.Columns["staff_name"].HeaderText = "staff_name";
                        dataGridView1.Columns["staff_address"].HeaderText = "staff_address";
                        dataGridView1.Columns["staff_email"].HeaderText = "staff_email";
                        dataGridView1.Columns["staff_contact_number"].HeaderText = "staff_contact_number";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.ToString());
                }
            }
        }

        private void staffadd_Load(object sender, EventArgs e)
        {
            try
            {

                var supplierList = soapClient.GetWarehouses();

                dataGridView1.DataSource = supplierList;

                dataGridView1.Columns["staff_id"].HeaderText = "staff_id";
                dataGridView1.Columns["staff_name"].HeaderText = "staff_name";
                dataGridView1.Columns["staff_address"].HeaderText = "staff_address";
                dataGridView1.Columns["staff_email"].HeaderText = "staff_email";
                dataGridView1.Columns["staff_contact_number"].HeaderText = "staff_contact_number";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int supplier_id = (int)dataGridView1.Rows[rowIndex].Cells["staff_id"].Value;

                int result = soapClient.DeletestaffWeb(supplier_id);
                if (result == 1)
                {
                    MessageBox.Show("staff Delete successfully.");
                    var supplierList = soapClient.GetWarehouses();

                    dataGridView1.DataSource = supplierList;

                    dataGridView1.Columns["staff_id"].HeaderText = "staff_id";
                    dataGridView1.Columns["staff_name"].HeaderText = "staff_name";
                    dataGridView1.Columns["staff_address"].HeaderText = "staff_address";
                    dataGridView1.Columns["staff_email"].HeaderText = "staff_email";
                    dataGridView1.Columns["staff_contact_number"].HeaderText = "staff_contact_number";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            home newForm = new home();
            newForm.Show();
            this.Hide();
        }
    }
}
