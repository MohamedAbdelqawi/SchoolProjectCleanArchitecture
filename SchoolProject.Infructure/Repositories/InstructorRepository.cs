using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        private DbSet<Instructor> instructors;
        public InstructorRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            instructors = dbContext.Set<Instructor>();

        }
    }
}
