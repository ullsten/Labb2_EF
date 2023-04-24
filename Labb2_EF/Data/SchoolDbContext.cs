using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Labb2_EF.Models;
using Labb2_EF.Models.JoinModels;
using Labb2_EF.Models.ViewModels;

namespace Labb2_EF.Data
{
    public class SchoolDbContext : IdentityDbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Class> Classes { get; set; } = default!;
        public DbSet<Enrollment> Enrollments { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } 

        public DbSet<TeacherCourse> TeacherCourses { get; set; } = default!;
        public DbSet<StudentsTeachers> StudentsTeachers { get; set; } = default!;
        public DbSet<StudentsTeachersCourse> StudentTeachersCourses { get; set; } = default!;
    }
}