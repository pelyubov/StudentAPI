using StudentAPI.DBcontexts;
using StudentAPI.Dtos.CourseDtos;
using StudentAPI.Entities;
using StudentAPI.Exceptions;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Services.Implements
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Course CreateCourse(CreateCourseDto input)
        {
            var newCourse = new Course { Name = input.Name, MaxQuantity = input.MaxQuantity };
            _dbContext.Courses.Add(newCourse);
            _dbContext.SaveChanges();
            return newCourse;
        }

        public void DeleteCourse(uint id)
        {
            var findCourse = _dbContext.Courses.Find(id);
            if (findCourse != null)
            {
                _dbContext.StudentsCourses.RemoveRange(
                    _dbContext.StudentsCourses.Where(sc => sc.CourseId == id).ToList()
                );
                _dbContext.Courses.Remove(findCourse);
            }
            else
                throw new CourseNotFoundException($"Course with id {id} not found.");
        }

        public List<Course> GetAllCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public Course GetCourse(uint id)
        {
            var findCourse = _dbContext.Courses.Find(id);
            if (findCourse != null)
            {
                return findCourse;
            }
            else
                throw new CourseNotFoundException($"Course with id {id} not found.");
        }

        public void UpdateCourse(uint id, CreateCourseDto input)
        {
            var findCourse = _dbContext.Courses.Find(id);
            if (findCourse != null)
            {
                findCourse.Name = input.Name;
                findCourse.MaxQuantity = input.MaxQuantity;
            }
            else
                throw new CourseNotFoundException($"Course with id {id} not found.");
        }
    }
}
