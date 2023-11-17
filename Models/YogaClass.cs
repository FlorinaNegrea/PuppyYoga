using System.ComponentModel.DataAnnotations;

namespace PuppyYoga.Models
{
    public class YogaClass
    {
        public int YogaClassID { get; set; }
        public string? ClassName { get; set; }
        public string? Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }    
        public int? MaxCapacity { get; set; }

        public int? InstructorId { get; set; }
        public Instructor? Instructor {  get; set; }
        public List<Enrollment> Enrollments { get; set; }


    }
}
