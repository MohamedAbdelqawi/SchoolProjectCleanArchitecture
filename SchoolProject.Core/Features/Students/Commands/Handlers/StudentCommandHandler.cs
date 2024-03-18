using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
                                                         , IRequestHandler<EditStudentCommand, Response<string>>
        , IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<sharedResources> _stringLocalizer;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<sharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapper = _mapper.Map<Student>(request);
            var reslut = await _studentService.AddStudentAsync(studentmapper);

            if (reslut == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student is null) return NotFound<string>("Student not found");
            var studentmapper = _mapper.Map(request, student);
            var reslut = await _studentService.EditStudentAsync(studentmapper);
            if (reslut == "success") return Success("Edit Successfully");
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdwithoutIncludeAsync(request.id);
            if (student is null) return NotFound<string>("Student not found");
            var reslut = await _studentService.DeleteStudentAsync(student);
            if (reslut == "success") return Deleted<string>();
            else return BadRequest<string>();
        }
    }
}
