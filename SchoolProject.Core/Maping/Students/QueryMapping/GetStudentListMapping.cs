using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Commons;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Maping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>().ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.Department.DNameAr, src.Department.DNameEn))).
                ForMember(des => des.Name, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.NameAr, src.NameEn)));


        }
    }
}
