using System.Collections;
using System.Collections.Generic;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public interface IBeachRepository : IBaseRepository<int, Beach>
    {
        IEnumerable SearchByName(string name);
    }
}