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
    public class PluginsController : ControllerBase
    {
        GingerPluginDBContext db = new GingerPluginDBContext();

        // GET: api/Plugins
        [HttpGet]
        public IEnumerable<Plugins> Get()
        {
            return db.Plugins;
        }

        [HttpGet("search/{key}", Name = "Search")]
        public List<PluginInfo> search(string key)
        {

            var plugins= PluginInfo.SearchPlugins(db, key);
            return plugins;
        }


    }
}
