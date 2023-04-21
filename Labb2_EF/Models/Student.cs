using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName => FirstName + " " + LastName;
        public int Age { get; set; }

        [DisplayName("Personal number")]
        public string SSN { get; set; }
        public string Gender { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(35)]
        public string Email { get; set; }

        [DisplayName("Enrollment date")]
        public DateTime EnrollmentDate { get; set; }
        public int FK_AddressId { get; set; }

        public virtual ICollection<Teacher>? Teachers { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
