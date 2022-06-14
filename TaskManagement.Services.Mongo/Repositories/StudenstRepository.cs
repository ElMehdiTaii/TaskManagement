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
    public class StudenstRepository : IStudentsRepository
    {
        private readonly IMongoCollection<Students> _students;

        public StudenstRepository(IMongoDatabase database)
        {
            _students = database.GetCollection<Students>("Students");
        }
        public async Task Add(Students obj)
        {
            await _students.InsertOneAsync(obj);
        }

        public async Task AddMany(IEnumerable<Students> obj)
        {
            await _students.InsertManyAsync(obj);
        }

        public async Task Delete(Guid id)
        {
            var filter = Builders<Students>.Filter.Eq(c => c.Id, id);
            var result = await _students.DeleteOneAsync(filter);
        }

        public async Task DeleteMany(Expression<Func<Students, bool>> filterExpression)
        {
            await _students.DeleteManyAsync(filterExpression);
        }

        public IQueryable<Students> GetAll()
        {
            return _students.AsQueryable();
        }
        public async Task<Students> GetById(Guid id)
        {
            var filter = Builders<Students>.Filter.Eq(c => c.Id, id);
            var result = await _students.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<Students> Update(Students obj)
        {
            var filter = Builders<Students>.Filter.Where(x => x.Id == obj.Id);
            var updateDefBuilder = Builders<Students>.Update;
            var updateDef = updateDefBuilder.Combine(new UpdateDefinition<Students>[]
            {
                updateDefBuilder.Set(x => x.Name, obj.Name),
                updateDefBuilder.Set(x => x.BirthDate, obj.BirthDate),
                updateDefBuilder.Set(x => x.YearOfStudy, obj.YearOfStudy)
            });
            await _students.FindOneAndUpdateAsync(filter, updateDef);

            return await _students.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
    }
}
