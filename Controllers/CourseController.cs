using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testWebAPI.Dtos.Course;
using testWebAPI.Dtos.Student;
using testWebAPI.Entities;
using testWebAPI.Service.Contract;

namespace testWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CourseDto>))]
        public async Task<IActionResult> GetAll()
        {
            
            var courses = await _service.GetCoursesAsync();

            return Ok(courses);
        }
    }
}
