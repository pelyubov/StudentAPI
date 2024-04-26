using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Dtos.CourseDtos
{
    public class CreateCourseDto
    {
        private string _name;

        [
            Required(AllowEmptyStrings = false, ErrorMessage = "Name must be valid."),
            StringLength(
                50,
                ErrorMessage = "Name's length must be less than 50 chars.",
                MinimumLength = 1
            )
        ]
        public string Name
        {
            get => _name;
            set => _name = value.Trim();
        }

        //[
        //    Required(AllowEmptyStrings = false, ErrorMessage = "Code must be valid"),
        //    MinLength(5, ErrorMessage = "Name's length must be greater than 5 chars.")
        //]
        //public required string Code { get; set; }
        [Range(0, 200, ErrorMessage = "Course's quantity must be greater than 0.")]
        public uint MaxQuantity { get; set; }
    }
}
