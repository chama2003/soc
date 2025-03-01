using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webform.ServiceReference1;

namespace webform.webform
{
    public partial class Login : System.Web.UI.Page
    {
        WebService1SoapClient soapClient = new WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<spc> users = soapClient.GetSpcWeb();
            string enteredUserId = TextBox2.Text;
            string enteredPassword = Password1.Value;
           

            try
            {


                bool credentialsCorrect = users.Any(user =>
                    user.user_id == enteredUserId && user.password == enteredPassword);

                if (credentialsCorrect)
                {
                    Response.Write("Login successful!");

                    home newForm = new home();
                    Response.Redirect($"home.aspx?userId={enteredUserId}");

                    
                }
                else
                {

                    Response.Write("UserName or password in correct!");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");

            }
        }
    }
}