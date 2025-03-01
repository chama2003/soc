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
    public partial class home : Form
    {
        string user;
        public home()
        {
            InitializeComponent();
        }
        public home(string userid)
        {
            this.user = userid;

            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            supplierregis secondForm = new supplierregis(user);


            this.Hide();


            secondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search_drug secondForm = new search_drug(user);


            this.Hide();


            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            staffadd secondForm = new staffadd(user);


            this.Hide();


            secondForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login secondForm = new Login();


            this.Hide();


            secondForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            plantadd secondForm = new plantadd(user);


            this.Hide();


            secondForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            search_drug secondForm = new search_drug(user);


            this.Hide();


            secondForm.Show();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            pharmacy sec = new pharmacy(user);
            this.Hide();
            sec.Show();
        }
    }
}
