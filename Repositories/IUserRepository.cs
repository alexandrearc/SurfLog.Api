using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public interface IUserRepository : IBaseRepository<int, User>
    {
        User GetByUserName(string userName);
    }
}