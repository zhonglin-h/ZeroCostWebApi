namespace testWebAPI.Repository.Contract
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Return all students.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Entities.Student>> GetAllStudentsAsync();
        
    }
}
