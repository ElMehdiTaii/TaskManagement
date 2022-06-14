using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Services.Contract.Services;

namespace TaskManagement.Services.Mongo.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly MongoContext _dbContext;

        public RepositoryWrapper(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IStudentsRepository Student => new StudenstRepository(_dbContext.Database);

        public ITasksRepository Task => new TaskRepository(_dbContext.Database);

        public ITeachersRepository Teacher => new TeachersRepository(_dbContext.Database);
    }
}
