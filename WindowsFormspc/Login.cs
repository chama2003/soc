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
using WindowsFormspc.ServiceReference1;

namespace WindowsFormspc
{
    public partial class Login : Form
    {
        WebService1SoapClient soapClient = new WebService1SoapClient();
        public Login()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<spc> users = soapClient.GetSpcWeb();
            string enteredUserId = textBox1.Text;  
            string enteredPassword = textBox2.Text;
           
            try
            {
                
                
                bool credentialsCorrect = users.Any(user =>
                    user.user_id == enteredUserId && user.password == enteredPassword);

                if (credentialsCorrect)
                {
                    MessageBox.Show("Login successful! Redirecting...");

                    home newForm = new home(enteredUserId);
                    newForm.Show();
                    this.Hide();  
                }
                else
                {
                   
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string enteredUserId = textBox4.Text;

                // Attempt to parse the entered PIN (password) as an integer
                int enteredPassword;
                bool isPasswordValid = int.TryParse(textBox3.Text, out enteredPassword);

                if (!isPasswordValid)
                {
                    // If the entered password is not a valid integer, show an error message
                    MessageBox.Show("Please enter a valid numeric PIN.");
                    return;  // Exit the method early if the password is invalid
                }
                
                // Call the web service to get the supplier list
                var supplierList = soapClient.getsupplierWeb();

                // Check if supplierList is null or empty before attempting to access it
                if (supplierList == null || !supplierList.Any())
                {
                    MessageBox.Show("No suppliers found. Please contact support.");
                    return;
                }

                // Check if the entered credentials match any supplier in the list
                bool credentialsCorrect = supplierList.Any(user =>
                    user.username == enteredUserId && user.pin == enteredPassword);

                if (credentialsCorrect)
                {
                    // If credentials are correct, show a success message and redirect
                    MessageBox.Show("Login successful! Redirecting...");

                    supplierhome newForm = new supplierhome(enteredUserId);
                    newForm.Show();
                    this.Hide();  // Hide the login form
                }
                else
                {
                    // If credentials are incorrect, show an error message
                    MessageBox.Show("Invalid username or PIN. Please try again.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur (e.g., network issues, service not available)
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        int ComputeIntSha256Hash(int rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert integer to bytes
                byte[] bytes = BitConverter.GetBytes(rawData);

                // Compute hash
                byte[] hashBytes = sha256Hash.ComputeHash(bytes);

                // Convert first 4 bytes of hash to an integer
                return BitConverter.ToInt32(hashBytes, 0);
            }
        }

        string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
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
        private void button3_Click(object sender, EventArgs e)
        {
            var users = soapClient.getpharmaciesWeb();
            string enteredUserId = textBox6.Text;
            string enteredPassword = textBox5.Text;

            try
            {
              
                string hashedPassword = HashPassword(enteredPassword);
                bool credentialsCorrect = users.Any(user =>
                    user.pharmacy_name == enteredUserId && user.password == hashedPassword);

                if (credentialsCorrect)
                {
                    MessageBox.Show("Login successful! Redirecting...");

                    pharmacyhome newForm = new pharmacyhome(enteredUserId);
                    newForm.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SPC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var users = soapClient.GetWarehouses();
            string enteredUserId = textBox7.Text;
            string enteredPassword = textBox8.Text;

            try
            {

                
                bool credentialsCorrect = users.Any(user =>
                    user.staff_name == enteredUserId && user.password == enteredPassword);

                if (credentialsCorrect)
                {
                    MessageBox.Show("Login successful! Redirecting...");

                    staffhome newForm = new staffhome();
                    newForm.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        
            try
            {
                var users = soapClient.Getplantweb();
                string enteredUserId = textBox9.Text;
                int enteredPassword = int.Parse(textBox10.Text);


                bool credentialsCorrect = users.Any(user =>
                    user.plant_name == enteredUserId && user.pin == enteredPassword); 

                if (credentialsCorrect)
                {
                    MessageBox.Show("Login successful! Redirecting...");
                    planthome newForm = new planthome();
                    newForm.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
    }
}
