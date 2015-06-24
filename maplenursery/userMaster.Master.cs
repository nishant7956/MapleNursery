using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maplenursery
{
    public partial class userMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(maplenursery.login.name=="")
            if (HttpContext.Current.Session["username"] == null)
            {
                Login.Text = "Login";
                session.Visible = false;
                

            }
            else
            {
                Login.Text = "Logout";
                session.Visible = true;
                
                session.Text = Session["username"].ToString();
                

            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (Login.Text == "Logout")
            {
                Session["username"] = null;
                Session["username"] = "";
                Session.Clear();
                Session.Abandon();
                Login.Text = "Login";
                Response.Redirect("login.aspx");

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}