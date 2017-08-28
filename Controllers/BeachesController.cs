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

        // GET api/values
        [HttpGet]
        public IEnumerable<Beach> Get()
        {
            return _beachService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_beachService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _beachService.Insert(new Beach());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Beach beach)
        {
            _beachService.Update(beach);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _beachService.Delete(id);
        }
    }

}