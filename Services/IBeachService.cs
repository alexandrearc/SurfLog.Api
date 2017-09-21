using System.Collections;
using System.Collections.Generic;
using SurfLog.Api.Models;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public interface IBeachService : IBaseService<int, Beach>
    {
        IEnumerable SearchByName(string name);
    }
}