using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Services;

namespace TaskManagement.Services.Mongo.Repositories
{
    public class TaskRepository : ITasksRepository
    {
        private readonly IMongoCollection<Tasks> _tasks;

        public TaskRepository(IMongoDatabase database)
        {
            _tasks = database.GetCollection<Tasks>("Tasks");
        }
        public async Task Add(Tasks obj)
        {
            await _tasks.InsertOneAsync(obj);
        }

        public async Task AddMany(IEnumerable<Tasks> obj)
        {
            await _tasks.InsertManyAsync(obj);
        }
        public async Task Delete(Guid id)
        {
            var filter = Builders<Tasks>.Filter.Eq(c => c.Id, id);
            var result = await _tasks.DeleteOneAsync(filter);
        }

        public async Task DeleteMany(Expression<Func<Tasks, bool>> filterExpression)
        {
            await _tasks.DeleteManyAsync(filterExpression);
        }
        public IQueryable<Tasks> GetAll()
        {
            return _tasks.AsQueryable();
        }

        public async Task<Tasks> GetById(Guid id)
        {

            var filter = Builders<Tasks>.Filter.Eq(c => c.Id, id);
            var result = await _tasks.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Tasks> Update(Tasks obj)
        {
            var filter = Builders<Tasks>.Filter.Where(x => x.Id == obj.Id);
            var updateDefBuilder = Builders<Tasks>.Update;
            var updateDef = updateDefBuilder.Combine(new UpdateDefinition<Tasks>[]
            {
                updateDefBuilder.Set(x => x.Name, obj.Name),
                updateDefBuilder.Set(x => x.ActionType, obj.ActionType),
                updateDefBuilder.Set(x => x.TableName, obj.TableName),
                updateDefBuilder.Set(x => x.TaskEndDate, obj.TaskEndDate),
                updateDefBuilder.Set(x => x.TaskStartDate, obj.TaskStartDate),
            });
            await _tasks.FindOneAndUpdateAsync(filter, updateDef);

            return await _tasks.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
    }
}
