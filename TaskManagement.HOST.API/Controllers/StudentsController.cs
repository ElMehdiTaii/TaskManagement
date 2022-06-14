using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Entities.Dto;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Services;

namespace TaskManagement.Host.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IRepositoryWrapper _student;

        private readonly IMapper _mapper;

        public StudentsController(IRepositoryWrapper student, IMapper mapper)
        {
            _student = student;

            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = _student.Student.GetAll();
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

            var student = await _student.Student.GetById((Guid)id);

            if (student == null)
            {
                return BadRequest("Student Not Exists");
            }

            _mapper.Map(studentForUpdateDto, student);

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

            var student = _mapper.Map<Students>(studentForCreateDto);

            _mapper.Map(studentForCreateDto, student);

            await _student.Student.Add(student);

            return Ok("Student Created Successfully");
        }
    }
}
