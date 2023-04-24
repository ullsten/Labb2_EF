using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models.JoinModels
{
    public class TeacherCourse
    {
        [Key]
        public Guid TeacherCourseId { get; set; }

        [ForeignKey("Teachers")]
        public Guid FK_TeacherId { get; set; }
        public Teacher? Teachers { get; set; }

        [ForeignKey("Courses")]
        public Guid FK_CourseId { get; set; }
        public Course? Courses { get; set; }
    }
}
