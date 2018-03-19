using FanSoft.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FanSoft.Auth.Domain.Contracts.Repositories
{
    public interface IRepository<T> :
       IDisposable where T : Entity
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Del(T entity);
        void Del(IEnumerable<T> entities);

        IEnumerable<T> Get();
        Task<IEnumerable<T>> GetAsync();
        T Get(object key);
        Task<T> GetAsync(object key);
    }
}
