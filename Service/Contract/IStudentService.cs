using testWebAPI.Dtos.Student;

namespace testWebAPI.Service.Contract
{
    public interface IStudentService
    {
        /// <summary>
        /// Return list of all students
        /// </summary>
        /// <returns>List of StudentDTO</returns>
        Task<ServiceResponse<List<Dtos.Student.StudentDto>>> GetAllStudentsAsync();

        /// <summary>
        /// Return list of students, after filters
        /// </summary>
        /// <param name="criterias">Criteria for filtering students</param>
        /// <returns>List of StudentDTO</returns>
        Task<ServiceResponse<List<Dtos.Student.StudentDto>>> GetStudentsAsync(StudentFilterCriteriaDto criterias);
    }
}
