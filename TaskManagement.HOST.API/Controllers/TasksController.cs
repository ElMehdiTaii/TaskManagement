using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;
using TaskManagement.Business.Interfaces;
using TaskManagement.Entities.Dto;
using TaskManagement.Entities.Models;
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

        private readonly IMemoryCache _memoryCache;

        private readonly IDistributedCache _distributedCache;

        public TasksController(IRepositoryWrapper task, IMapper mapper, ITaskManagementService taskManagementService
            , IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _task = task;

            _mapper = mapper;

            _taskManagementService = taskManagementService;

            _memoryCache = memoryCache;

            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cacheKey = "taskLists";
            string serializedTaskList;
            var taskLists = new List<Tasks>();
            var redisTaskList = await _distributedCache.GetAsync(cacheKey);

            if(redisTaskList != null)
            {
                serializedTaskList = Encoding.UTF8.GetString(redisTaskList);
                taskLists = JsonConvert.DeserializeObject<List<Tasks>>(serializedTaskList);
            }
            else
            {
                taskLists = _task.Task.GetAll().ToList();
                serializedTaskList = JsonConvert.SerializeObject(taskLists);
                redisTaskList = Encoding.UTF8.GetBytes(serializedTaskList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisTaskList, options);
            }
            return Ok(taskLists);
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
