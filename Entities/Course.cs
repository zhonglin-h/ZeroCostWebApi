using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        public DateTime UpdateDate { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public Class? Class { get; set; }

        public Teacher? Teacher { get; set; }

        public DateOnly StartDate {  get; set; }

        public DateOnly EndDate { get; set; }

        public string RepetitionPattern { get; set; }

        public float DefaultCostPerLessonPerStudent { get; set; }

        public float TeacherPayPerClass { get; set; }

        // Navigation Properties
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
