using System.Collections.Generic;
using SurfLog.Api.Models;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public class SessionService : BaseService<int, Session, ISessionRepository>, ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository repo) : base(repo)
        {
            _sessionRepository = repo;
        }

        public IEnumerable<Session> GetByUser(int userId) {
            return _sessionRepository.GetByUser(userId);
        }
    }
}