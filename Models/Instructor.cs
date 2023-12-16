using System.ComponentModel.DataAnnotations;

namespace PuppyYoga.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(1000)]
        public string? Bio { get; set; }

        public ICollection<YogaClass>? YogaClasses { get; set; }

        [Display(Name = "Instructor")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
