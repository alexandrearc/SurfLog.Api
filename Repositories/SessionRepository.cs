using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public class SessionRepository : BaseRepository<int, Session>, ISessionRepository
    {
        public SessionRepository(SurfLogContext context) : base(context)
        {
        }

        public override Session GetById(int id)
        {
            return _dbSet.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Session> GetByUser(string userId){

            return _dbSet.Where(s => s.UserId == userId)
                         .Include( s => s.Condition);
        }
    }
}