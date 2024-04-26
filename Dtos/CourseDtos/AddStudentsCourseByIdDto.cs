using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Dtos.CourseDtos
{
    public class AddStudentsCourseByIdDto
    {
        [Required, Range(0, int.MaxValue, ErrorMessage = "Course's id must be greater than 0.")]
        public uint courseId { get; set; }
        [Required, MinLength(1, ErrorMessage = "Number of students must be greater or equal 1.")]
        public List<uint> studentsId { get; set; }
    }
}
