using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.Mongo.Interfaces;

namespace TaskManagement.Services.Mongo.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IMongoContext _context;

        public RepositoryWrapper(IMongoContext context)
        {
            _context = context;
        }
        public IStudentsRepository Student => new StudenstRepository(_context);

        public ITasksRepository Task => new TasksRepository(_context);

        public ITeachersRepository Teacher => new TeachersRepository(_context);

        public async Task<bool> SaveChanges()
        {
            if (await _context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
