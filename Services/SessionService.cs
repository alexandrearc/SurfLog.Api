using SurfLog.Api.Models;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public class SessionService : BaseService<int, Session, SessionRepository>, ISessionService
    {
        public SessionService(SessionRepository repo) : base(repo)
        {
        }
    }
}