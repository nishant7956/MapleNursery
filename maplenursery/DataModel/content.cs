using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace maplenursery.DataModel
{
    public class content
    {
        public content()
    {
        Quantity = 1;
    }
        public string Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Uri image { get; set; }
        public double price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}