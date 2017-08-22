using System.Collections.Generic;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public interface IBeachRepository
    {
        Beach Insert(Beach beach);
        Beach GetById(int id);
        IEnumerable<Beach> Get();
    }
}