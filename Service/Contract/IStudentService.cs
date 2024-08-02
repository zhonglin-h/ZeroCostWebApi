namespace testWebAPI.Service.Contract
{
    public interface IStudentService
    {
        /// <summary>
        /// Return list of all students
        /// </summary>
        /// <returns>List of StudentDTO</returns>
        Task<ServiceResponse<List<Dtos.Student.StudentDto>>> GetAllStudentsAsync();
    }
}
