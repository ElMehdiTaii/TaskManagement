using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.EF.Services;

namespace TaskManagement.Services.EF.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly EfContext _context;
        public RepositoryBase(EfContext context)
        {
            _context = context;
        }
        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(Guid id)
        {
            var res = _context.Set<T>().Find(id);
            if (res != null)
                _context.Set<T>().Remove(res);
        }

        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
        }
    }
}
