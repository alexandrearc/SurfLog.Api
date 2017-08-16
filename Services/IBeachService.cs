using SurfLog.Api.Models;

namespace SurfLog.Api.Services
{
    public interface IBeachService
    {
        Beach Get(int id);
    }
}