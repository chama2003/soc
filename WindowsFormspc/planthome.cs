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
    public partial class planthome : Form
    {
        public planthome()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            insertstok newForm = new insertstok();
            newForm.Show();
            this.Hide();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login newForm = new Login();
            newForm.Show();
            this.Hide();
        }
    }
}
