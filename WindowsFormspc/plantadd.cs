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
    public partial class plantadd : Form
    {
        int ComputeSha256Hash(int rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert integer to string before hashing
                string rawString = rawData.ToString();

                // Compute SHA-256 hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawString));

                // Convert first 4 bytes of hash into an integer (to keep PIN numeric)
                return BitConverter.ToInt32(bytes, 0);
            }
        }
        string user;
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();
        public plantadd()
        {
            InitializeComponent();
        }
        public plantadd(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            int address = int.Parse(textBox2.Text);

            int pin = int.Parse(textBox3.Text);
            int cpin = int.Parse(textBox4.Text);
            if (pin != cpin)
            {

                MessageBox.Show("The PINs you entered do not match. Please try again.");
            }
            else
            {
                try
                {

                    int result = soapClient.InsertplantWeb(name, address, pin);
                    if (result == 1)
                    {
                        MessageBox.Show("new plant has been added");
                        var supplierList = soapClient.Getplantweb();


                        dataGridView1.DataSource = supplierList;

                        dataGridView1.Columns["plant_id"].HeaderText = "plant_id";
                        dataGridView1.Columns["plant_name"].HeaderText = "plant_name";
                        dataGridView1.Columns["contact"].HeaderText = "contact";


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.ToString());
                }
            }
        }

        private void plantadd_Load(object sender, EventArgs e)
        {
            try
            {

                var supplierList = soapClient.Getplantweb();


                dataGridView1.DataSource = supplierList;

                dataGridView1.Columns["plant_id"].HeaderText = "plant_id";
                dataGridView1.Columns["plant_name"].HeaderText = "plant_name";
                dataGridView1.Columns["contact"].HeaderText = "contact";
              
                

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
                int supplier_id = (int)dataGridView1.Rows[rowIndex].Cells["plant_id"].Value;

                int result = soapClient.DeleteplantWeb(supplier_id);
                if (result == 1)
                {
                    MessageBox.Show("plant Delete successfully.");
                    var supplierList = soapClient.Getplantweb();


                    dataGridView1.DataSource = supplierList;

                    dataGridView1.Columns["plant_id"].HeaderText = "plant_id";
                    dataGridView1.Columns["plant_name"].HeaderText = "plant_name";
                    dataGridView1.Columns["contact"].HeaderText = "contact";

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
