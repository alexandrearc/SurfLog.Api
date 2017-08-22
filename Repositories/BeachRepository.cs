using System.Collections.Generic;
using System.Linq;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public class BeachRepository : IBeachRepository
    {
        private readonly SurfLogContext _context;

        public BeachRepository(SurfLogContext context)
        {
            _context = context;
        }

        public Beach GetById(int id)
        {
            return _context.Beaches.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Beach> Get(){
            return _context.Beaches.ToList();
        }

        public Beach Insert(Beach beach){
            var entity = _context.Beaches.Add(beach).Entity;
            _context.SaveChanges();
            return entity;
        }
    }
}

