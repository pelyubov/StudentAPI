using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

        [MaxLength(100)]
        [Unicode]
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime Birth { get; set; }
        public bool IsDeleted { get; set; }
    }
}
