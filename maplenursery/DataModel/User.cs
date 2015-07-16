using Parse;
using System;
using System.Collections.Generic;
using System.Text; 

namespace JustTest1.DataModel
{
    public class User
    { 
        public string Id { get; set; } 
        public string username { get; set; } 
        public string password { get; set; } 
        public int user_type { get; set; }
        public string status { get; set; }
        public Uri profilePic { get; set; }
        public string location { get; set; }
        public ParseGeoPoint lastLocation { get; set; } 
    }
}
