using System.ComponentModel.DataAnnotations;

namespace PuppyYoga.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio {  get; set; }
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
