using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public IQueryable<Student> GetStudentsQuerable();
        public Task<Student> GetStudentByIdAsync(int studentId);
        public Task<Student> GetStudentByIdwithoutIncludeAsync(int studentId);
        public Task<string> AddStudentAsync(Student student);
        public Task<string> EditStudentAsync(Student student);
        public Task<string> DeleteStudentAsync(Student student);

        public Task<bool> isNameExist(string nameAr, string nameEn);
        public Task<bool> isNameExistExcludeSelf(string name, int id);
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);


    }
}
