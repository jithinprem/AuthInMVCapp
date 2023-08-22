using System.ComponentModel.DataAnnotations;

namespace StudentCourseWithAuth.Models
{
    public class AuthPeople
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
