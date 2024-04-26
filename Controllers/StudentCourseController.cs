using Microsoft.AspNetCore.Mvc;
using StudentAPI.Dtos.CourseDtos;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService studentCourseService;

        public StudentCourseController(IStudentCourseService _studentCourseService)
        {
            studentCourseService = _studentCourseService;
        }

        //[HttpPost("add-students")]
        //public IActionResult addStudents(AddStudentsCourseDto input)
        //{
        //    try
        //    {
        //        studentCourseService.AddStudents(input);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
        [HttpPost("add-students-by-id")]
        public IActionResult addStudentsById(AddStudentsCourseByIdDto input)
        {
            try
            {
                studentCourseService.AddStudentsById(input);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("remove-students-from-course")]
        public IActionResult removeStudents(RemoveStudentsFromCourseDto input)
        {
            try
            {
                studentCourseService.RemoveStudents(input);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get-students-from-course")]
        public IActionResult getStudents(uint courseId)
        {
            try
            {
                return Ok(studentCourseService.GetStudents(courseId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
