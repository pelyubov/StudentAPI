using StudentAPI.Dtos.StudentDtos;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Dtos.CourseDtos
{
    public class AddStudentsCourseDto
    {
        [Required, Range(0, Double.MaxValue, ErrorMessage = "Course's id must be greater than 0.")]
        public uint courseId { get; set; }
        [Required, MinLength(1, ErrorMessage = "Number of student must be grseater than 1.")]
        public List<CreateStudentDto> students { get; set; }
    }
}
