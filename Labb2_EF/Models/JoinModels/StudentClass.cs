using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_EF.Models.JoinModels
{
    public class StudentClass
    {
        [Key]
        public Guid StudentClassId { get; set; }

        [ForeignKey("Students")]
        public Guid FK_StudentId { get; set; }
        public Student? Students { get; set; }

        [ForeignKey("Classes")]
        public Guid ClassId { get; set; }
        public Class? Classes { get; set; }
    }
}
