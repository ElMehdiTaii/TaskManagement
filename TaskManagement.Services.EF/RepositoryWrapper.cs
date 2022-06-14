using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Services.Contract.Services;
using TaskManagement.Services.EF.Repositories;

namespace TaskManagement.Services.EF
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _context;
        public RepositoryWrapper(RepositoryContext context)
        {
            _context = context;
        }
        public IStudentsRepository Student => new StudenstRepository(_context) ;

        public ITasksRepository Task => new TasksRepository(_context);

        public ITeachersRepository Teacher => new TeachersRepository(_context);
    }
}
