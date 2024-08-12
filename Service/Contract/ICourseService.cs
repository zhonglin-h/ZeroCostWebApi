using testWebAPI.Dtos.Student;

namespace testWebAPI.Service.Contract
{
    public interface ICourseService
    {

        /// <summary>
        /// Return list of courses
        /// </summary>
        /// <returns>List of CourseDto</returns>
        Task<ServiceResponse<List<Dtos.Course.CourseDto>>> GetCoursesAsync();
    }
}
