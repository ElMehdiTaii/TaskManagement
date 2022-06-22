using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.Interfaces;
using TaskManagement.Entities.Dto;
using TaskManagement.Entities.Models;

namespace TaskManagement.Host.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ITaskManagementService _service;

        public StudentsController(ITaskManagementService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _service.GetAllStudents();
            
            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid? id, StudentForUpdateDto studentForUpdateDto)
        {
            if (!id.HasValue || id.Value == Guid.Empty)

                return BadRequest("Invalid Params Id");

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            if(await _service.UpdateStudent(id,studentForUpdateDto))
                
                return Ok("Student Updated Successfully");
            
            return BadRequest("Something Was Wrong");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _service.DeleteStudent(id))
            
                return Ok("Student Deleted Successfully");
            
            return BadRequest("Something Was Wrong");
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentForCreateDto studentForCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            if (await _service.CreateStudent(studentForCreateDto))
            
                return Ok("Student Created Successfully");
            
            return BadRequest("Something Was Wrong");
        }
    }
}
