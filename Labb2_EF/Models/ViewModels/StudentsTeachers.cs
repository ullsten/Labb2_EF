using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models.ViewModels
{
    public class StudentsTeachers
    {
        [Key]
        public Guid StudentsTeachersId { get; set; }

        public Guid StudentId { get; set; }
        public string? StudentFullName { get; set; }
        public Guid TeacherId { get; set; }
        public string? TeacherFullname { get; set; }
    }
}
