using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi.Data.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<StudentModel>> GetAllStudentsAsync()
        {
            var allStudents = await _context.Students.ToListAsync();

            return _mapper.Map<List<StudentModel>>(allStudents);
        }

        public async Task<StudentModel> GetStudentById(int id)
        {
            var result = await _context.Students.FindAsync(id);
               
            return _mapper.Map<StudentModel>(result);
        }

        public async Task<StudentModel> GetStudentByFirstName(string name)
        {
            var result = await _context.Students.Where(x => x.FirstName == name).FirstOrDefaultAsync();
                
            return _mapper.Map<StudentModel>(result);
        }

        public async Task<int> AddStudentAsync(StudentModel model)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Age = model.Age,
                Nationality = model.Nationality
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student.Id;
        }

        public async Task UpdateStudentAsync(int id, StudentModel model)
        {
            var student = new Student
            {
                Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Age = model.Age,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Nationality = model.Nationality
            };

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

            
       

        public async Task UpdateStudentPatchAsync(int id, JsonPatchDocument model)
        {
            var student = await _context.Students.FindAsync(id);

            if(student != null)
            {
                model.ApplyTo(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = new Student { Id = id };

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
