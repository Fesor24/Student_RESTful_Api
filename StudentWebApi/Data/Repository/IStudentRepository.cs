using StudentWebApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace StudentWebApi.Data.Repository
{
    public interface IStudentRepository
    {
        Task<List<StudentModel>> GetAllStudentsAsync();
        Task<StudentModel> GetStudentById(int id);
        Task<StudentModel> GetStudentByFirstName(string name);
        Task<int> AddStudentAsync(StudentModel model);
        Task UpdateStudentAsync(int id, StudentModel model);
        Task UpdateStudentPatchAsync(int id, JsonPatchDocument model);
        Task DeleteStudentAsync(int id);
    }
}
