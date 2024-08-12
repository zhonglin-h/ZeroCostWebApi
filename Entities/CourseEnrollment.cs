using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{
    public class CourseEnrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseEnrollmentId { get; set; }

        public DateTime UpdateDate { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }

        public float? CostPerLesson { get; set; }
    }
}
