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
            User currentUser = new User() { Id = user.ObjectId, UserType = user.Get<int>("user_type"), Name = user.Username };
            return currentUser;
        } 
        //private IMobileServiceTable<User> userTable = Global.MobileService.GetTable<User>();
        //User m = new User();
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        //private async Task ValidateInput()
        //{
        //    if (uName.Text.Trim() != null || uName.Text.Trim() != string.Empty || uPassword.Password != null)
        //    {
        //        await ValidateLogin(uName.Text, uPassword.Password);
        //    }
        //    else
        //    {
        //        SetLoginHint("Please input user name and password");
        //    }
        //}




        //Validate Login and send to appropriate page
        //public async Task ValidateLogin(string userName, string password)
        //{
        //    MobileServiceInvalidOperationException exception = null;
        //    try
        //    {
        //        SetLoginHint(" ");

        //        User has = (User)userTable.Where(i => i.Name.Equals(userName));
        //        //Debug.WriteLine("Debug Information-Product Starting " + has.Password);

        //        var user_Admin = await userTable
        //            .Where(todoItem => todoItem.Name == userName && todoItem.Password == password && todoItem.UserType == 1)
        //            .ToCollectionAsync();
        //        var user_normal = await userTable
        //           .Where(todoItem => todoItem.Name == userName && todoItem.Password == password && todoItem.UserType == 2)
        //           .ToCollectionAsync();

        //        int adminCount = user_Admin.Count;
        //        int userCount = user_normal.Count;

        //        //Debug.WriteLine("Debug Information-Product Starting " + count);


        //        if (adminCount == 0 && userCount == 0)
        //        {
        //            // Invalid user name
        //            SetLoginHint("Invalid user name or password");
        //        }
        //        else if (adminCount == 0 && userCount == 1)
        //        {
        //            // Success
        //            SetLoginHint("Success user ");
        //            //this.Frame.Navigate(typeof(User_home));
        //        }
        //        else if (adminCount == 1 && userCount == 0)
        //        {
        //            // Success
        //            SetLoginHint("Success admin ");
        //            //this.Frame.Navigate(typeof(Ad_Home));
        //        }
        //        else
        //        {
        //            SetLoginHint("Check credentials ");
        //        }
        //    }
        //    catch (MobileServiceInvalidOperationException e)
        //    {
        //        exception = e;
        //    }

        //    if (exception != null)
        //    {
        //        ShowMessage(exception.Message);
        //        SetLoginHint(exception.Message + "");
        //    }
        //}

        //private void SetLoginHint(string hint)
        //{
        //    LoginHint.Text = hint;
        //}

        //private async void ShowMessage(string message)
        //{
        //    var dialog = new MessageDialog(message);
        //    await dialog.ShowAsync();
        //}

        //private async void uPassword_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        //{
        //    if (e.Key == Windows.System.VirtualKey.Enter)
        //    {
        //        await ValidateInput();
        //    }
        //}
         [System.Web.Services.WebMethod(EnableSession = true)]
        protected async void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            
            try
            {
                var user = await ValidateLogin(Login1.UserName, Login1.Password);
                if (user.UserType == AdminCode)
                {
                    //Session.Add("adminusername", Login1.UserName);
                    Session["adminusername"] = (string)Login1.UserName;
                    //SetLoginHint("Success admin ");
                    e.Authenticated = true;
                    Response.Redirect("admin/adminhome.aspx",false);
                    if (Convert.ToString(Session["pid"]).Equals("_addjob"))
                    {
                        Response.Redirect("admin/addjob.aspx",false);
                    }
                }
                if (user.UserType == UserCode)
                {
                    
                    
                    e.Authenticated = true;
                    name = Login1.UserName.Trim();
                    //SetLoginHint("Success user ");
                    HttpContext.Current.Session["username"] = name;
                    Response.Redirect("userhome.aspx",false);
                    Label1.Text = Convert.ToString( HttpContext.Current.Session["username"]);
                }
                else
                {
                    e.Authenticated = false;
                }

            }
            catch (Exception)
            {
                Label1.Text="Invalid username / password";

            }
            //MobileServiceInvalidOperationException exception = null;
            //try
            //{

            //    var user_Admin = await userTable
            //    .Where((con => con.Name == Login1.UserName  && con.Password == Login1.Password && con.UserType == 1))
            //    .ToCollectionAsync();
            //    var user_normal = await userTable
            //       .Where(con => con.Name == Login1.UserName && con.Password == Login1.Password && con.UserType == 2)
            //       .ToCollectionAsync();

            //    if (user_Admin.Count > 0 && user_normal.Count == 0)
            //    {
            //        e.Authenticated = true;
            //        Session["username"] = Login1.UserName;

            //        Response.Redirect("admin/adminhome.aspx");
            //    }
            //    if (user_Admin.Count == 0 && user_normal.Count > 0)
            //    {
            //        e.Authenticated = true;
            //        Session["username"] = Login1.UserName;

            //        Response.Redirect("userhome.aspx");

            //    }
            //    else
            //    {
            //        e.Authenticated = false;
            //    }

            //}
            //catch (MobileServiceInvalidOperationException en)
            //{
            //    exception = en;
            //}

            //if (exception != null)
            //{
            //    Response.Write("<script LANGUAGE='JavaScript' >alert(" + exception.Message + ")</script>");

            //    //SetLoginHint(exception.Message + "");
            //}
        }

        
    }
}