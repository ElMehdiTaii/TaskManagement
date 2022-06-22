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
        private readonly ITaskManagementService _service;

        public TasksController(ITaskManagementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _service.GetAllTasks();

            return Ok(tasks);
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

            if(await _service.UpdateTask(id,taskForUpdateDto))
            
                return Ok("Task Updated Successfully");
            
            return BadRequest("Something Was Wrong");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _service.DeleteTask(id))

                return Ok("Task Deleted Successfully");

            return BadRequest("Something Was Wrong");
        }
    }
}
