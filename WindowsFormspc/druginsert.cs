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
    public partial class druginsert : Form
    {
        string user;

        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();

        public druginsert()
        {
            InitializeComponent();
        }

        public druginsert(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            int supplier = int.Parse(comboBox1.SelectedValue.ToString());
            int minimum_order = int.Parse(textBox3.Text);


            try
            {
                int result = soapClient.InsertdrugWeb(name, supplier, minimum_order);
                if (result == 1)
                {
                    MessageBox.Show("new drug has been added");
                    var drugList = soapClient.getdrugWeb();


                    dataGridView1.DataSource = drugList;

                    dataGridView1.Columns["drug_id"].HeaderText = "drug_id";
                    dataGridView1.Columns["drug_name"].HeaderText = "drug_name";
                    dataGridView1.Columns["supplier_name"].HeaderText = "supplier_name";
                    dataGridView1.Columns["minimum_order"].HeaderText = "minimum_order";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.ToString());
            }
        }

        private void druginsert_Load(object sender, EventArgs e)
        {
            try
            {



                var drugList = soapClient.getdrugWeb();


                dataGridView1.DataSource = drugList;

                dataGridView1.Columns["drug_id"].HeaderText = "drug_id";
                dataGridView1.Columns["drug_name"].HeaderText = "drug_name";
                dataGridView1.Columns["supplier_name"].HeaderText = "supplier_name";
                dataGridView1.Columns["minimum_order"].HeaderText = "minimum_order";
                  }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }




            try
            {


                var quatationlist = soapClient.getsupplierWeb();






                foreach (var quatation in quatationlist)
                {
                    comboBox1.Items.Add(quatation.username);
                }



                comboBox1.DataSource = quatationlist;
                comboBox1.DisplayMember = "username";
                comboBox1.ValueMember = "supplier_id";

                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            supplierhome secondForm = new supplierhome(user);


            this.Hide();


            secondForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int drug_id = (int)dataGridView1.Rows[rowIndex].Cells["drug_id"].Value;

                int result = soapClient.DeletedrugWeb(drug_id);
                if (result == 1)
                {
                    MessageBox.Show("Drug Delete successfully.");
                    var drugList = soapClient.getdrugWeb();


                    dataGridView1.DataSource = drugList;

                    dataGridView1.Columns["drug_id"].HeaderText = "drug_id";
                    dataGridView1.Columns["drug_name"].HeaderText = "drug_name";
                    dataGridView1.Columns["supplier_name"].HeaderText = "supplier_name";
                    dataGridView1.Columns["minimum_order"].HeaderText = "minimum_order";
                }
            }
        }
    }
}
