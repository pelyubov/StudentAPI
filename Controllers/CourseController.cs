using Microsoft.AspNetCore.Mvc;
using StudentAPI.Dtos.CourseDtos;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService _courseService)
        {
            courseService = _courseService;
        }

        [HttpGet("get-all")]
        //[ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public IActionResult Get()
        {
            return Ok(courseService.GetAllCourses());
        }

        [HttpGet("get/{id:min(0)}")]
        public IActionResult Get(uint id)
        {
            try
            {
                return Ok(courseService.GetCourse(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("update/{id:min(0)}")]
        public IActionResult Update(uint id, CreateCourseDto input)
        {
            try
            {
                courseService.UpdateCourse(id, input);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("add")]
        public IActionResult Post(CreateCourseDto input)
        {
            return Ok(courseService.CreateCourse(input));
        }

        [HttpDelete("delete")]
        public IActionResult Delete(uint id)
        {
            try
            {
                courseService.DeleteCourse(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
