using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Services;

namespace TaskManagement.Services.EF.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly RepositoryContext _context;
        public TasksRepository(RepositoryContext context)
        {
            _context = context;
        }
        public async Task Add(Tasks obj)
        {
            _context.Tasks.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task AddMany(IEnumerable<Tasks> obj)
        {
            _context.Tasks.AddRange(obj);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMany(Expression<Func<Tasks, bool>> filterExpression)
        {
            var tasks = _context.Tasks.ToList();
            _context.Tasks.RemoveRange(tasks);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Remove(task);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Tasks> GetAll()
        {
            return _context.Tasks;
        }

        public async Task<Tasks> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Tasks> Update(Tasks obj)
        {
            _context.Tasks.Update(obj);
            await _context.SaveChangesAsync();
            return obj;

        }
    }
}
