using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models
{
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName(("First name"))]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName(("Last name"))]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName => FirstName + " " + LastName;

        [DisplayName("Hire date")]
        public DateTime DateOfHire { get; set; }

        [ForeignKey("Students")]
        public virtual ICollection<Student>? Students { get; set; }

        [ForeignKey("Courses")]
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
