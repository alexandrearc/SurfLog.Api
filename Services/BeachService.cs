using System.Collections.Generic;
using SurfLog.Api.Models;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public class BeachService : BaseService<int, Beach, IBeachRepository>, IBeachService
    {
        public BeachService(IBeachRepository repo) : base(repo)
        {
        }
    }

}