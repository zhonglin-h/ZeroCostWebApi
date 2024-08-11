namespace testWebAPI.Dtos.Student
{
    public class StudentFilterCriteriaDto
    {
        public Dictionary<string, string> criterias { get; set; }
        public StudentFilterCriteriaDto()
        {
            criterias = new Dictionary<string, string>();
        }
    }
}
