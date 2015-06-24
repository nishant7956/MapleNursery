using JustTest1.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parse;
namespace maplenursery.admin
{
    public partial class addjob : System.Web.UI.Page
    {
        //var user = ParseUser.LogInAsync(userName.Trim(), password.Trim());
        //private MobileServiceCollection<User, User> items;
        //private IMobileServiceTable<User> userTable = Global.MobileService.GetTable<User>();

        //private IMobileServiceTable<Job> jobTable = Global.MobileService.GetTable<Job>(); 
        protected async void Page_Load(object sender, EventArgs e)
        {
            Session["pid"] = "_addjob";
            if (Session["adminusername"] == null)
            {
                
                Response.Redirect("~/login.aspx",false);
            }
            //items = await userTable
            //    .Where(con => con.Availability != false)
            //    .ToCollectionAsync();

            //DropDownList1.DataSource = items;
            //DropDownList1.DataTextField = "Name";
            //DropDownList1.DataValueField = "Name";
            //DropDownList1.DataBind();
            if(!IsPostBack)
            {
                await RefreshTodoItems();
            }
            

        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        private async Task RefreshTodoItems()
        {
           
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                var query = ParseObject.GetQuery("Job")
    .WhereEqualTo("Availability", "false");
                IEnumerable<ParseObject> results = await query.FindAsync();

                //items = await userTable
                //    .Where(todoItem => todoItem.Availability != false)
                //    .ToCollectionAsync();
                
          
                LiEmployee.DataSource = results;
                LiEmployee.DataTextField = "Name";
                LiEmployee.DataValueField = "Id";
                LiEmployee.DataBind();

                LiEmployee.EnableViewState = true;
            
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            var selectedValue = LiEmployee.SelectedItem;
            //User userObject = items[selectedValue];
            //Response.Write((selectedValue.Value));
            ParseObject job = new ParseObject("job");
            job["JobName"] = JobTitle.Text;
            job["JobDesc"] = JobDescription.Text;
            job["AssignedUser"] = selectedValue.Value;
            await job.SaveAsync();
            //var newJob = new Job { JobName = JobTitle.Text, JobDesc = JobDescription.Text, AssignedUser = selectedValue.Value };
            ////Debug.WriteLine("" + selectedValue.Id);
            // await InsertnewJob(newJob);
        }

        //private async void SaveaJob(object sender, EventArgs e)
        //{
            

        //}


        //private async Task InsertnewJob(Job newJob)
        //{
        //    await jobTable.InsertAsync(newJob);
        //    Lblerror.Text = "saved";
        //    //items.Add(newJob); 
        //}

       
         
    }
}