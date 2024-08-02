using AutoMapper;
using testWebAPI.Dtos.Student;
using testWebAPI.Repository.Contract;
using testWebAPI.Service.Contract;

namespace testWebAPI.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<StudentDto>>> GetAllStudentsAsync()
        {
            ServiceResponse<List<StudentDto>> _response = new();

            try
            {

                var studentsList = await _studentRepository.GetAllStudentsAsync();

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
    }
}
