using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.Mongo.Interfaces;
using TaskManagement.Services.Mongo.Repository;

namespace TaskManagement.Services.Mongo.Repository
{
    public class TasksRepository : RepositoryBase<Tasks>, ITasksRepository
    {
        public TasksRepository(IMongoContext context) : base(context)
        {
        }
    }
}
