using System.ComponentModel.DataAnnotations;

namespace PuppyYoga.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Display(Name ="Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
