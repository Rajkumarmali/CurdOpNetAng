using CURD.DAL.EmailDAL;
using CURD.DAL.SmsDAL;
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
        private readonly EmailServices _emailServices;
        private readonly SmsServices _smsServices;
        public StudentRepo(AppDbContext context, EmailServices emailServices, SmsServices smsServices)
        {
            _context = context;
            _emailServices = emailServices;
            _smsServices = smsServices;
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

            string body =
                 "=====================================\n" +
                 "        📘 New Student Added         \n" +
                 "=====================================\n\n" +
                 $"Full Name : {student.FullName}\n" +
                 $"Email     : {student.Email}\n" +
                 $"Phone     : {student.Phone}\n" +
                 $"Address   : {student.Address}\n\n" +
                 "-------------------------------------\n" +
                 "This is an automated notification.\n";
            _emailServices.SendEmailAsync("Add a new Student", body);
            _smsServices.SendSms("7372907537", "Hii");
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
            string body = $"A student is deleted. Student ID: {student.Id} , FullName : {student.FullName}";
            _emailServices.SendEmailAsync("Delete a student", body);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}