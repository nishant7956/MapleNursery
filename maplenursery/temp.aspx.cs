using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoogleMaps.LocationServices;
namespace maplenursery
{
    public partial class temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void convert_Click(object sender, EventArgs e)
        {
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(streetname.Text);
            var latitude = point.Latitude;
            var longitude = point.Longitude;
            Response.Write(latitude+""+longitude);
        }
    }
}