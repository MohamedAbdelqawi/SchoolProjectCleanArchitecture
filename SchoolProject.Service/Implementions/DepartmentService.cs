using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementions
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id)).Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                                                                                       .Include(x => x.Students)
                                                                                       .Include(x => x.Instructors)
                                                                                       .Include(x => x.Instructor).FirstOrDefaultAsync();
            return department;

        }
    }
}
