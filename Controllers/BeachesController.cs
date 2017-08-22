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

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_beachService.Get(id));
        }
    }

}