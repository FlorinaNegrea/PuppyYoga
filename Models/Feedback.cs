namespace PuppyYoga.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int? UserId { get; set; }
        public int? YogaClassID {  get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public User? User { get; set; }
        public YogaClass? YogaClass { get; set; }
    }
}
