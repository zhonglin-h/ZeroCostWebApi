namespace testWebAPI.Dtos.Student
{
    public class StudentFilterCriteriaDto
    {
        public Dictionary<string, string> studentCriterias { get; set; }
        public Dictionary<string, string> courseCriterias { get; set; }
        public StudentFilterCriteriaDto()
        {
            studentCriterias = new Dictionary<string, string>();
            courseCriterias = new Dictionary<string, string>();
        }
    }
}
