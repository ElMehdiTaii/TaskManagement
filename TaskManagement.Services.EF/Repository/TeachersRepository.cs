using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.EF.Services;

namespace TaskManagement.Services.EF.Repository
{
    public class TeachersRepository : RepositoryBase<Teachers>, ITeachersRepository
    {
        public TeachersRepository(EfContext context) : base(context)
        {
        }
    }
}
