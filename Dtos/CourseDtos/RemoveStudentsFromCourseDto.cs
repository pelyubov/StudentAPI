using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Dtos.CourseDtos
{
    public class RemoveStudentsFromCourseDto
    {
        [Required, Range(0, Double.MaxValue, ErrorMessage = "Course's id must be greater than 0.")]
        public uint courseId { get; set; }
        [Required, MinLength(1, ErrorMessage = "Số lượng sinh viên phải lớn hơn hoặc bằng 1.")]
        public List<uint> studentsId { get; set; }
    }
}
