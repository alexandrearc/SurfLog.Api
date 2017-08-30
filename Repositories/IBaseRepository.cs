using System.Collections.Generic;

namespace SurfLog.Api.Repositories
{
    public interface IBaseRepository<TId, T>
    {
        IEnumerable<T> Get();
        T Insert(T t);
        T Update(T t);
        void Delete(TId id);
        void Delete(T t);
    }
}