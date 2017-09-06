using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfLog.Api.Models;

namespace SurfLog.Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<JsonResult> Login([FromBody] Login model)
        {
            //TODO: create model to pass credentials
            var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if(signInResult.Succeeded){
                return new JsonResult(Ok());
            }

            return new JsonResult(BadRequest("Failed to login."));
        }
    }
}