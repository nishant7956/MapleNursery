using JustTest1.Controller;
using JustTest1.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maplenursery
{
    public partial class login : System.Web.UI.Page
    {
        public static string name;
        public const int AdminCode = 1;
        public const int UserCode = 2;


        public static async Task<User> ValidateLogin(string userName, string password)
        {
            var user = await ParseUser.LogInAsync(userName.Trim(), password.Trim());
            User currentUser = new User() { Id = user.ObjectId,user_type = user.Get<int>(MemberInfoGetting.GetMemberName(() => new User().user_type)), username = user.Username };
            return currentUser;
        } 
        //private IMobileServiceTable<User> userTable = Global.MobileService.GetTable<User>();
        //User m = new User();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        protected async void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            try
            {
                var user = await ValidateLogin(Login1.UserName, Login1.Password);
                if (user.user_type == AdminCode)
                {
                    //Session.Add("adminusername", Login1.UserName);
                    Session["adminusername"] = (string)Login1.UserName;
                    //SetLoginHint("Success admin ");
                    e.Authenticated = true;
                    Response.Redirect("admin/adminhome.aspx");
                    if (Convert.ToString(Session["pid"]).Equals("_addjob"))
                    {
                        Response.Redirect("admin/addjob.aspx", false);
                    }
                }
                if (user.user_type == UserCode)
                {


                    e.Authenticated = true;
                    name = Login1.UserName.Trim();
                    //SetLoginHint("Success user ");
                    HttpContext.Current.Session["username"] = name;
                    Response.Redirect("userhome.aspx", false);
                    Label1.Text = Convert.ToString(HttpContext.Current.Session["username"]);
                }
                else
                {
                    e.Authenticated = false;
                }

            }
            catch (Exception)
            {
                Label1.Text = "Invalid username / password";

            }
        }

        
    }
}