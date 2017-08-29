using System.Collections.Generic;
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

        public IEnumerable<Beach> Get(){
            return _beachRepository.Get();
        }

        public Beach Get(int id)
        {
            return _beachRepository.GetById(id);
        }

        public Beach Insert(Beach beach) {
            return _beachRepository.Insert(beach);
        }

        public Beach Update(Beach beach){
            return _beachRepository.Update(beach);
        }

        public void Delete(int id){
            _beachRepository.Delete(id);
        }

    }

}