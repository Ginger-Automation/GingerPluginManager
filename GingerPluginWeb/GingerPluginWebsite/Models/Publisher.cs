using System;
using System.Collections.Generic;

namespace GingerPluginWebsite.Models
{
    public partial class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }
    }
}
