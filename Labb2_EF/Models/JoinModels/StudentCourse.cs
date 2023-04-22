using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models.JoinModels
{
    public class StudentCourse
    {
        [Key]
        public Guid StudentCourseId { get; set; }

        [ForeignKey("Students")]
        public Guid FK_StudentId { get; set; }
        public Student? Students { get; set; }

        [ForeignKey("Courses")]
        public Guid FK_CourseId { get; set; }
        public Course? Courses { get; set; }

        public int? Grade { get; set; }
    }
}
