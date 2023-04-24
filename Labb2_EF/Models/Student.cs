using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

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
        public string? StudentFirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string? StudentLastName { get; set; }

        [DisplayName("Student")]
        public string StudentFullName => StudentFirstName + " " + StudentLastName;

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

        [DisplayName("Phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(35)]
        public string? Email { get; set; }

        [DisplayName("Enrollment date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }


        public int FK_AddressId { get; set; }
        public virtual Address? Addresses { get; set; }
        public virtual ICollection<Teacher>? Teachers { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}