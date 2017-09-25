using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public class BeachRepository : BaseRepository<int, Beach>, IBeachRepository
    {
        public BeachRepository(SurfLogContext context) : base(context)
        {
        }

        public override Beach GetById(int id)
        {
            return _dbSet.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable SearchByName(string name)
        {
            return _dbSet.Where(b => b.Name.ToLower().StartsWith(name));
        }
    }
}

