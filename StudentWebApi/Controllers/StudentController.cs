using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Data.Repository;
using StudentWebApi.Models;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _studentRepository.GetAllStudentsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById([FromRoute]int id)
        {
            var result = await _studentRepository.GetStudentById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetStudentByFirstName([FromRoute]string name)
        {
            var result = await _studentRepository.GetStudentByFirstName(name);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddStudent([FromBody]StudentModel model)
        {
            var studentId = await _studentRepository.AddStudentAsync(model);
            return CreatedAtAction("GetStudentById", new {id = studentId, Controller = "Student"}, studentId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute]int id, [FromBody]StudentModel model)
        {
            await _studentRepository.UpdateStudentAsync(id, model);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStudentPatch([FromRoute] int id, [FromBody] JsonPatchDocument model)
        {
            await _studentRepository.UpdateStudentPatchAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
            return Ok();
        }
    }
}
