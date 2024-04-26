using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Dtos.StudentDtos
{
    public class CreateStudentDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be valid."), StringLength(50, ErrorMessage = "Name's length must be less than 50 chars.", MinimumLength = 1)]
        public required string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code must be valid.")]
        public required string Code { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
    }
}
