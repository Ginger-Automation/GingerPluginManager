using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GingerPluginWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GingerPluginWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PluginController : ControllerBase
    {
        GingerPluginDBContext db = new GingerPluginDBContext();

        // GET: api/Plugin
     

        // GET: api/Plugin/5
        [HttpGet("{id}", Name = "Get")]
        public PluginInfo Get(string id)
        {
            Plugins Plugin = db.Plugins.Where(x => x.Url.ToUpper() == id.ToUpper()).First();
            IEnumerable<VersionInfo> Versions = db.VersionInfo.Where(x => x.PluginId == Plugin.PluginId) as IEnumerable<VersionInfo>;
            Publisher publisher = db.Publisher.Where(x => x.PublisherId == Plugin.PublisherId).FirstOrDefault();

            return new PluginInfo(Plugin, Versions, publisher);
        }

        
    }
}
