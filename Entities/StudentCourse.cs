using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAPI.Entities
{
    [Table("StudentCourse")]
    public class StudentCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public uint StudentId { get; set; }
        public uint CourseId { get; set; }
    }
}
