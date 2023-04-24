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
        public string? CourseName { get; set; }

        [StringLength(50)]
        [DisplayName("Description")]
        public string ?CourseDescription { get; set; }

        public string? Grade { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<Teacher>? Teachers { get; set; }
        public virtual ICollection<Class>? Classs { get; set; }
    }
}
