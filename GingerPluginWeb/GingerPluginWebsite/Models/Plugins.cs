using System;
using System.Collections.Generic;

namespace GingerPluginWebsite.Models
{
    public partial class Plugins
    {
        public string Name { get; set; }
        public int PublisherId { get; set; }
        public string Website { get; set; }
        public string RepoUrl { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public long PluginId { get; set; }
        public string Url { get; set; }
    }
}
