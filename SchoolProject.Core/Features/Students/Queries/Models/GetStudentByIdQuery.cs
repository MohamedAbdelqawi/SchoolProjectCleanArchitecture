using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Results;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public int ID { get; set; }
        public GetStudentByIdQuery(int id)
        {
            this.ID = id;
        }
    }
}
