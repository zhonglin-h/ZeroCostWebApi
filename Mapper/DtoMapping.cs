using AutoMapper;
using testWebAPI.Dtos.Student;
using testWebAPI.Entities;

namespace testWebAPI.Mapper
{
    public class DtoMapping:Profile
    {
        public DtoMapping() { 
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
