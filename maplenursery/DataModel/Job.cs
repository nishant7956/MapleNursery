using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JustTest1.DataModel 
{
    class Job 
    {
        
        public string Id { get; set; }

        [JsonProperty(PropertyName = "jobname")]
        public string JobName { get; set; }

        [JsonProperty(PropertyName = "jobdescription")]
        public string JobDesc { get; set; }
    }
}
