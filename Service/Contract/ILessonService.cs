namespace testWebAPI.Service.Contract
{
    public interface ILessonService
    {
        Task<ServiceResponse<List<Dtos.Student.StudentDto>>> GetAllStudentsAsync();
    }
}
