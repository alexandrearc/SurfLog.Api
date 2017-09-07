using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfLog.Api.Dtos;
using SurfLog.Api.Services;

namespace SurfLog.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var user = _userService.Login(model.UserName, model.Password);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
            return BadRequest("Failed to login.");
        }
    }
}