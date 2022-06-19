using System.Linq.Expressions;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Services;

namespace TaskManagement.Services.EF.Repositories
{
    public class StudenstRepository : IStudentsRepository
    {
        private readonly RepositoryContext _context;
        public StudenstRepository(RepositoryContext context)
        {
            _context = context;
        }
        public async Task<Students> Add(Students obj)
        {
            _context.Students.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task AddMany(IEnumerable<Students> obj)
        {
            _context.Students.AddRange(obj);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMany(Expression<Func<Students, bool>> filterExpression)
        {
            var students = _context.Students.ToList();
            _context.Students.RemoveRange(students);
            await _context.SaveChangesAsync();
        }
        public async Task<Students> Delete(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        

        public IQueryable<Students> GetAll()
        {
            return _context.Students;
        }

        public async Task<Students> GetById(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Students> Update(Students obj)
        {
            _context.Students.Update(obj);
            await _context.SaveChangesAsync();
            return obj;

        }
    }
}
