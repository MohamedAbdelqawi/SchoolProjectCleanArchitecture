using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Data.AppMetaData;
using SchoolProjectApi.Base;

namespace SchoolProjectApi.Controllers
{

    public class DepartmentController : AppControllerBase
    {

        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetDepartmentByID([FromRoute] int id)
        {
            var Response = await Mediator.Send(new GetDepartmentByIDQuery(id));
            return NewResult(Response);
        }
    }
}
