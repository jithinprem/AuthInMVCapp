using System.ComponentModel.DataAnnotations;

namespace StudentCourseWithAuth.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        

    }
}
