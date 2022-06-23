using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.EF.Services;

namespace TaskManagement.Services.EF.Repository
{
    public class StudentsRepository : RepositoryBase<Students>, IStudentsRepository
    {
        public StudentsRepository(EfContext context) : base(context)
        {
        }
    }
}
