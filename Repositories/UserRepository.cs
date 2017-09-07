using System.Linq;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public class UserRepository : BaseRepository<int, User>, IUserRepository
    {
        public UserRepository(SurfLogContext context) : base(context)
        {
        }

        public override User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetByUserName(string userName) => _dbSet.FirstOrDefault(u => u.UserName == userName);
    }
}