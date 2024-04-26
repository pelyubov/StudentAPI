using StudentAPI.Dtos.CourseDtos;
using StudentAPI.Entities;

namespace StudentAPI.Services.Interfaces
{
    public interface ICourseService
    {
        Course CreateCourse(CreateCourseDto input);
        void UpdateCourse(uint id, CreateCourseDto input);
        void DeleteCourse(uint id);
        List<Course> GetAllCourses();
        Course GetCourse(uint id);
    }
}
