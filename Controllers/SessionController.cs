using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurfLog.Api.Dtos;
using SurfLog.Api.Models;
using SurfLog.Api.Services;

namespace SurfLog.Api.Controllers
{
     [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionController(IMapper mapper,ISessionService sessionService)
        {
            _mapper = mapper;
            _sessionService = sessionService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_sessionService.Get(id));
        }

         [HttpGet("user/{id}")]
        public IActionResult GetByUser(int userId)
        {
            return Ok(_sessionService.GetByUser(userId));
        }

        [HttpPost]
        public IActionResult Post([FromBody] SessionDto dto){
            var session = _mapper.Map<Session>(dto);
            return Ok(_sessionService.Insert(session));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SessionDto dto)
        {
            var session = _mapper.Map<Session>(dto);
            return Ok(_sessionService.Update(session));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _sessionService.Delete(id);
        }
    }
}