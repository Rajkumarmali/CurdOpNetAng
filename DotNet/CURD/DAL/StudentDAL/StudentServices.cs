using CURD.DTO;
using CURD.Model;

namespace CURD.DAL.StudentDAL
{
    public class StudentService
    {
        private readonly IStudent _studentRepo;
        public StudentService(IStudent studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public void AddStudent(AddStudentDto dto, string userId)
        {
            _studentRepo.AddStudent(dto, userId);
        }

        public Task<List<Student>> GetAllStudent(string userId)
        {
            return _studentRepo.GetAllStudent(userId);
        }

        public Task<Student> UpdateStudent(UpdateStudentDto dto)
        {
            return _studentRepo.UpdateStudent(dto);
        }
        public void DeletStudent(int id)
        {
            _studentRepo.DeleteStudent(id);
        }
    }
}