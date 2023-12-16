using System.ComponentModel.DataAnnotations;

namespace PuppyYoga.Models
{
    public class Session
    {
        public int SessionId { get; set; }

        [Required]
        [StringLength(200)]
        public string SessionName { get; set; }

        public ICollection<PuppySession>? PuppySessions { get; set; }
    }
}
