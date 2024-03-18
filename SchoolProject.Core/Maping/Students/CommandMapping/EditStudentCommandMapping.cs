using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Maping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>().ForMember(des => des.DID, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(des => des.NameEn, opt => opt.MapFrom(src => src.NameEn))
                .ForMember(des => des.NameAr, opt => opt.MapFrom(src => src.NameAr))
           .ForMember(des => des.StudID, opt => opt.MapFrom(src => src.Id));

        }
    }
}
