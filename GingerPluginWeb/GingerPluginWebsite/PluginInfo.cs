using GingerPluginWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GingerPluginWebsite
{
    public class PluginInfo
    {
        public readonly string Name;
        public readonly string Website;
        public readonly string RepoUrl;
        public readonly string Type;
        public readonly string Description;
        public readonly string Publisher;

        public readonly IEnumerable<VersionInfo> Versions;
        public long Downloads;

        public PluginInfo(Plugins Plugin, IEnumerable<VersionInfo> versions, Publisher publisher)
        {

            this.Name = Plugin.Name;
            this.Type = Plugin.Type;
            this.Website = Plugin.Website;
            this.Description = Plugin.Description;
            this.RepoUrl = Plugin.RepoUrl;
            this.Versions = versions;
            this.Publisher = publisher.Name;


        }


        public static List<PluginInfo> SearchPlugins(GingerPluginDBContext db,string searchKey)
        {
            List<PluginInfo> Plugins = new List<PluginInfo>();

            foreach (Plugins plugin in db.Plugins.Where(x => x.Name.ToUpper().Contains(searchKey.ToUpper())))
            {

           
                Publisher publisher = db.Publisher.Where(x => x.PublisherId == plugin.PublisherId).FirstOrDefault();

                PluginInfo pi = new PluginInfo(plugin, db.VersionInfo, publisher);
                pi.Downloads = pi.Versions.Sum(x => x.Downloads).Value;

                Plugins.Add(pi);
            }

            return Plugins;
        }
    }
}
