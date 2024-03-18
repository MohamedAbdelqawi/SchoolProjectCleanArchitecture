using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Commons;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
                                                       IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
                                                       IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetSudentPaginatedListResponse>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<sharedResources> _stringLocalizer;

        public StudentQueryHandler(IStudentService studentService,
                                   IMapper mapper,
                                   IStringLocalizer<sharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var reslut = Success(studentListMapper);
            reslut.Meta = new { count = studentListMapper.Count() };
            return reslut;
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var stud = await _studentService.GetStudentByIdAsync(request.ID);
            if (stud == null) return NotFound<GetSingleStudentResponse>(_stringLocalizer[sharedResourceskeys.NotFound]);
            var result = _mapper.Map<GetSingleStudentResponse>(stud);
            return Success(result, "Successed");
        }

        public async Task<PaginatedResult<GetSudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetSudentPaginatedListResponse>> expression = e => new GetSudentPaginatedListResponse(e.StudID, GeneralLocalizableEntity.Localize(e.NameAr, e.NameEn), e.Address, GeneralLocalizableEntity.Localize(e.Department.DNameAr, e.Department.DNameEn));
            //var querable = _studentService.GetStudentsQuerable();
            var filterquery = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            var paginatedList = await filterquery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginatedList.Meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;
        }
    }
}
