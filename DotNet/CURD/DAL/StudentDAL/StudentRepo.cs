using CURD.Data;
using CURD.DTO;
using CURD.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CURD.DAL.StudentDAL
{
    public class StudentRepo : IStudent
    {
        private readonly AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddStudent(AddStudentDto dto, string userId)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                UserId = userId
            };
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public async Task<List<Student>> GetAllStudent(string userId)
        {
            var students = await _context.Students.Where(x => x.UserId == userId).ToListAsync();
            return students;
        }

        public async Task<Student> UpdateStudent(UpdateStudentDto dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == dto.Id);
            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.Phone = dto.Phone;
            student.Address = dto.Address;
            _context.SaveChanges();
            return student;
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}