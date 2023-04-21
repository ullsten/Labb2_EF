using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models
{
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Class")]
        public string ClassName { get; set; }

        [ForeignKey("Students")]
        public virtual ICollection<Student> Students { get; set; }

        [ForeignKey("Teachers")]
        public virtual ICollection<Teacher> Teachers { get; set; }

        [ForeignKey("Courses")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
