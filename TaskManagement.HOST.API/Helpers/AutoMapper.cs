using AutoMapper;
using TaskManagement.Entities.Dto;
using TaskManagement.Entities.Models;

namespace TaskManagement.Host.Api.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Tasks,TaskForCreateDto>().ReverseMap();
            
            CreateMap<Tasks,TaskForUpdateDto>().ReverseMap();
            
            CreateMap<Teachers,TeacherForCreateDto>().ReverseMap();
            
            CreateMap<Teachers,TeacherForUpdateDto>().ReverseMap();
            
            CreateMap<Students, StudentForCreateDto>().ReverseMap();

            CreateMap<Students, StudentForCreateDto>().ReverseMap();
        }
    }
}
