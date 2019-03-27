using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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


        [HttpGet("download/{id}/{version}", Name = "download")]
        public ActionResult Download(string id, string version)
        {
            Plugins Plugin = db.Plugins.Where(x => x.Url.ToUpper() == id.ToUpper()).First();
            VersionInfo vi = db.VersionInfo.Where(x => x.PluginId == Plugin.PluginId && x.Version == version).FirstOrDefault();
            Publisher publisher = db.Publisher.Where(x => x.PublisherId == Plugin.PublisherId).FirstOrDefault();



            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = @"C:\GitRepos\GingerPluginManager\GingerPluginWeb\GingerPluginWebsite\";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + vi.FilePath);
            string fileName = string.Format("Ginger-{0}-{1}.zip",Plugin.Name,vi.Version);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }



    }
}
