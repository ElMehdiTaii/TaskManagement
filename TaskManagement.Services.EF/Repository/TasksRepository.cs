using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.EF.Services;

namespace TaskManagement.Services.EF.Repository
{
    public class TasksRepository : RepositoryBase<Tasks>, ITasksRepository
    {
        public TasksRepository(EfContext context) : base(context)
        {
        }
    }
}
