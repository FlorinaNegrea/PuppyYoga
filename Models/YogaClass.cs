using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuppyYoga.Models
{
    public class YogaClass
    {
        public int YogaClassID { get; set; }

        [Required]
        public string? ClassName { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(100)]
        public string? Location { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal? Price { get; set; }
        [Range(1, 100)]
        public int? MaxCapacity { get; set; }

        [Range(1, int.MaxValue)]
        public int? InstructorId { get; set; }

        public Instructor? Instructor { get; set; }

        [Range(1, int.MaxValue)]
        public int? EnrollmentID { get; set; }

        public Enrollment? Enrollment { get; set; }

        public ICollection<PuppySession>? PuppySessions { get; set; }
    }
}
