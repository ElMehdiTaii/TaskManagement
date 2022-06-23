using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.EF.Services;

namespace TaskManagement.Services.EF.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly EfContext _context;
        public RepositoryWrapper(EfContext context)
        {
            _context = context;
        }
        public IStudentsRepository Student => new StudentsRepository(_context) ;

        public ITasksRepository Task => new TasksRepository(_context);

        public ITeachersRepository Teacher => new TeachersRepository(_context);

        public async Task<bool> SaveChanges()
        {
            if (await _context.SaveChangesAsync() > 0)
                return true;
            return false;
        }
    }
}
