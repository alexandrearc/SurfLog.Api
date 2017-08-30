using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SurfLog.Api.Repositories
{
    public abstract class BaseRepository<TId, T> : IBaseRepository<TId, T> where T : class
    {
        protected readonly SurfLogContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SurfLogContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public abstract T GetById(TId id);

        public IEnumerable<T> Get(){
            return _dbSet.ToList();
        }

        public T Insert(T t){
            var entity = _dbSet.Add(t).Entity;
            _context.SaveChanges();
            return entity;
        }

         public T Update(T t){;
            _context.Update(t);
            _context.SaveChanges();
            return t;
        }

        public void Delete(TId id){
            Delete(GetById(id));
        }

        public void Delete(T t){
            _dbSet.Remove(t);
            _context.SaveChanges(); //Check if we need to save changes.
        }
    }
}