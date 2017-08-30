using System.Collections.Generic;
using SurfLog.Api.Repositories;

namespace SurfLog.Api.Services
{
    public class BaseService<TId, T, TRepo> : IBaseService<TId, T> where T : class where TRepo : IBaseRepository<TId, T>
    {
        protected readonly TRepo _repository;

        public BaseService(TRepo repo)
        {
            _repository = repo;
        }

        public IEnumerable<T> Get(){
            return _repository.Get();
        }

        public T Get(TId id)
        {
            return _repository.GetById(id);
        }

        public T Insert(T t) {
            return _repository.Insert(t);
        }

        public T Update(T t){
            return _repository.Update(t);
        }

        public void Delete(TId id){
            _repository.Delete(id);
        }

    }
}