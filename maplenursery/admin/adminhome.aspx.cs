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
                    users();
                    
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
            var finisheduser = await ParseObject.GetQuery("CurrentUserStatus")
                               .WhereEqualTo("status", UserControlls.statusCode[7])
                               .FindAsync();
            txtidle.Text = finisheduser.Count() + "";
            List<User> idle = new List<User>();
            foreach (ParseObject all in finisheduser)
            {
                idle.Add(new User()
                {
                    Id = all.Get<string>("userId"),
                    status = all.Get<string>("status")

                });
            }
            var temp = idle.Select(a => a.Id).ToList();
            var stat = idle.Select(s => s.status).ToList();
            IEnumerable<ParseUser> finishedusers = await ParseUser.Query
                              .WhereContainedIn("objectId", temp)
                              .FindAsync();
       
            foreach (ParseUser user in finishedusers)
            {
                ParseFile img = user.Get<ParseFile>("profilePic");
                finishuserlist.Add(new User
                {
                    Id = user.ObjectId,
                    username = user.Get<string>("username"),
                    lastLocation = user.Get<ParseGeoPoint>("lastLocation"),
                    profilePic = img.Url,
                    status = stat.ToString()
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
            var idleuser = await ParseObject.GetQuery("CurrentUserStatus")
                               .WhereEqualTo("status", UserControlls.statusCode[0])
                               .FindAsync();
            txtidle.Text = idleuser.Count() + "";
            List<User> current = new List<User>();
            foreach (ParseObject all in idleuser)
            {
                current.Add(new User()
                {
                    Id = all.Get<string>("userId"),
                    status = all.Get<string>(MemberInfoGetting.GetMemberName(() => new User().status)),
                   
                });
            }
            var temp = current.Select(a => a.Id).ToList();
            var sat = current.Select(s => s.status).ToList();
            IEnumerable<ParseUser> idleusers = await ParseUser.Query
                              .WhereContainedIn("objectId", temp)
                              .FindAsync();
            foreach (ParseUser user in idleusers)
            {
                ParseFile img = user.Get<ParseFile>("profilePic");
                idleuserlist.Add(new User
                {
                    Id = user.ObjectId,
                    //username = user.Get<string>(MemberInfoGetting.GetMemberName(() => new User().username)),
                    username = user.Username,
                    lastLocation = user.Get<ParseGeoPoint>(MemberInfoGetting.GetMemberName(() => new User().lastLocation)),
                    profilePic = img.Url, 
                    status = sat.ToString()
                });
              


            }
       
            foreach (var locations in idleuserlist)
            {

                PinIcon p;
                GMarker gm;
                GInfoWindow win;

                
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
            string count = "0";
            try
            {
                var workinguser = await ParseObject.GetQuery("CurrentUserStatus")
                                       .WhereEqualTo("status", UserControlls.statusCode[4])
                                       .FindAsync();
                count = workinguser.Count().ToString();
            }
            catch { }
            txtworking.Text = count;
        }
        public async void offwork()
        {
            var offworkuser = await ParseObject.GetQuery("CurrentUserStatus")
                                .WhereEqualTo("status", UserControlls.statusCode[8])
                                .FindAsync();

            txtoffwork.Text = offworkuser.Count().ToString();
        }
        public async void users()
        {
            List<Job> job = new List<Job>();
            try
            {
                List<string> n=new List<string>();
                n.Add(JobControlls.JobStatusCode[8]);
                n.Add(JobControlls.JobStatusCode[3]);
                var q = n.ToList();
                var query = await ParseObject.GetQuery(typeof(Job).Name)
                    .WhereContainedIn(MemberInfoGetting.GetMemberName(() => new Job().Status), q)
                    
                    .FindAsync();
                lblusers.Text = query.Count().ToString();
            }
            catch(Exception e)
            {
                lblerror.Text = e.Message;
            }
          
        }
        






    }


}