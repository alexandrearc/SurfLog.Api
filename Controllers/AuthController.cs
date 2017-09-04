using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfLog.Api.Models;

namespace SurfLog.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly SurfLogContext _context;

        public AuthController(SurfLogContext surfLogContext, SignInManager<User> signInManager)
        {
            _context = surfLogContext;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<JsonResult> Login(string userName, string password)
        {
            //TODO: create model to pass credentials
            var signInResult = await _signInManager.PasswordSignInAsync(userName, password, false, false);
            if(signInResult.Succeeded){
                return new JsonResult(Ok());
            }

            return new JsonResult(BadRequest("Failed to login."));
        }
    }
}