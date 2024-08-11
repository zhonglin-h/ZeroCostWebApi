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
        private readonly Entities.Student _student;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
            _student = new Entities.Student();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentDto>))]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] int studentId = -1, [FromQuery] string grade = "", 
            [FromQuery] string firstName = "", [FromQuery] string lastName = "", [FromQuery] string wechatId = "")
        {
            StudentFilterCriteriaDto filterCriteria = new StudentFilterCriteriaDto();

            String parsedId = "";
            if (studentId != -1)
            {
                parsedId = studentId.ToString();
            }
            filterCriteria.criterias.Add(nameof(_student.StudentId), parsedId);
            filterCriteria.criterias.Add(nameof(_student.Grade), grade.ToString());
            filterCriteria.criterias.Add(nameof(_student.FirstName), firstName.ToString());
            filterCriteria.criterias.Add(nameof(_student.LastName), lastName.ToString());
            filterCriteria.criterias.Add(nameof(_student.WechatId), wechatId.ToString());

            var students = await _studentService.GetStudentsAsync(filterCriteria);

            return Ok(students);
        }
    }
}
