using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private DbSet<Department> departments;
        public DepartmentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            departments = dbContext.Set<Department>();

        }
    }
}
