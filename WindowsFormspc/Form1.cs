using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormspc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            druginsert secondForm = new druginsert();


            this.Hide();


            secondForm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            search_drug secondForm = new search_drug();


            this.Hide();


            secondForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            quatation secondForm = new quatation();


            this.Hide();


            secondForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            quatation_detail secondForm = new quatation_detail();


            this.Hide();


            secondForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread progressThread = new Thread(ProgressBarTask);
            progressThread.Start();
        }


        private void ProgressBarTask()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(10);

                Invoke(new Action(() => progressBar1.Value = i));
            }

            Invoke(new Action(() =>
            {
                this.Hide();  
                Login secondForm = new Login();
                secondForm.Show();
            }));
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
