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

        public string Name { get; set; }

      
        public string Desc { get; set; }
        public Uri imagePath{get; set;}

        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        
    }
}