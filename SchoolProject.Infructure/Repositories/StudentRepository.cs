using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {

        private readonly DbSet<Student> _students;
        public StudentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _students = dBContext.Set<Student>();
        }



        public async Task<List<Student>> GetStudentsListAsync() => await _students.Include(d => d.Department).ToListAsync();





    }
}
