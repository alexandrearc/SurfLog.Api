using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurfLog.Api.Dtos;
using SurfLog.Api.Models;
using SurfLog.Api.Services;

namespace SurfLog.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDto model)
        {
            var user = _mapper.Map<User>(model);
            var newUser = await _userService.Register(user);
            if (newUser != null)
            {
                var userDto = _mapper.Map<UserDto>(newUser);
                return Ok(userDto);
            }
            return BadRequest("Failed to create user.");
        }
    }
}