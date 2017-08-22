using SurfLog.Api.Models;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public class BeachService : IBeachService
    {
        private readonly IBeachRepository _beachRepository;

        public BeachService(IBeachRepository beachRepository)
        {
            _beachRepository = beachRepository;
        }

        public Beach Get(int id)
        {
            return _beachRepository.GetById(id);
        }

        public void Insert(Beach beach) {
            _beachRepository.Insert(beach);
        }

    }

}