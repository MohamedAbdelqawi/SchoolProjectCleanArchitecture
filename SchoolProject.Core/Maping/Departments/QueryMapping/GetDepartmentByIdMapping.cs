using AutoMapper;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Data.Commons;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Maping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIDResponse>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.DNameAr, src.DNameEn)))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.DID))
                .ForMember(des => des.ManagerName, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.Instructor.ENameAr, src.Instructor.ENameEn)))
                .ForMember(des => des.subjectlist, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(des => des.studentlist, opt => opt.MapFrom(src => src.Students))
                .ForMember(des => des.instructorlist, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.SubID))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));

            CreateMap<Student, StudentResponse>()
               .ForMember(des => des.Id, opt => opt.MapFrom(src => src.StudID))
               .ForMember(des => des.Name, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.NameAr, src.NameEn)));


            CreateMap<Instructor, InstructorResponse>()
               .ForMember(des => des.Id, opt => opt.MapFrom(src => src.InsId))
               .ForMember(des => des.Name, opt => opt.MapFrom(src => GeneralLocalizableEntity.Localize(src.ENameAr, src.ENameEn)));


        }
    }
}
