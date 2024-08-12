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
        private readonly Entities.Course _course;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
            _student = new Entities.Student();
            _course = new Entities.Course();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentDto>))]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] int studentId = -1, [FromQuery] string grade = "", 
            [FromQuery] string firstName = "", [FromQuery] string lastName = "", [FromQuery] string wechatId = "", 
            [FromQuery] string courseName = "")
        {
            StudentFilterCriteriaDto filterCriteria = new StudentFilterCriteriaDto();

            String parsedId = "";
            if (studentId != -1)
            {
                parsedId = studentId.ToString();
            }
            filterCriteria.studentCriterias.Add(nameof(_student.StudentId), parsedId);
            filterCriteria.studentCriterias.Add(nameof(_student.Grade), grade.ToString());
            filterCriteria.studentCriterias.Add(nameof(_student.FirstName), firstName.ToString());
            filterCriteria.studentCriterias.Add(nameof(_student.LastName), lastName.ToString());
            filterCriteria.studentCriterias.Add(nameof(_student.WechatId), wechatId.ToString());
            filterCriteria.courseCriterias.Add(nameof(_course.Name), courseName.ToString());

            var students = await _studentService.GetStudentsAsync(filterCriteria);

            return Ok(students);
        }
    }
}
