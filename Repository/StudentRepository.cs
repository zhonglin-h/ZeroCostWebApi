using Microsoft.EntityFrameworkCore;
using testWebAPI.Data;
using testWebAPI.Repository.Contract;

namespace testWebAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _dataContext;

        public StudentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ICollection<Entities.Student>> GetAllStudentsAsync() {
            return await _dataContext.Students.ToListAsync();
        }
    }
}
