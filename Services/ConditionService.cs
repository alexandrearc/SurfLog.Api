using SurfLog.Api.Models;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public class ConditionService : BaseService<int, Condition, IConditionRepository>, IConditionService
    {
        public ConditionService(IConditionRepository repo) : base(repo)
        {
        }
    }
}