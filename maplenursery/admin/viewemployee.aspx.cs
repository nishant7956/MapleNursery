using JustTest1.Controller;
using JustTest1.DataModel;
using maplenursery.DataModel;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maplenursery.admin
{
    public partial class viewemployee : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            bindempjobrelationview();
        }
              public async void bindempjobrelationview()
        {
            try
            {
                List<CurrentUserStatus> use = new List<CurrentUserStatus>();
                IEnumerable<ParseObject> currentuser = await ParseObject.GetQuery(typeof(CurrentUserStatus).Name)
                    .WhereNotEqualTo(MemberInfoGetting.GetMemberName(() => new CurrentUserStatus().status), "nothing")
                    .FindAsync();
                foreach (ParseObject obj in currentuser)
                {
                    use.Add(new CurrentUserStatus()
                    {
                        userId=obj.Get<string>(MemberInfoGetting.GetMemberName(() => new CurrentUserStatus().userId)),
                        status=obj.Get<string>(MemberInfoGetting.GetMemberName(() => new CurrentUserStatus().status))
                    });
                }
                var temp1 = use.Select(a => a.userId).ToList();
                var stat = use.Select(s => s.status).ToList();
                 IEnumerable<ParseUser> idleuser = await ParseUser.Query
                               .WhereContainedIn("objectId",  temp1)
                               .FindAsync();
                List<User> users = new List<User>();
                foreach(ParseUser u in idleuser)
                {
                    users.Add(new User
                    {
                        Id=u.ObjectId,
                        username = u.Username,
                        lastLocation=u.Get<ParseGeoPoint>(MemberInfoGetting.GetMemberName(() => new User().lastLocation))
                        
                    });
                }
                //var n = users.Select(a => a.Id).ToList();
                List<Job> job = new List<Job>();
                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Job).Name)
                    .WhereNotEqualTo("objectId", null)
                    .FindAsync();
                foreach (ParseObject all in query)
                {

                    job.Add(new Job()
                    {
                        Id = all.ObjectId,
                        name = all.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().name)),
                        EmployeeId = all.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().EmployeeId)),
                        Status=all.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().Status))
                    });
                }
                var temp = job.Select(a => a.name).ToList();
              
               //string dogCsv = string.Join(",", temp.ToArray());
               //var an = new[] { string.Join(",", n.ToArray()) };
               //lblerror.Text = n.ToString();
    //          var categorizedProducts =
    //from p in product
    //join pc in productcategory on p.Id equals pc.ProdId
    //join c in category on pc.CatId equals c.Id
    //select new {
    //    ProdId = p.Id, // or pc.ProdId
    //    CatId = c.CatId
    //    // other assignments
    //};
               
                List<EmpJobNames> names = new List<EmpJobNames>();

                var widgets1_in_widgets2 = from first in job
                                           join second in users
                                           
                                           on first.EmployeeId equals second.Id
                                           join third in use on second.Id equals third.userId
                                           select new EmpJobNames
                                               { name=first.name,username=second.username,jobstatus=first.Status,userstatus=third.status
            };
             
                empjobrelation.DataSource = widgets1_in_widgets2.ToList();
                empjobrelation.DataBind();

            }
            catch (Exception e)
            {
                lblerror.Text = e.Message;
            }


        
        }
              protected void empjobrelation_PageIndexChanging(object sender, GridViewPageEventArgs e)
              {
                  empjobrelation.PageIndex = e.NewPageIndex;
                  bindempjobrelationview();
              }

              protected void empjobrelation_Sorting(object sender, GridViewSortEventArgs e)
              {
                  bindempjobrelationview();
              }
    }
}