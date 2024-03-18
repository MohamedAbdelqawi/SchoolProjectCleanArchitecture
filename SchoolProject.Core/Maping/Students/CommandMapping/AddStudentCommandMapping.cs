using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Maping.Students
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>().ForMember(des => des.DID, opt => opt.MapFrom(src => src.DepartmentId)).
                ForMember(des => des.NameEn, opt => opt.MapFrom(src => src.NameEn)).
               ForMember(des => des.NameAr, opt => opt.MapFrom(src => src.NameAr));

        }
    }
}
