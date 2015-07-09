 
using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustTest1.DataModel
{
    public class Job
    {
        public string Id { get; set; } 
        public string name { get; set; } 
        public string description { get; set; }
        public string Status { get; set; }
        public string content { get; set; }
        public DateTime jobDate { get; set; }
        public ParseGeoPoint locCoordinate { get; set; }
        public string location { get; set; }
        public string EmployeeId { get; set; }
        public string UserRelation { get; set; }
    }
}
