using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.Interfaces;
using TaskManagement.Entities.Dto;
using TaskManagement.Services.Contract.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Host.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IRepositoryWrapper _task;

        private readonly ITaskManagementService _taskManagementService;

        private readonly IMapper _mapper;

        public TasksController(IRepositoryWrapper task, IMapper mapper, ITaskManagementService taskManagementService)
        {
            _task = task;

            _mapper = mapper;

            _taskManagementService = taskManagementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = _task.Task.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var task = await _task.Task.GetById(id);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid? id, TaskForUpdateDto taskForUpdateDto)
        {
            if (!id.HasValue || id.Value == Guid.Empty)

                return BadRequest("Invalid Params Id");

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var task = await _task.Task.GetById((Guid)id);

            if (task == null)
            {
                return BadRequest("Task Not Exists");
            }

            _mapper.Map(taskForUpdateDto, task);

            await _task.Task.Update(task);

            return Ok("Task Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _task.Task.Delete(id);
            return Ok("Delete with success");
        }
        [HttpPost("AddRandonData")]
        public async Task<IActionResult> AddRandonData(int table)
        {
            await _taskManagementService.AddRandomDataTask(table);
            return Ok();
        }
        [HttpDelete("DeleteAllData")]
        public async Task<IActionResult> DeleteAllData(int table)
        {
            await _taskManagementService.DeleteAllDataTask(table);
            return Ok();
        }
    }
}
