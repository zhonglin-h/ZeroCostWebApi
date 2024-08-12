using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using testWebAPI.Data;
using testWebAPI.Dtos.Student;
using testWebAPI.Service.Contract;

namespace testWebAPI.Service
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public StudentService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<StudentDto>>> GetAllStudentsAsync()
        {
            ServiceResponse<List<StudentDto>> _response = new();

            try
            {

                var studentsList = await _dataContext.Students.OrderBy(s => s.StudentId).ToListAsync();

                var StudentListDto = new List<StudentDto>();

                foreach (var item in studentsList)
                {
                    StudentListDto.Add(_mapper.Map<StudentDto>(item));
                }

                //OR 
                //CompanyListDto.AddRange(from item in CompaniesList select _mapper.Map<CompanyDto>(item));
                _response.Success = true;
                _response.Message = "ok";
                _response.Data = StudentListDto;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

        public async Task<ServiceResponse<List<StudentDto>>> GetStudentsAsync(StudentFilterCriteriaDto criteriasDto)
        {
            ServiceResponse<List<StudentDto>> _response = new();

            try
            {
                var query = _dataContext.Students.AsQueryable();
                foreach (var (key, value) in criteriasDto.studentCriterias)
                {
                    if (!value.IsNullOrEmpty())
                        query = query.Where(s => EF.Property<object>(s, key) != null && EF.Property<string>(s, key).Equals(value));
                }

                if (!criteriasDto.courseCriterias.IsNullOrEmpty())
                {
                    query = query.Include(s => s.CourseEnrollments).ThenInclude(ce => ce.Course);
                }

                foreach (var (key, value) in criteriasDto.courseCriterias)
                {
                    if (!value.IsNullOrEmpty())
                        query = query.Where(s => s.CourseEnrollments.Any(ce => EF.Property<object>(ce.Course, key) != null && EF.Property<string>(ce.Course, key).Equals(value)));
                }

                var studentsList = await query.ToListAsync();

                var StudentListDto = new List<StudentDto>();

                foreach (var item in studentsList)
                {
                    StudentListDto.Add(_mapper.Map<StudentDto>(item));
                }

                //OR 
                //CompanyListDto.AddRange(from item in CompaniesList select _mapper.Map<CompanyDto>(item));
                _response.Success = true;
                _response.Message = "ok";
                _response.Data = StudentListDto;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                Console.Error.WriteLine(Convert.ToString(ex.Message));
            }

            return _response;
        }
    }
}
