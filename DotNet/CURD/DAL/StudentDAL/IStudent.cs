using CURD.DTO;
using CURD.Model;

namespace CURD.DAL.StudentDAL
{
    public interface IStudent
    {
        void AddStudent(AddStudentDto stu, string userId);
        Task<List<Student>> GetAllStudent(string userId);
        Task<Student> UpdateStudent(UpdateStudentDto dto, string userId);
        void DeleteStudent(int id, string userId);
    }
}