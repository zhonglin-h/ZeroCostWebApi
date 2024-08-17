using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{
    public class CourseEnrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime UpdateTimestamp { get; set; }

        public DateTime CreateTimestamp { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }

        public float? CostPerLesson { get; set; }
    }
}
