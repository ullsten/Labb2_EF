using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models.JoinModels
{
    public class StudentsTeachers
    {
        [Key]
        public Guid StudentsTeachersId { get; set; }

        [ForeignKey("Students")]
        public Guid FK_StudentId { get; set; }
        public Student? Students { get; set; }

        [ForeignKey("Teachers")]
        public Guid FK_TeacherId { get; set; }
        public Teacher? Teachers { get; set; }
    }
}
