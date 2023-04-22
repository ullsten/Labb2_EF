using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models
{
    public class Course
    {
        public Guid CourseId { get; set; }

        [StringLength(50)]
        [DisplayName("Course")]
        public string CourseName { get; set; }

        [StringLength(50)]
        public string ?CourseDescription { get; set; }

        [ForeignKey("Students")]
        public virtual ICollection<Student>? Students { get; set; }

        [ForeignKey("Teachers")]
        public virtual ICollection<Teacher>? Teachers { get; set; }
    }
}
