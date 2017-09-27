using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public class ConditionRepository : BaseRepository<int, Condition>, IConditionRepository
    {
        public ConditionRepository(SurfLogContext context) : base(context)
        {
        }

        public override Condition GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}