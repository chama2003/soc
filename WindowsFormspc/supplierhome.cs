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
    public partial class supplierhome : Form
    {
        string user;
        public supplierhome()
        {
            InitializeComponent();
        }
        public supplierhome(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            quatation_detail secondForm = new quatation_detail(user);


            this.Hide();


            secondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            druginsert secondForm = new druginsert(user);


            this.Hide();


            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login secondForm = new Login();


            this.Hide();


            secondForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
