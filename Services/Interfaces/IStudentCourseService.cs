using StudentAPI.Dtos.CourseDtos;
using StudentAPI.Entities;

namespace StudentAPI.Services.Interfaces
{
    public interface IStudentCourseService
    {
        void AddStudentsById(AddStudentsCourseByIdDto input);
        void RemoveStudents(RemoveStudentsFromCourseDto input);
        List<Student> GetStudents(uint courseId);
        List<StudentCourse> GetStudentCourses();
    }
}
