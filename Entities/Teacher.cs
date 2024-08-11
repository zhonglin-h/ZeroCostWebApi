using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }

        [Timestamp]
        public Byte[] UpdateDate { get; set; }

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
