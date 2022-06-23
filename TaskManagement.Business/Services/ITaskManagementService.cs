using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Dto;
using TaskManagement.Entities.Models;

namespace TaskManagement.Business.Interfaces
{
    public interface ITaskManagementService
    {
        public Task<IEnumerable<Students>> GetAllStudents();
        public Task<IEnumerable<Tasks>> GetAllTasks();
        public IEnumerable<TasksExecution> GetAllTasksExecutions();
        public Task<IEnumerable<Teachers>> GetAllTeachers();
        public Task<bool> UpdateStudent(Guid id, StudentForUpdateDto studentForUpdateDto);
        public Task<bool> UpdateTeacher(Guid id, TeacherForUpdateDto teacherForUpdateDto);
        public Task<bool> UpdateTask(Guid id, TaskForUpdateDto taskForUpdateDto);
        public Task UpdateTaskExecution(TasksExecution tasksExecution);
        public Task<bool> DeleteStudent(Guid id);
        public Task<bool> DeleteTeacher(Guid id);
        public Task<bool> DeleteTask(Guid id);
        public Task DeleteTaskExecution(Guid id);
        public Task DeleteAllDataTask(int table);
        public Task AddRandomDataTask(int table);
        public Task<bool> CreateTask(TaskForCreateDto taskForCreateDto);
        public Task<bool> CreateTeacher(TeacherForCreateDto teacherForCreateDto);
        public Task<bool> CreateStudent(StudentForCreateDto studentForCreateDto);
    }
}
