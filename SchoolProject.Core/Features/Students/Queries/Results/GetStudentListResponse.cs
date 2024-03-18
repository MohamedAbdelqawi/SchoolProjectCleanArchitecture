namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetStudentListResponse
    {
        public int StudID { get; set; }

        //public string NameAr { get; set; }
        //public string NameEn { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string? DepartmentName { get; set; }


    }
}
