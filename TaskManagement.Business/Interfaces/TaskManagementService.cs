using FizzWare.NBuilder;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Services;
using static TaskManagement.Entities.Enums.Enums;

namespace TaskManagement.Business.Interfaces
{
    public class TaskManagementService : ITaskManagementService
    {

        private readonly IRepositoryWrapper _repo;

        public TaskManagementService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public async Task AddRandomDataTask(int table)
        {
            var daysGenerator = new RandomGenerator();
            if (table == (int)TableName.Teachers)
            {
                var teachers = Builder<Teachers>.CreateListOfSize(500)
                        .All()
                            .With(c => c.Id = new Guid())
                            .With(c => c.MainSubjectTeaching = Faker.Lorem.Paragraph())
                            .With(c => c.Name = Faker.Name.FullName())
                            .With(c => c.BirthDate = DateTime.Now.AddDays(-daysGenerator.Next(1, 100)))
                        .Build();

                await _repo.Teacher.AddMany(teachers);
            }
            else if (table == (int)TableName.Students)
            {
                var students = Builder<Students>.CreateListOfSize(500)
                        .All()
                            .With(c => c.Id = new Guid())
                            .With(c => c.Name = Faker.Name.FullName())
                            .With(c => c.YearOfStudy = DateTime.Now.AddYears(-daysGenerator.Next(1, 100)).Year)
                            .With(c => c.BirthDate = DateTime.Now.AddDays(-daysGenerator.Next(1, 100)))
                        .Build();

                await _repo.Student.AddMany(students);
            }
        }

        public async Task DeleteAllDataTask(int table)
        {
            if (table == (int)TableName.Students)
            {

                await _repo.Student.DeleteMany(a => a.Id != Guid.Empty);
            }
            else if (table == (int)TableName.Teachers)
            {
                await _repo.Teacher.DeleteMany(a => a.Id != Guid.Empty);
            }
        }
    }
}