using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maplenursery.admin
{
    public partial class mas : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminusername"] == null) 
            {
                Login.Text = "Login";
                session.Visible = false;
            }
            else
            {
                session.Visible = true;
                session.Text = Session["adminusername"].ToString();
                Login.Text = "Logout";
            }

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (Login.Text == "Logout")
            {
                Session["adminusername"] = null;
                Session["adminusername"] = "";
                Session.Clear();
                Session.Abandon();
                Login.Text = "Login";
                Response.Redirect("~/login.aspx");

            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }
    }
}