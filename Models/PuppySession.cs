namespace PuppyYoga.Models
{
    public class PuppySession
    {
        public int PuppySessionId { get; set; }
        public int? EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int? YogaClassID { get; set; }
        public YogaClass YogaClass { get; set; }

    }
}
