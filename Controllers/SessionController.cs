using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurfLog.Api.Dtos;
using SurfLog.Api.Enums;
using SurfLog.Api.Helpers;
using SurfLog.Api.Models;
using SurfLog.Api.Requests;
using SurfLog.Api.Services;

namespace SurfLog.Api.Controllers
{
    [Authorize]
    [ApiValidationFilterAttribute]
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
            var session = _sessionService.Get(id);
            if(session == null)
                return NotFound(new ApiBadRequestResponse());
            return Ok(new ApiOkResponse(session));
        }

         [HttpGet("user/{id}")]
        public IActionResult GetByUser(string userId)
        { 
            var session = _sessionService.GetByUser(userId);
            if(session == null)
                return NotFound(new ApiBadRequestResponse());
            return Ok(new ApiOkResponse(session));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostSessionRequest request){
            var session = _mapper.Map<Session>(request);
            var newSession = _sessionService.Insert(session);
            if(newSession == null)
                return BadRequest("Failed to create session.");
            return Ok(new ApiOkResponse(newSession));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PostSessionRequest request)
        {
            var session = _mapper.Map<Session>(request);
            var updatedSession = _sessionService.Update(session);
            if (updatedSession == null)
                return BadRequest("Failed to update session.");
            return Ok(new ApiOkResponse(updatedSession));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _sessionService.Delete(id);
        }
    }
}