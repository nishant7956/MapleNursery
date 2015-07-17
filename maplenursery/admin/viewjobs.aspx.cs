using JustTest1.Controller;
using JustTest1.DataModel;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;

namespace maplenursery.admin
{
    public partial class viewjobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindrejectedlistgrid();
        }
        public async void bindrejectedlistgrid()
        {
            try
            {
                List<Job> job = new List<Job>();
                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Job).Name)
                    .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new Job().Status), JobControlls.JobStatusCode[3])
                    .FindAsync();
                foreach (ParseObject all in query)
                {
                    job.Add(new Job()
                    {
                        Id = all.ObjectId,
                        name = all.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().name)),
                    });
                }
                rejectedjobs.DataSource = job;
                rejectedjobs.DataBind();

            }
            catch (Exception e)
            {
                lblerror.Text = e.Message;
            }


        }
        protected async void rejectedjobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                IEnumerable<ParseUser> users = await ParseUser.Query
                    .WhereNotEqualTo(MemberInfoGetting.GetMemberName(() => new User().username), "admin").FindAsync();

                List<User> all = new List<User>();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Find the DropDownList in the Row
                    DropDownList idleuserlist = (e.Row.FindControl("idleuser") as DropDownList);

                    foreach (ParseObject obj in users)
                    {
                        all.Add(new User()
                        {
                            Id = obj.ObjectId,
                            username = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new User().username))
                        });
                    }

                    idleuserlist.DataSource = all;
                    idleuserlist.DataTextField = MemberInfoGetting.GetMemberName(() => new User().username);
                    idleuserlist.DataValueField = MemberInfoGetting.GetMemberName(() => new User().Id);
                    idleuserlist.DataBind();
                    idleuserlist.Items.Insert(0, new ListItem("Please select", "Please select"));
                    //initial= idleuserlist.SelectedValue;
                }
            }
            catch (Exception en)
            {
                lblerror.Text = en.Message;
            }
        }
        protected void rejectedjobs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            rejectedjobs.PageIndex = e.NewPageIndex;
            bindrejectedlistgrid();
        }

        protected async void rejectedjobs_SelectedIndexChanged(object sender, EventArgs e)
        { 
             
            GridViewRow row1 = rejectedjobs.SelectedRow;
            Label id = row1.FindControl("lblId") as Label;
            //Label name = row1.FindControl("lblname") as Label;
            string selectedid = id.Text.ToString();
            //string selectedname = name.Text;
            DropDownList idleuserlist = row1.FindControl("idleuser") as DropDownList;
            //idleuserlist.Items.Add("asd") ;
            var sel = idleuserlist.SelectedValue;

            if (idleuserlist.SelectedIndex != 0)
            {


                string value = idleuserlist.SelectedValue;


                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Job).Name)
                    .WhereEqualTo("objectId", selectedid).FindAsync();// attempt to change username
                foreach (ParseObject obj in query)
                {

                    obj[MemberInfoGetting.GetMemberName(() => new Job().Status)] = JobControlls.JobStatusCode[0];
                    obj[MemberInfoGetting.GetMemberName(() => new Job().EmployeeId)] = value;
                    await obj.SaveAsync();
                    lblerror.Text = "saved successful";
                }

                //result = true;
                bindrejectedlistgrid();


            }

            else
            {
                lblerror.Text = "please select the User";
            }
        }
    }
}