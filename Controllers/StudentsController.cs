using Microsoft.AspNetCore.Mvc;
using StudentAPI.Dtos.StudentDtos;
using StudentAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("get-all")]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("get/{id:min(0)}")]
        public IActionResult Get(uint id)
        {
            try
            {
                return Ok(_studentService.GetStudent(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("update/{id:min(0)}")]
        public IActionResult Update(uint id, CreateStudentDto input)
        {
            try
            {
                _studentService.UpdateStudent(id, input);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("add")]
        public IActionResult Post(CreateStudentDto input)
        {
            return Ok(_studentService.CreateStudent(input));
        }

        [HttpDelete("delete")]
        public IActionResult Delete(uint id)
        {
            try
            {
                _studentService.DeleteStudent(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
