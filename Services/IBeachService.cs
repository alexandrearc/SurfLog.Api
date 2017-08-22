using SurfLog.Api.Models;

namespace SurfLog.Api.Services
{
    public interface IBeachService
    {
        void Insert(Beach beach);
        Beach Get(int id);
    }
}