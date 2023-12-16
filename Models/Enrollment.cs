using System.ComponentModel.DataAnnotations;

namespace PuppyYoga.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? UserID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? YogaClassID { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public User? User { get; set; }
        public YogaClass? YogaClass { get; set; }

        public ICollection<PuppySession> PuppySessions { get; set; }
    }
}
