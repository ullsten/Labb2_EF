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
        [StringLength(20)]
        [DisplayName("Class")]
        public string? ClassName { get; set; }

        public virtual ICollection<Student>? Students { get; set; }

        public virtual ICollection<Teacher>? Teachers { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}