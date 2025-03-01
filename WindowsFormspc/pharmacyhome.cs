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
    public partial class pharmacyhome : Form
    {
        string user;
        public pharmacyhome()
        {
            
            InitializeComponent();
        }
        public pharmacyhome(string userid)
        {
            this.user = userid;
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            search_drug s = new search_drug(user);
            this.Hide();
            s.Show();
            
        }

        private void logout_Click(object sender, EventArgs e)
        {
           Login s = new Login();
            this.Hide();
            s.Show();
        }

        private void pharmacyhome_Load(object sender, EventArgs e)
        {

        }
    }
}
