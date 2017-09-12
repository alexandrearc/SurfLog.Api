using System.Threading.Tasks;
using SurfLog.Api.Models;

namespace SurfLog.Api.Services
{
    public interface IUserService : IBaseService<int, User>
    {
         Task<User> Login(string userName, string password);
         Task<User> Register(User newUser);
    }
}