using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.Mongo.Interfaces;

namespace TaskManagement.Services.Mongo.Repository
{
    public class TeachersRepository : RepositoryBase<Teachers>, ITeachersRepository
    {
        public TeachersRepository(IMongoContext context) : base(context)
        {
        }
    }
}
