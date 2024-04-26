using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Entities
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

        [MaxLength(50)] //Default: NVARCHAR
        [Unicode]
        public string Name { get; set; }

        [Range(0, 200)]
        public uint MaxQuantity { get; set; }
    }
}
