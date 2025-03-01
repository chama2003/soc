using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ServiceReference1.WebService1SoapClient soapClient = new ServiceReference1.WebService1SoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string fullName = TextBox2.Text;
                string address = TextBox1.Text;
                string email = TextBox3.Text;
                int contactNumber =int.Parse (TextBox4.Text);
                int newPin = int.Parse(TextBox6.Text);
                int confirmPin = int.Parse(TextBox5.Text);


                if (newPin != confirmPin)
                {
                    // Show a message if the pins do not match
                    Response.Write("<script>alert('Pins do not match.');</script>");
                    return;
                }
                else {

                    try
                    {
                        int result = soapClient.InsertsupplierWeb(fullName, address, email, contactNumber, newPin);
                        if (result == 1)
                        {
                            
                            Response.Write("<script>alert('Supplier added successfully.');</script>");

                        }
                    }
                    catch (Exception ex)
                    {
                       
                        Response.Write("<script>alert('Error: " + ex.Message + "');</script>");

                    }
                }

              
            }
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }


    }
}