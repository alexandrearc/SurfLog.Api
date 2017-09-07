using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SurfLog.Api.Models;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public class UserService : BaseService<int, User, IUserRepository>, IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repo, SignInManager<User> signInManager) : base(repo)
        {
            _signInManager = signInManager;
            _userRepository = repo;
        }

        public async Task<User> Login(string userName, string password){

            if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password)) {
                var signInResult = await _signInManager.PasswordSignInAsync(userName, password, false, false);
                if(signInResult.Succeeded){
                    return _userRepository.GetByUserName(userName);
                }
            }
            return null;
        }

        public User Create(){
            return new User();
        }
    }
}