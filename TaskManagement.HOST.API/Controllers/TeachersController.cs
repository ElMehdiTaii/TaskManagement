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
    public class TeachersController : ControllerBase
    {
        private readonly IRepositoryWrapper _teacher;

        private readonly IMapper _mapper;

        public TeachersController(IRepositoryWrapper teacher, IMapper mapper)
        {
            _teacher = teacher;

            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teachers = _teacher.Teacher.GetAll();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var task = await _teacher.Teacher.GetById(id);
            return Ok(task);
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

            var teacher = await _teacher.Teacher.GetById((Guid)id);

            if (teacher == null)
            {
                return BadRequest("Task Not Exists");
            }

            _mapper.Map(teacherForUpdateDto, teacher);

            await _teacher.Teacher.Update(teacher);

            return Ok("Teacher Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _teacher.Teacher.Delete(id);
            return Ok("Teacher Deletet with success");
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TeacherForCreateDto teacherForCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var teacher = _mapper.Map<Teachers>(teacherForCreateDto);

            _mapper.Map(teacherForCreateDto, teacher);

            await _teacher.Teacher.Add(teacher);

            return Ok("Teacher Created Successfully");
        }
    }
}
