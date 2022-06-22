using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;
using TaskManagement.Business.Interfaces;
using TaskManagement.Entities.Dto;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Services;

namespace TaskManagement.Host.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITaskManagementService _service;

        public TeachersController(ITaskManagementService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teachers = await _service.GetAllTeachers();

            return Ok(teachers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid? id, TeacherForUpdateDto teacherForUpdateDto)
        {
            if (!id.HasValue || id.Value == Guid.Empty)

                return BadRequest("Invalid Params Id");

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            return Ok("Teacher Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _service.DeleteTeacher(id))

                return Ok("Teacher Deleted Successfully");

            return BadRequest("Invalid model object");
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TeacherForCreateDto teacherForCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            if(await _service.CreateTeacher(teacherForCreateDto))
            
                return Ok("Teacher Created Successfully");
            
            return BadRequest("Invalid model object");

        }
    }
}
