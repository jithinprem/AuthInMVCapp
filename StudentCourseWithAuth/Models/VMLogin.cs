using System.ComponentModel.DataAnnotations;

namespace StudentCourseWithAuth.Models
{
    public class VMLogin
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
