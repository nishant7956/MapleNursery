using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JustTest1.DataModel
{
    public class User
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "usertype")]
        public int UserType { get; set; }
        [JsonProperty(PropertyName = "availability")]
        public bool Availability { get; set; }
    }
}
