using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {
        private DbSet<Subjects> subjects;
        public SubjectRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            subjects = dbContext.Set<Subjects>();

        }
    }
}
