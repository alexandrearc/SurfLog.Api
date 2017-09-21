using System.Collections;
using System.Collections.Generic;
using SurfLog.Api.Models;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public class BeachService : BaseService<int, Beach, IBeachRepository>, IBeachService
    {
        private readonly IBeachRepository _beachRepository;
        public BeachService(IBeachRepository repo) : base(repo)
        {
            _beachRepository = repo;
        }

        public IEnumerable SearchByName(string name){
            return _beachRepository.SearchByName(name);
        }
    }
}