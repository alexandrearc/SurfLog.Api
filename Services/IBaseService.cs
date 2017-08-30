using System.Collections.Generic;

namespace SurfLog.Api.Services
{
    public interface IBaseService<TId, T>
    {
        IEnumerable<T> Get();
        T Get(TId id);
        T Insert(T t);
        T Update(T t);
        void Delete(TId id);
    }
}