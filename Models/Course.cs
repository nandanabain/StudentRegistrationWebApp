using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebApp.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public int CourseDuration { get; set; }

        // Navigation Property
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}