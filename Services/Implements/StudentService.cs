using StudentAPI.DBcontexts;
using StudentAPI.Dtos.StudentDtos;
using StudentAPI.Entities;
using StudentAPI.Exceptions;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                Name = input.Name,
                Code = input.Code,
                Birth = input.Birth
            };
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return student;
        }

        public void DeleteStudent(uint id)
        {
            var findStudent = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (findStudent != null)
            {
                _dbContext.StudentsCourses.RemoveRange(
                    _dbContext.StudentsCourses.Where(sc => sc.StudentId == id)
                );
                _dbContext.Students.Remove(findStudent);
                _dbContext.SaveChanges();
            }
            else
                throw new StudentNotFoundException($"Student with id {id} is not found");
        }

        public void UpdateStudent(uint id, CreateStudentDto input)
        {
            var findStudent = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (findStudent != null)
            {
                findStudent.Name = input.Name;
                findStudent.Code = input.Code;
                findStudent.Birth = input.Birth;
                _dbContext.SaveChanges();
            }
            else
                throw new StudentNotFoundException($"Student with id {id} is not found");
        }

        public Student GetStudent(uint id)
        {
            var findStudent = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (findStudent != null)
            {
                return findStudent;
            }
            else
                throw new StudentNotFoundException(
                    $"Student with id {findStudent.Id} is not found"
                );
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }
    }
}
