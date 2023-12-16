namespace PuppyYoga.Models
{
    public class YogaClassData
    {
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<YogaClass> YogaClasses { get; set; }
        public IEnumerable<PuppySession> PuppySessions { get; set; }
    }
}
