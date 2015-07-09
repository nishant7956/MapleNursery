using JustTest1.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System.Drawing;
using System.Windows.Input;

using System.Windows.Media.Imaging;
using Parse;
using JustTest1.Controller;
using Newtonsoft.Json;
using maplenursery.Properties;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using maplenursery.DataModel;
using System.Collections;
namespace maplenursery.admin
{
    public partial class adminhome : System.Web.UI.Page
    {

        // ParseUser user = new ParseUser();
        
        List<User> idleuserlist = new List<User>();
        List<User> finishuserlist = new List<User>();
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["adminusername"] != null)
            //{
            //    Label1.Visible = true;
            //}
            //else
            //{
            //    Label1.Visible = false;
            //}
            //HyperLink myHyperLink = new HyperLink();
            //myHyperLink.Text = "Hi, " + System.Environment.NewLine + "Assign Job";
            //myHyperLink.NavigateUrl = "~admin/addjob.aspx";
            ////this.Page.Controls.Add(myHyperLink);
            try
            {

                if (!IsPostBack)
                {
                    bindempjobrelationview();
                    bindgridview();
                    bindrejectedlistgrid();
                    GMap1.Add(GMapType.GTypes.Hybrid);
                    GMap1.Add(GMapType.GTypes.Normal);
                    GMap1.Add(GMapType.GTypes.Satellite);
                    GMap1.Add(new GControl(GControl.preBuilt.GOverviewMapControl));
                    GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));

                    //GMap1.addControl(new GControl(GControl.preBuilt.GOverviewMapControl));
                    //GMap1.Add(new GControl(GControlPosition.position.Bottom_Right);

                    //GMap1.Add( legendposition);

                    GMap1.setCenter(new GLatLng(43.390179, -80.3052154), 11);
                    XPinLetter xpinletter = new XPinLetter(PinShapes.pin_star, "H", Color.Blue, Color.White, Color.Chocolate);

                    //GMap1.Add(new GMarker(homelocation, new GMarkerOptions(new GIcon(xpinletter.ToString(), xpinletter.Shadow()))));
                    //status idle


                    idleuser();
                    finisheduser();


                    //working
                    working();
                    //offwork
                    offwork();
                }
            }
            catch (Exception en)
            {
                lblerror.Text = en.Message;
            }
        }

        public async void finisheduser()
        {
            var finisheduser = await ParseUser.Query
                                          .WhereEqualTo("status", UserControlls.statusCode[7])
                                          .FindAsync();
            txtfinished.Text = finisheduser.Count().ToString();
            foreach (ParseUser user in finisheduser)
            {
                ParseFile img = user.Get<ParseFile>("profilePic");
                finishuserlist.Add(new User
                {
                    Id = user.ObjectId,
                    username = user.Get<string>("username"),
                    lastLocation = user.Get<ParseGeoPoint>("lastLocation"),
                    profilePic = img.Url,
                    status = user.Get<string>("status")
                });
            }



            foreach (var locations in finishuserlist)
            {
                PinIcon p;
                GMarker gm;
                GInfoWindow win;

                p = new PinIcon(PinIcons.WCmale, Color.Yellow);
                gm = new GMarker(new GLatLng(locations.lastLocation.Latitude, locations.lastLocation.Longitude),
                    new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                win = new GInfoWindow(gm, "<p><img src='" + locations.profilePic + "' alt='person Image' width='60px' height='60px' runat='server' />  <br/>"
                    + locations.username.First().ToString().ToUpper() + locations.username.Substring(1) + " <br/>" + locations.status.First().ToString().ToUpper() + locations.status.Substring(1) + "</p>", false, GListener.Event.mouseover);
                GMap1.Add(win);
            }
        }

        public async void idleuser()
        {
            var idleuser = await ParseUser.Query
                               .WhereEqualTo("status", UserControlls.statusCode[0])
                               .FindAsync();
            txtidle.Text = idleuser.Count() + "";
            //foreach (ParseUser user in idleuser){


            //        int count= user.ObjectId.Count();
            //        txtidle.Text = count.ToString();
            //}

            //var userGeoPoint = ParseUser.CurrentUser.Get<ParseGeoPoint>("lastLocation");
            foreach (ParseUser user in idleuser)
            {
                ParseFile img = user.Get<ParseFile>("profilePic");
                idleuserlist.Add(new User
                {
                    Id = user.ObjectId,
                    username = user.Get<string>("username"),
                    lastLocation = user.Get<ParseGeoPoint>("lastLocation"),
                    profilePic = img.Url,
                    status = user.Get<string>("status")
                });
            }
            GMapOverlay markersOverlay = new GMapOverlay();
            foreach (var locations in idleuserlist)
            {

                //Image i = new Image();
                //ResizeImage(locations.profilePic, 40, 40);
                //GIcon icon = new GIcon();
                //icon.image=locations.profilePic.AbsoluteUri.ToString();

                //icon.shadow = "http://simpleicon.com/wp-content/uploads/map-marker-3.png";
                //icon.iconSize = new GSize(40, 100);
                //icon.shadowSize = new GSize(82, 200);

                //string jsonEmployeeResponse = JsonConvert.SerializeObject(locations);
                PinIcon p;
                GMarker gm;
                GInfoWindow win;

                //Bitmap im = new Bitmap(PinIcons.WCmale);
                //imggreen = PinIcons.WCmale;
                //imggreen.ForeColor = Color.Green;
                //body += @"<p><img src='" + domainName + imageFileName +"' alt='Product Image' width='250px' height='250px' runat='server' /></p>";
                p = new PinIcon(PinIcons.WCmale, Color.Green);
                gm = new GMarker(new GLatLng(locations.lastLocation.Latitude, locations.lastLocation.Longitude),
                    new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                win = new GInfoWindow(gm, "<p><img src='" + locations.profilePic + "' alt='person Image' width='60px' height='60px' runat='server' />  <br/>"
                    + locations.username.First().ToString().ToUpper() + locations.username.Substring(1) + " <br/>" + locations.status.First().ToString().ToUpper() + locations.status.Substring(1) + "</p>", false, GListener.Event.mouseover);
                GMap1.Add(win);
            }
        }
        public async void working()
        {
            var workinguser = await ParseUser.Query
                                   .WhereEqualTo("status", UserControlls.statusCode[4])
                                   .FindAsync();
            txtworking.Text = workinguser.Count().ToString();
        }
        public async void offwork()
        {
            var offworkuser = await ParseUser.Query
                                .WhereEqualTo("status", UserControlls.statusCode[8])
                                .FindAsync();

            txtoffwork.Text = offworkuser.Count().ToString();
        }
        public async void bindgridview()
        {
            try
            {
                List<Job> job = new List<Job>();
                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Job).Name)
                    .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new Job().Status), JobControlls.JobStatusCode[8])
                    .FindAsync();
                foreach (ParseObject all in query)
                {
                    job.Add(new Job()
                    {
                        Id = all.ObjectId,
                        name = all.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().name)),
                    });
                }
                listofusers.DataSource = job;
                listofusers.DataBind();

            }
            catch (Exception e)
            {
                lblerror.Text = e.Message;
            }
        }
        public async void bindempjobrelationview()
        {
            try
            {
                List<Job> job = new List<Job>();
                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Job).Name)
                    .WhereNotEqualTo(MemberInfoGetting.GetMemberName(() => new Job().EmployeeId), null)
                    .FindAsync();
                foreach (ParseObject all in query)
                {
                    job.Add(new Job()
                    {
                        Id = all.ObjectId,
                        name = all.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().name)),
                        EmployeeId = all.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().EmployeeId))
                    });
                }
                var temp = job.Select(a => a.name).ToList();
               var n = job.Select(a => a.EmployeeId).ToList();
               //string dogCsv = string.Join(",", temp.ToArray());
               //var an = new[] { string.Join(",", n.ToArray()) };
               //lblerror.Text = n.ToString();
                IEnumerable<ParseUser> idleuser = await ParseUser.Query
                               .WhereContainedIn("objectId",  n)
                               .FindAsync();
                List<User> users = new List<User>();
                foreach(ParseUser u in idleuser)
                {
                    users.Add(new User
                    {
                        Id=u.ObjectId,
                        username = u.Get<string>(MemberInfoGetting.GetMemberName(() => new User().username))
                    });
                }
                var temp1 = users.Select(a => a.Id).ToList();
                List<EmpJobNames> names = new List<EmpJobNames>();
                var widgets1_in_widgets2 = from first in job
                                           join second in users
                                           on first.EmployeeId equals second.Id
                                           select new EmpJobNames
                                               { name=first.name,username=second.username
            };
             
                empjobrelation.DataSource = widgets1_in_widgets2.ToList();
                empjobrelation.DataBind();

            }
            catch (Exception e)
            {
                lblerror.Text = e.Message;
            }


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
        protected async void listofusers_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                IEnumerable<ParseUser> users = await ParseUser.Query
                    .WhereNotEqualTo(MemberInfoGetting.GetMemberName(() => new User().username), "admin")
                    .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new User().status), UserControlls.statusCode[0]).FindAsync();
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
                    idleuserlist.Items.Insert(0, new ListItem("Please select"));
                    //initial= idleuserlist.SelectedValue;
                }
            }
            catch (Exception en)
            {
                lblerror.Text = en.Message;
            }
        }



        protected async void listofusers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row1 = listofusers.SelectedRow;
            Label id = row1.FindControl("lblId") as Label;
            //Label name = row1.FindControl("lblname") as Label;
            string selectedid = id.Text.ToString();
            //string selectedname = name.Text;
            DropDownList idleuserlist = row1.FindControl("idleuser") as DropDownList;
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
                bindgridview();

                bindempjobrelationview();
            }

            else
            {
                lblerror.Text = "please select the User";
            }
        }

        protected void listofusers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listofusers.PageIndex = e.NewPageIndex;
            bindgridview();
        }

        protected async void rejectedjobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                IEnumerable<ParseUser> users = await ParseUser.Query
                    .WhereNotEqualTo(MemberInfoGetting.GetMemberName(() => new User().username), "admin")
                    .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new User().status), UserControlls.statusCode[0]).FindAsync();
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
                    idleuserlist.Items.Insert(0, new ListItem("Please select"));
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
                bindempjobrelationview();

            }

            else
            {
                lblerror.Text = "please select the User";
            }
        }

        protected void empjobrelation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            empjobrelation.PageIndex = e.NewPageIndex;
            bindempjobrelationview();
        }






    }


}