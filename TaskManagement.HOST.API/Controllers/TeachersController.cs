using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;
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

        private readonly IMemoryCache _memoryCache;

        private readonly IDistributedCache _distributedCache;

        public TeachersController(IRepositoryWrapper teacher, IMapper mapper ,IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _teacher = teacher;

            _mapper = mapper;

            _memoryCache = memoryCache;

            _distributedCache = distributedCache;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cacheKey = "teacherLists";
            string serializedTeacherList;
            var teacherLists = new List<Teachers>();
            var redisTeacherList = await _distributedCache.GetAsync(cacheKey);

            if (redisTeacherList != null)
            {
                serializedTeacherList = Encoding.UTF8.GetString(redisTeacherList);
                teacherLists = JsonConvert.DeserializeObject<List<Teachers>>(serializedTeacherList);
            }
            else
            {
                teacherLists = _teacher.Teacher.GetAll().ToList();
                serializedTeacherList = JsonConvert.SerializeObject(teacherLists);
                redisTeacherList = Encoding.UTF8.GetBytes(serializedTeacherList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisTeacherList, options);
            }
            return Ok(teacherLists);
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

            return Ok("Teacher Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _teacher
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
