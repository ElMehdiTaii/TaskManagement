using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Entities.Dto;
using TaskManagement.Entities.Models;
using TaskManagement.Notifier.Interface;
using TaskManagement.Notifier.Repository;
using TaskManagement.Services.Contract.Interface;

namespace TaskManagement.Scheduler.Services
{
    public class TaskScheduler : ITaskScheduler
    {
        private IHubContext<InformHub, IHubClient> _informHub;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public TaskScheduler(IHubContext<InformHub, IHubClient> hubContext, IServiceScopeFactory serviceScopedFactory)
        {
            _informHub = hubContext;
            _serviceScopeFactory = serviceScopedFactory;
        }
        public void Run(TaskExecutionQuery query)
        {
            _informHub.Clients.All.InformMessage("Start Execution");

            Task.Factory.StartNew(async () =>
            {
                //var repo = GetRepository(1);
                //repo.DeleteAll();
                // use TaskExecutionRepository to get the task execution and to modify the end date to now
                await _informHub.Clients.All.InformMessage("End Execution");
            });
        }
        //private IRepositoryBase<T> GetRepositoryByQuery<T>(string tableName)
        //{
        //    var scope = _serviceScopeFactory.CreateScope();
        //    switch (tableName)
        //    {

        //        case "Missions":
        //            return scope.ServiceProvider.GetService<ITasksRepository>();
        //        case "Tasks":
        //            return  scope.ServiceProvider.GetService<ITeachersRepository>();
        //    }
        //    return null;
        //}
        private IRepositoryBase<T> GetRepository<T>(int tableName) where T : class
        {
            var scope = _serviceScopeFactory.CreateScope();
            switch (tableName)
            {
                case 1:
                    return (IRepositoryBase<T>)scope.ServiceProvider.GetService<IStudentsRepository>();
                case 2:
                    return (IRepositoryBase<T>)scope.ServiceProvider.GetService<ITeachersRepository>();
            }
            return null;
        }
    }
}
