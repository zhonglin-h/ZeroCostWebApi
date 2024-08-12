using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{

    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        public DateTime UpdateDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Grade { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string? MiddleName { get; set; }

        [MaxLength(255)]
        public string? WechatId { get; set; }

        [MaxLength(255)]
        public string? StudentEmail { get; set; }

        [MaxLength(255)]
        public string? ParentEmail { get; set; }

        [MaxLength(255)]
        public string? ParentPhoneNumber { get; set; }

        [MaxLength(255)]
        public string? ExtraInfo { get; set; }

        // Navigation Properties
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
