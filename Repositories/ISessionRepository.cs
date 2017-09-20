using System.Collections.Generic;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public interface ISessionRepository : IBaseRepository<int, Session>
    {
        IEnumerable<Session> GetByUser(int userId);
    }
}