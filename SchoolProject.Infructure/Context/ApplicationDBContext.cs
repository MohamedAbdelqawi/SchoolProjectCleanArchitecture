using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentSubject>().HasKey(x => new { x.SubID, x.DID });
            modelBuilder.Entity<Ins_Subject>().HasKey(x => new { x.SubId, x.InsId });
            modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.SubID, x.StudID });

            modelBuilder.Entity<Instructor>().HasOne(x => x.Supervisor).WithMany(x => x.Instructors).HasForeignKey(x => x.SupervisorId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>().HasOne(x => x.Instructor).WithOne(x => x.departmentManager).HasForeignKey<Department>(x => x.InsManager).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
