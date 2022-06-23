using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Dto;

namespace TaskManagement.Scheduler.Services
{
    public interface ITaskScheduler
    {
        void Run(TaskExecutionQuery query);
    }
}
