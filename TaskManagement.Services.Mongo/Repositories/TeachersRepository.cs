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
    public class TeachersRepository : ITeachersRepository
    {
        private readonly IMongoCollection<Teachers> _teachers;

        public TeachersRepository(IMongoDatabase database)
        {
            _teachers = database.GetCollection<Teachers>("Teachers");
        }
        public async Task Add(Teachers obj)
        {
            await _teachers.InsertOneAsync(obj);
        }
        public async Task AddMany(IEnumerable<Teachers> obj)
        {
            await _teachers.InsertManyAsync(obj);
        }
        public async Task Delete(Guid id)
        {
            var filter = Builders<Teachers>.Filter.Eq(c => c.Id, id);
            var result = await _teachers.DeleteOneAsync(filter);
        }

        public IQueryable<Teachers> GetAll()
        {
            return _teachers.AsQueryable();
        }

        public async Task<Teachers> GetById(Guid id)
        {
            var filter = Builders<Teachers>.Filter.Eq(c => c.Id, id);
            var result = await _teachers.Find(filter).FirstOrDefaultAsync();
            return result;
        }
        public async Task DeleteMany(Expression<Func<Teachers, bool>> filterExpression)
        {
            await _teachers.DeleteManyAsync(filterExpression);
        }
        public async Task<Teachers> Update(Teachers obj)
        {
            var filter = Builders<Teachers>.Filter.Where(x => x.Id == obj.Id);
            var updateDefBuilder = Builders<Teachers>.Update;
            var updateDef = updateDefBuilder.Combine(new UpdateDefinition<Teachers>[]
            {
                updateDefBuilder.Set(x => x.Name, obj.Name),
                updateDefBuilder.Set(x => x.BirthDate, obj.BirthDate),
                updateDefBuilder.Set(x => x.MainSubjectTeaching, obj.MainSubjectTeaching)
            });
            await _teachers.FindOneAndUpdateAsync(filter, updateDef);

            return await _teachers.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
    }
}

