using JustTest1.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace maplenursery.DataModel
{
    public class Plant
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Uri image { get; set; }
        public double price { get; set; }
        public string Availability { get; set; }
        
        
    }
}