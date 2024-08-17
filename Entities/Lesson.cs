using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime UpdateTimestamp { get; set; }

        public DateTime CreateTimestamp { get; set; }

        public string GCalendarId { get; set; }

        public string GEventId { get; set; }

        public DateTime StartTimestamp { get; set; }

        public float Duration { get; set; }

        public Course Course { get; set; }

        [Column(TypeName = "text")]
        public string ExtraInfo { get; set; }
    }
}
