using StudentAPI.DBcontexts;
using StudentAPI.Dtos.CourseDtos;
using StudentAPI.Entities;
using StudentAPI.Exceptions;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Services.Implements
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentCourseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StudentCourse> GetStudentCourses()
        {
            return _dbContext.StudentsCourses.ToList();
        }

        //public void AddStudents(AddStudentsCourseDto input)
        //{
        //    var findCourse = _dbContext.Courses.Find(input.courseId);
        //    if (findCourse == null)
        //    {
        //        throw new CourseNotFoundException($"Course id {input.courseId} is not found.");
        //    }
        //    int currentQuantity = GetQuantity(input.courseId);
        //    if (currentQuantity + input.students.Count > findCourse.MaxQuantity)
        //    {
        //        throw new CourseQuantityExceedException(
        //            $"Course {findCourse.Name} had enough students (current: {currentQuantity}, max: ${findCourse.MaxQuantity})."
        //        );
        //    }
        //    input.students.ForEach(student =>
        //    {
        //        var newStudent = new Student(_dbContext.studentId++, student.Name, student.Code);
        //        _dbContext.StudentCourses.Add(
        //            new StudentCourse()
        //            {
        //                Id = _dbContext.studentCourseId++,
        //                CourseId = input.courseId,
        //                StudentId = newStudent.Id,
        //            }
        //        );
        //    });
        //}

        public void AddStudentsById(AddStudentsCourseByIdDto input)
        {
            foreach (var studentId in input.studentsId)
            {
                if (!_dbContext.Students.Select(s => s.Id).Contains(studentId))
                {
                    throw new StudentNotFoundException(
                        $"Student with id {studentId} is not found."
                    );
                }
                if (!_dbContext.Courses.Select(c => c.Id).Contains(input.courseId))
                {
                    throw new CourseNotFoundException(
                        $"Coure with id {input.courseId} is not found."
                    );
                }
                if (_dbContext.StudentsCourses.Select(s => s.StudentId).Contains(studentId))
                {
                    throw new StudentAlreadyExistInCourse(
                        $"Student id {studentId} already exist in this course {input.courseId}"
                    );
                }
            }

            foreach (var studentId in input.studentsId)
            {
                _dbContext.StudentsCourses.Add(
                    new StudentCourse() { CourseId = input.courseId, StudentId = studentId }
                );
            }
            _dbContext.SaveChanges();
        }

        public int GetQuantity(uint courseId)
        {
            return _dbContext.StudentsCourses.Count(e => e.CourseId == courseId);
        }

        public List<Student> GetStudents(uint courseId)
        {
            if (!_dbContext.Courses.Select(c => c.Id).Contains(courseId))
            {
                throw new CourseNotFoundException($"Course with {courseId} is not found.");
            }
            var query =
                from student in _dbContext.Students
                join studentCourse in _dbContext.StudentsCourses
                    on student.Id equals studentCourse.StudentId
                where studentCourse.CourseId == courseId
                select student;

            return query.ToList();
        }

        public void RemoveStudents(RemoveStudentsFromCourseDto input)
        {
            foreach (var studentId in input.studentsId)
            {
                if (!input.studentsId.Contains(studentId))
                {
                    throw new StudentNotFoundException(
                        $"Student with id {studentId} is not found."
                    );
                }
                if (_dbContext.StudentsCourses.Find(studentId) == null)
                {
                    throw new StudentNotFoundException(
                        $"Student with id {studentId} is not found in course id {input.courseId}"
                    );
                }
            }
            foreach (var studentId in input.studentsId)
            {
                var findStudent = _dbContext.StudentsCourses.Find(studentId);
                _dbContext.StudentsCourses.Remove(findStudent);
            }
            _dbContext.SaveChanges();
        }
    }
}
