namespace PuppyYoga.Models
{
    public class SessionData
    {
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
        public IEnumerable<PuppySession> PuppySessions { get; set; }
    }
}
