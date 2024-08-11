using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testWebAPI.Entities
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Timestamp]
        public Byte[] UpdateDate { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }
    }
}
