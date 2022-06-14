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
    public class TeachersRepository : ITeachersRepository
    {
        private readonly RepositoryContext _context;
        public TeachersRepository(RepositoryContext context)
        {
            _context = context;
        }
        public async Task Add(Teachers obj)
        {
            _context.Teachers.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task AddMany(IEnumerable<Teachers> obj)
        {
            _context.Teachers.AddRange(obj);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMany(Expression<Func<Teachers, bool>> filterExpression)
        {
            var teachers = _context.Teachers.ToList();
            _context.Teachers.RemoveRange(teachers);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            _context.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Teachers> GetAll()
        {
            return _context.Teachers;
        }

        public async Task<Teachers> GetById(Guid id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<Teachers> Update(Teachers obj)
        {
            _context.Teachers.Update(obj);
            await _context.SaveChangesAsync();
            return obj;

        }
    }
}
