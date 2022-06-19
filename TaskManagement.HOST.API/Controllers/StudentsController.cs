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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var student = await _student.Student.GetById(id);
            return Ok(student);
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

            

            await _student.Student.Update(student);

            return Ok("Student Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _student.Student.Delete(id);
            return Ok("Delete with success");
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentForCreateDto studentForCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            return Ok("Student Created Successfully");
        }
    }
}
