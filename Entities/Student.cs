using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{

    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime UpdateTimestamp { get; set; }

        public DateTime CreateTimestamp { get; set; }

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

        [Column(TypeName = "text")]
        public string? ExtraInfo { get; set; }

        // Navigation Properties
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
