using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SurfLog.Api.Dtos;
using SurfLog.Api.Models;
using SurfLog.Api.Services;


namespace SurfLog.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private IMapper _mapper;

        private readonly JWTSettings _options;

        public AuthController(IUserService userService, IMapper mapper, IOptions<JWTSettings> optionsAccessor)
        {
            _mapper = mapper;
            _userService = userService;
             _options = optionsAccessor.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userService.Login(model.UserName, model.Password);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                userDto.access_token = GetAccessToken(userDto.Email);
                userDto.id_token = GetIdToken(userDto);
                return Ok(userDto);
            }
            return new JsonResult("Unable to Log in.") { StatusCode = 401 };
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDto model)
        {
            var user = _mapper.Map<User>(model);
            var newUser = await _userService.Register(user, model.Password);
            if (newUser != null)
            {
                var userDto = _mapper.Map<UserDto>(newUser);
                userDto.access_token = GetAccessToken(userDto.Email);
                userDto.id_token = GetIdToken(userDto);
                return Ok(userDto);
            }
            return BadRequest("Failed to create user.");
        }

        private string GetAccessToken(string Email) {
            var payload = new Dictionary<string, object>
            {
                { "sub", Email },
                { "email", Email }
            };
            return GetToken(payload);
        }

         private string GetIdToken(UserDto user) {
            var payload = new Dictionary<string, object>
            {
                { "id", user.Id },
                { "sub", user.Email },
                { "email", user.Email },
                { "emailConfirmed", user.EmailConfirmed },
            };
            return GetToken(payload);
        }


         private string GetToken(Dictionary<string, object> payload) {
            var secret = _options.SecretKey;

            payload.Add("iss", _options.Issuer);
            payload.Add("aud", _options.Audience);
            payload.Add("nbf", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("iat", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("exp", ConvertToUnixTimestamp(DateTime.Now.AddDays(7)));
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, secret);
        }
        
        private static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        private JsonResult Errors(IdentityResult result)
        {
        var items = result.Errors
            .Select(x => x.Description)
            .ToArray();
        return new JsonResult(items) {StatusCode = 400};
        }

        private JsonResult Error(string message)
        {
        return new JsonResult(message) {StatusCode = 400};
        }

    }
}