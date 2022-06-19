using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Services.Contract.Services
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Add(T obj);

        Task<T> Update(T obj);

        Task<T> Delete(Guid id);
        Task AddMany(IEnumerable<T> obj);

        Task DeleteMany(Expression<Func<T, bool>> filterExpression);

    }
}
