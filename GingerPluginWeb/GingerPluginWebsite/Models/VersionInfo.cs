using System;
using System.Collections.Generic;

namespace GingerPluginWebsite.Models
{
    public partial class VersionInfo
    {
        public int PluginId { get; set; }
        public string Version { get; set; }
        public DateTime PublishDate { get; set; }
        public bool SupportLinux { get; set; }
        public bool SupportWindows { get; set; }
        public string ChangeLog { get; set; }
        public string MinGingerVersion { get; set; }
        public long UniqueId { get; set; }
        public long? Downloads { get; set; }
        public string FilePath { get; set; }
        public bool PreRelease { get; set; }
        public string MaxGingerVersion { get; set; }
    }
}
