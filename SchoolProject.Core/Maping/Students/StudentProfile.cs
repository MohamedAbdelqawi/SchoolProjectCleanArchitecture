using AutoMapper;

namespace SchoolProject.Core.Maping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
        }
    }
}
