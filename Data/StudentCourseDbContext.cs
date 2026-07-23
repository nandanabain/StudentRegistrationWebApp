using Microsoft.EntityFrameworkCore;
using StudentRegistrationWebApp.Models;

namespace StudentRegistrationWebApp.Data
{
    public class StudentCourseDbContext : DbContext
    {
        public StudentCourseDbContext(DbContextOptions<StudentCourseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    CourseName = "Java",
                    CourseDuration = 6
                },
                new Course
                {
                    CourseId = 2,
                    CourseName = "Python",
                    CourseDuration = 8
                }
            );
        }
    }
}