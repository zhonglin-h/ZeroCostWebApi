using testWebAPI.Entities;

namespace testWebAPI.Dtos.Course
{
    public class CourseDto
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string RepetitionPattern { get; set; }

        public float DefaultCostPerLessonPerStudent { get; set; }

        public float TeacherPayPerClass { get; set; }
    }
}
