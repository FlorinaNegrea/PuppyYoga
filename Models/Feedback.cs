using System.ComponentModel.DataAnnotations;

namespace PuppyYoga.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? UserId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? YogaClassID { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }

        [StringLength(500)]
        public string? Comment { get; set; }

        public User? User { get; set; }
        public YogaClass? YogaClass { get; set; }
    }
}
