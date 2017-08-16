using SurfLog.Api.Models;

namespace SurfLog.Api.Services {

    public class BeachService : IBeachService { 

        public Beach Get(int id){
            return new Beach {
                Id=1,
                Name="Piha"
            };
        }

    }

}