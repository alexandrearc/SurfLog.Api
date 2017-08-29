using System.Collections.Generic;
using SurfLog.Api.Models;

namespace SurfLog.Api.Services
{
    public interface IBeachService
    {
        IEnumerable<Beach> Get();
        Beach Get(int id);
        Beach Insert(Beach beach);
        Beach Update(Beach beach);
        void Delete(int id);
    }
}