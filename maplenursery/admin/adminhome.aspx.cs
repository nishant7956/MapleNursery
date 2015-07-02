using JustTest1.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System.Drawing;
using Parse;
namespace maplenursery.admin
{
    public partial class adminhome : System.Web.UI.Page
    {
       // ParseUser user = new ParseUser();
        List<User> idleuserlist = new List<User>();
        List<User> finishuserlist = new List<User>();
        protected async void Page_Load(object sender, EventArgs e)
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
            if (!IsPostBack)
            {
                GMap1.Add(GMapType.GTypes.Hybrid);
                GMap1.Add(GMapType.GTypes.Normal);
                GMap1.Add(GMapType.GTypes.Satellite);
                
               
                GLatLng homelocation = new GLatLng(43.390179, -80.3052154);
                GMap1.setCenter(homelocation, 14);
                XPinLetter xpinletter = new XPinLetter(PinShapes.pin_star,"H", Color.Blue,Color.White,Color.Chocolate);
                GMap1.Add(new GMarker(homelocation,new GMarkerOptions(new GIcon(xpinletter.ToString(),xpinletter.Shadow()))));
                var idleuser = await ParseUser.Query
                            .WhereEqualTo("status", "idle")
                            .FindAsync();
                
                //var userGeoPoint = ParseUser.CurrentUser.Get<ParseGeoPoint>("lastLocation");
                foreach (ParseUser user in idleuser)
                {
                    idleuserlist.Add(new User
                    {
                        Id = user.ObjectId,
                        Name=user.Get<string>("username"),
                        lastloc = user.Get<ParseGeoPoint>("lastLocation")
                    });
                }
               
                foreach(var locations in idleuserlist)
                {
                    PinIcon p;
                    GMarker gm;
                    GInfoWindow win;

                    p = new PinIcon(PinIcons.WCmale, Color.Green);
                    gm = new GMarker(new GLatLng(locations.lastloc.Latitude, locations.lastloc.Longitude),
                        new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                    win = new GInfoWindow(gm,locations.Name,false,GListener.Event.mouseover);
                    GMap1.Add(win);
                }
                var finisheduser = await ParseUser.Query
                            .WhereEqualTo("status", "finish")
                            .FindAsync();
                foreach (ParseUser user in finisheduser)
                {
                    finishuserlist.Add(new User
                    {
                        Id = user.ObjectId,
                        lastloc = user.Get<ParseGeoPoint>("lastLocation")
                    });
                }
                foreach (var locations in finishuserlist)
                {
                    PinIcon p;
                    GMarker gm;
                    GInfoWindow win;

                    p = new PinIcon(PinIcons.WCmale, Color.Yellow);
                    gm = new GMarker(new GLatLng(locations.lastloc.Latitude, locations.lastloc.Longitude),
                        new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                    GMap1.Add(gm);
                }
                
            }
        }

    }
}