using StudentAPI.Dtos.StudentDtos;
using StudentAPI.Entities;

namespace StudentAPI.Services.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(CreateStudentDto input);
        void UpdateStudent(uint id, CreateStudentDto input);
        void DeleteStudent(uint id);
        Student GetStudent(uint id);
        List<Student> GetAllStudents();
    }
}
