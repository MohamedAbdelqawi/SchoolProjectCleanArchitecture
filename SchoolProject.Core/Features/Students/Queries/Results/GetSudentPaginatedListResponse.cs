namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetSudentPaginatedListResponse
    {
        public GetSudentPaginatedListResponse(int studID, string? name, string? address, string? dName)
        {
            StudID = studID;
            //NameAr = nameAr;
            //NameEn = nameEn;
            Name = name;
            Address = address;
            DepartmentName = dName;
        }

        public int StudID { get; set; }
        //public string NameAr { get; set; }
        //public string NameEn { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? DepartmentName { get; set; }

    }
}
