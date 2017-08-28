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

         public Beach Update(Beach beach){;
            _context.Update(beach);
            _context.SaveChanges();
            return beach;
        }

        public void Delete(int id){
            Delete(GetById(id));
        }

        public void Delete(Beach beach){
            _context.Beaches.Remove(beach);
            _context.SaveChanges(); //Check if we need to save changes.
        }
    }
}

