using System.Collections.Generic;
using SurfLog.Api.Models;

namespace SurfLog.Api.Services
{
    public interface ISessionService : IBaseService<int, Session>
    {
         IEnumerable<Session> GetByUser(string userId);
    }
}