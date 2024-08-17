using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime UpdateTimestamp { get; set; }

        public DateTime CreateTimestamp { get; set; }

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
        public string PrimaryGmail { get; set; }

        [MaxLength(255)]
        public string? CommunicationEmail { get; set; }

        [MaxLength(255)]
        public string? PhoneNumber { get; set; }

        [MaxLength(255)]
        public string? ExtraInfo { get; set; }
    }
}
