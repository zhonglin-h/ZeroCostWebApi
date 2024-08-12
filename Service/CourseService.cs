using AutoMapper;
using Microsoft.EntityFrameworkCore;
using testWebAPI.Data;
using testWebAPI.Dtos.Course;
using testWebAPI.Service.Contract;

namespace testWebAPI.Service
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CourseService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CourseDto>>> GetCoursesAsync()
        {
            ServiceResponse<List<CourseDto>> _response = new();

            try
            {

                var coursesList = await _dataContext.Courses.OrderBy(c => c.CourseId).ToListAsync();

                var courseListDto = new List<CourseDto>();

                foreach (var item in coursesList)
                {
                    courseListDto.Add(_mapper.Map<CourseDto>(item));
                }

                _response.Success = true;
                _response.Message = "ok";
                _response.Data = courseListDto;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                Console.Error.WriteLine(Convert.ToString(ex.Message));
            }

            return _response;
        }
    }
}
