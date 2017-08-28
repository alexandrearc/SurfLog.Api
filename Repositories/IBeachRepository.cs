using System.Collections.Generic;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public interface IBeachRepository
    {
        Beach GetById(int id);
        IEnumerable<Beach> Get();
        Beach Insert(Beach beach);
        Beach Update(Beach beach);
        void Delete(int id);
        void Delete(Beach beach);
    }
}