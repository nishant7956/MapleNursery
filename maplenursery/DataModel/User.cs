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
        public string address { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public ParseGeoPoint lastLocation { get; set; } 
    }
}
