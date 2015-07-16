using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maplenursery.DataModel
{
    public class EmpJobRelation
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string JobId { get; set; }
        public DateTime StartTravelTime { get; set; }
        public DateTime EndTravelTime { get; set; }
        public DateTime StartWorkingTime { get; set; }
        public DateTime EndWorkingTime { get; set; }
        public DateTime StartBreakTime { get; set; }
        public DateTime EndBreakTime { get; set; }
        public string UserResponse { get; set; }
       

      
    }
}