using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Commons;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementions
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var student = _studentRepository.GetTableNoTracking().Include(x => x.Department).Where(x => x.StudID.Equals(studentId)).FirstOrDefault();
            return student;
        }

        public async Task<string> AddStudentAsync(Student student)
        {
            var studentreslut = await isNameExist(student.NameAr, student.NameEn);
            if (studentreslut) return "Exist";
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> isNameExist(string nameAr, string nameEn)
        {
            var student = _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr) || x.NameEn.Equals(nameEn)).FirstOrDefault();
            if (student == null)
                return false;
            return true;

        }

        public async Task<bool> isNameExistExcludeSelf(string name, int id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(x => (x.NameEn.Equals(name) && !x.StudID.Equals(id))).FirstOrDefaultAsync();
            if (student == null)
                return false;
            return true;
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "success";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }

        }

        public async Task<Student> GetStudentByIdwithoutIncludeAsync(int studentId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            return student;
        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return _studentRepository.GetTableNoTracking().Include(d => d.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(d => d.Department).AsQueryable();
            if (search is not null)
                querable = querable.Where(x => x.NameAr.Contains(search.ToLower()) || x.NameEn.Contains(search.ToLower()) || x.Address.Contains(search.ToLower()));

            switch (orderingEnum)
            {

                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => GeneralLocalizableEntity.Localize(x.NameAr, x.NameEn));
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable = querable.OrderBy(x => GeneralLocalizableEntity.Localize(x.Department.DNameAr, x.Department.DNameEn));
                    break;
                default:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
            }
            return querable;


        }
    }
}
