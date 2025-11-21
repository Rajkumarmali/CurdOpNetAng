using CURD.DAL.StudentDAL;
using CURD.Data;
using CURD.DTO;
using CURD.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CURD.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly StudentService _services;

        public StudentController(AppDbContext context, StudentService service)
        {
            _context = context;
            _services = service;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddStudent([FromBody] AddStudentDto dto)
        {
            var userId = User.Claims.First(x => x.Type == "UserId").Value;
            _services.AddStudent(dto, userId);
            return Ok(new { message = "User added successfully" });
        }

        /*.                                                                        
        public async Task<IActionResult> AddStudent([FromBody] AddStudentDto dto)    
        {                                                                          
            var userId = User.Claims.First(x => x.Type == "UserId").Value;
            if (userId == null)
            {
                return Unauthorized(new { message = "User is not authorized" });
            }
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                UserId = userId
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User added successfully" });
        }
        */

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getStudents()
        {
            var userId = User.Claims.First(x => x.Type == "UserId").Value;
            var students = await _services.GetAllStudent(userId);
            return Ok(new { students });
        }

        /*
        public async Task<IActionResult> getStudent()
        {
            var userId = User.Claims.First(x => x.Type == "UserId").Value;
            if (userId == null)
            {
                return Unauthorized(new { message = "User is not authorized" });
            }
            var students = _context.Students.Where(x => x.UserId == userId).ToList();
            return Ok(new { students });
        }
         */
        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> updateStudent([FromBody] UpdateStudentDto dto)
        {
            var student = await _services.UpdateStudent(dto);
            return Ok(new { student });
        }
        // public async Task<IActionResult> upDateStudent([FromBody] UpdateStudentDto dto)
        // {
        //     var student = _context.Students.FirstOrDefault(x => x.Id == dto.Id);
        //     if (student == null)
        //     {
        //         return NotFound(new { message = "Student not found" });
        //     }

        //     student.FullName = dto.FullName;
        //     student.Email = dto.Email;
        //     student.Phone = dto.Phone;
        //     student.Address = dto.Address;
        //     await _context.SaveChangesAsync();
        //     return Ok(new { student });
        // }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> deleteStudent(int id)
        {
            _services.DeletStudent(id);
            return Ok(new { message = "Student deleted successfully" });
        }
        // public async Task<IActionResult> deleteStudent(int id)
        // {
        //     var student = _context.Students.FirstOrDefault(x => x.Id == id);
        //     if (student == null)
        //     {
        //         return NotFound(new { message = "Student not found" });
        //     }
        //     _context.Students.Remove(student);
        //     _context.SaveChanges();
        //     return Ok(new { message = "Student deleted successfully" });
        // }


    }
}