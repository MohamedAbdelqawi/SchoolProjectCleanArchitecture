using AutoMapper;

namespace SchoolProject.Core.Maping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdMapping();

        }
    }
}
