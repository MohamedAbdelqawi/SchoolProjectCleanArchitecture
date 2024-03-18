using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;
using SchoolProjectApi.Base;

namespace SchoolProjectApi.Controllers
{


    public class StudentController : AppControllerBase
    {

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var Response = await Mediator.Send(new GetStudentListQuery());
            return Ok(Response);
        }
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var Response = await Mediator.Send(query);
            return Ok(Response);
        }
        [HttpGet(Router.StudentRouting.GetByID)]
        public async Task<IActionResult> GetStudentByID([FromRoute] int id)
        {
            var Response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(Response);
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> Update([FromBody] EditStudentCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return NewResult(Response);
        }

        [HttpPut(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(Response);
        }
    }
}
