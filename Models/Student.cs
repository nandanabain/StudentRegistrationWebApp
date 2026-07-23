using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationWebApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        // Store the logged-in user's Id only
        public string? ApplicationUserId { get; set; }
    }
}