using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentByIDQuery, Response<GetDepartmentByIDResponse>>
    {
        private readonly IStringLocalizer<sharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentQueryHandler(IStringLocalizer<sharedResources> stringLocalizer, IDepartmentService departmentService,
                                      IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _mapper = mapper;
        }
        public async Task<Response<GetDepartmentByIDResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            var response = await _departmentService.GetDepartmentById(request.Id);
            if (response == null) return NotFound<GetDepartmentByIDResponse>(_stringLocalizer[sharedResourceskeys.NotFound]);

            var mapper = _mapper.Map<GetDepartmentByIDResponse>(response);




            return Success(mapper);
        }
    }
}
