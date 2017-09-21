using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SurfLog.Api.Models;
using SurfLog.Api.Services;

namespace SurfLog.Api.Controllers
{
    [Route("api/[controller]")]
    public class BeachesController : Controller {

        private readonly IBeachService _beachService;

        public BeachesController (IBeachService beachService){
            _beachService = beachService;
        }

        [HttpGet]
        public IEnumerable<Beach> Get()
        {
            return _beachService.Get();
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_beachService.Get(id));
        }

        [HttpGet("name/{name}")]
        public JsonResult Get(string name)
        {
            return Json(_beachService.SearchByName(name));
        }

        [HttpPost]
        public JsonResult Post([FromBody]Beach beach)
        {
            return Json(_beachService.Insert(beach));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Beach beach)
        {
            _beachService.Update(beach);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _beachService.Delete(id);
        }
    }

}