using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfLog.Api.Models;

namespace SurfLog.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public AuthController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public JsonResult Login(string userName, string password)
        {
            //var signInResult = _signInManager.PasswordSignInAsync(userName, password, true, false);
            return new JsonResult("");
        }
    }
}