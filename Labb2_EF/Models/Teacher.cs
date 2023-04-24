using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace Labb2_EF.Models
{
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName(("First name"))]
        public string? TeacherFirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName(("Last name"))]
        public string? TeacherLastName { get; set; }

        [DisplayName("Teacher")]
        public string TeacherFullName => TeacherFirstName + " " + TeacherLastName;

        [DisplayName("Hire date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfHire { get; set; }
        [DisplayName("Personal number")]
        public string? PersonalNumber { get; set; }

        public int? Age
        {
            get
            {
                if (PersonalNumber == null)
                {
                    return null;
                }

                var dateString = PersonalNumber.Length == 12 ? PersonalNumber.Substring(2, 6) : PersonalNumber.Substring(0, 6);
                if (!DateTime.TryParseExact(dateString, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthDate))
                {
                    return null;
                }

                var today = DateTime.Today;
                var age = today.Year - birthDate.Year;
                if (birthDate.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        public string? Gender
        {
            get
            {
                if (PersonalNumber == null)
                {
                    return null;
                }
                var genderDigit = PersonalNumber.Length == 12 ? int.Parse(PersonalNumber.Substring(10, 1)) : int.Parse(PersonalNumber.Substring(8, 1));
                return (genderDigit % 2 == 0) ? "Female" : "Male";
            }
        }

        public int FK_AddressId { get; set; }
        public virtual Address? Addresses { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
        public virtual ICollection<Class>? Classes { get; set; }
    }
}
