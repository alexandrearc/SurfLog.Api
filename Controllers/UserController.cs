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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, IOptions<JWTSettings> optionsAccessor)
        {
            _userService = userService;
            _mapper = mapper;
        }
    }
}