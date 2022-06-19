using AutoMapper;
using FizzWare.NBuilder;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using TaskManagement.Entities.Dto;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Services;
using static TaskManagement.Entities.Enums.Enums;

namespace TaskManagement.Business.Interfaces
{
    public class TaskManagementService : ITaskManagementService
    {

        private readonly IRepositoryWrapper _repo;

        private readonly IMapper _mapper;

        private readonly IDistributedCache _distributedCache;

        public TaskManagementService(IRepositoryWrapper repo, IMapper mapper,IDistributedCache distributedCache)
        {
            _repo = repo;

            _mapper = mapper;

            _distributedCache = distributedCache;
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

        public async Task<bool> DeleteTeacher(Guid id)
        {
            if ( _repo.Teacher.Delete(id) != null)
                return true;
            return false;
        }

        public async Task<bool> DeleteStudent(Guid id)
        {
            if (await _repo.Student.Delete(id) != null)
                return true;
            return false;
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            if (await _repo.Task.Delete(id) != null)
                return true;
            return false;
        }


        public async Task<IEnumerable<Students>> GetAllStudents()
        {
            var cacheKey = "stduentLists";
            string serializedTeacherList;
            var studentLists = new List<Students>();
            var redisStudentList = await _distributedCache.GetAsync(cacheKey);

            if (redisStudentList != null)
            {
                serializedTeacherList = Encoding.UTF8.GetString(redisStudentList);
                studentLists = JsonConvert.DeserializeObject<List<Students>>(serializedTeacherList);
            }
            else
            {
                studentLists = _repo.Student.GetAll().ToList();
                serializedTeacherList = JsonConvert.SerializeObject(studentLists);
                redisStudentList = Encoding.UTF8.GetBytes(serializedTeacherList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisStudentList, options);
            }
            return studentLists;
        }

        public IEnumerable<Tasks> GetAllTasks()
        {
            return _repo.Task.GetAll();
        }

        public IEnumerable<TasksExecution> GetAllTasksExecutions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teachers> GetAllTeachers()
        {
            return _repo.Teacher.GetAll();
        }

        public async Task<bool> UpdateStudent(Guid? id, StudentForUpdateDto studentForUpdateDto)
        {
            var student = await _repo.Student.GetById((Guid)id);

            if (student == null)
            {
                return false;
            }

            _mapper.Map(studentForUpdateDto, student);

            if (await _repo.Student.Update(student) != null)
                return true;
            return false;
        }

        public async Task<bool> UpdateTask(Guid? id , TaskForUpdateDto taskForUpdateDto)
        {
            var task = await _repo.Task.GetById((Guid)id);

            if (task == null)
            {
                return false;
            }

            _mapper.Map(taskForUpdateDto, task);

            if (await _repo.Task.Update(task) != null)

                return true;

            return false;
        }

        public Task UpdateTaskExecution(TasksExecution tasksExecution)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateTeacher(Guid? id, TeacherForUpdateDto teacherForUpdateDto)
        {
            var teacher = await _repo.Teacher.GetById((Guid)id);

            if (teacher == null)
            {
                return false;
            }

            _mapper.Map(teacherForUpdateDto, teacher);

            if (await _repo.Teacher.Update(teacher) != null)
                return true;
            return false;
        }

        public Task DeleteTaskExecution(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateTask(TaskForCreateDto taskForCreateDto)
        {
            var task = _mapper.Map<Tasks>(taskForCreateDto);

            _mapper.Map(taskForCreateDto, task);

            if (await _repo.Task.Add(task) != null)
                return true;
            return false;
        }

        public async Task<bool> CreateTeacher(TeacherForCreateDto teacherForCreateDto)
        {
            var teacher = _mapper.Map<Teachers>(teacherForCreateDto);

            _mapper.Map(teacherForCreateDto, teacher);

            if (await _repo.Teacher.Add(teacher) != null)
                return true;
            return false;
        }

        public async Task<bool> CreateStudent(StudentForCreateDto studentForCreateDto)
        {
            var student = _mapper.Map<Students>(studentForCreateDto);

            _mapper.Map(studentForCreateDto, student);

            if (await _repo.Student.Add(student) != null)
                return true;
            return false;
        }
    }
}