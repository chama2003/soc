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
    public partial class pharmacy : Form
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
       
        public pharmacy(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }
        public pharmacy()
        {
         
            InitializeComponent();
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash of the password
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string pharmacy = textBox1.Text;
            string location = textBox2.Text;
            int number = int.Parse(textBox3.Text);
            string email = textBox4.Text;
            string password = textBox5.Text;
            string cpassword = textBox6.Text;

            // Check if passwords match
            if (password != cpassword)
            {
                MessageBox.Show("The Passwords you entered do not match. Please try again.");
            }
            else
            {
                try
                {
                    // Hash the password before saving
                    string hashedPassword = HashPassword(password);

                    // Call the SOAP client to insert the pharmacy with the hashed password
                    int results = soapClient.InsertpharmacyWeb(pharmacy, location, number, email, hashedPassword);

                    if (results == 1)
                    {
                        MessageBox.Show("Pharmacy added successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            home home = new home(user);
            this.Hide();
            home.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
