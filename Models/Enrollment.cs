using System.ComponentModel.DataAnnotations;

namespace PuppyYoga.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int? UserID { get; set; }
        public int? YogaClassID { get; set; }
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        public User? User { get; set; }
        public YogaClass? YogaClass { get; set; }    
    }
}
