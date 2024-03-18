using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Commons;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Maping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>().ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.Department.DNameAr, src.Department.DNameEn))).
                ForMember(des => des.Name, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.NameAr, src.NameEn)));
        }
    }
}
