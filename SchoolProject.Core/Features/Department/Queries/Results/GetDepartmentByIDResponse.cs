using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Department.Queries.Results
{
    public class GetDepartmentByIDResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<StudentResponse>? studentlist { get; set; }
        public List<SubjectResponse>? subjectlist { get; set; }
        public List<InstructorResponse>? instructorlist { get; set; }
    }

    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }



    }

    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class InstructorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
