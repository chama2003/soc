using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform.webform
{
    public partial class home : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Request.QueryString["userId"];
            if (userId != null)
            {
                // Use the userId to display a personalized message or load data for the user
                Response.Write($"Welcome, {userId}!");
            }
        }
    }
}