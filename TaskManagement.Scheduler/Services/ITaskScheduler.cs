using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Scheduler.Services
{
    public interface ITaskScheduler
    {
        Task TaskSchedulerCreated();
        Task TaskSchedulerCompleted();
    }
}
