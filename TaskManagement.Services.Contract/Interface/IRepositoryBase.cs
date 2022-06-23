using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TaskManagement.Services.Contract.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj);
        void Remove(Guid id);
    }
}
