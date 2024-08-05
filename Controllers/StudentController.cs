using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using testWebAPI.Dtos.Student;
using testWebAPI.Service.Contract;

namespace testWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentDto>))]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();

            return Ok(students);
        }
    }
}
