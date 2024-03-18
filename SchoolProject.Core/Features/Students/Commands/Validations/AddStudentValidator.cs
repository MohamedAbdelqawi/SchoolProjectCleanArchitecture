using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<sharedResources> _stringLocalizer;

        public AddStudentValidator(IStudentService studentService, IStringLocalizer<sharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_stringLocalizer[sharedResourceskeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[sharedResourceskeys.Required])
                .MaximumLength(100).WithMessage("name max length  is 10");
            RuleFor(x => x.NameAr)
               .NotEmpty().WithMessage(_stringLocalizer[sharedResourceskeys.NotEmpty])
               .NotNull().WithMessage(_stringLocalizer[sharedResourceskeys.Required])
               .MaximumLength(100).WithMessage("name max length  is 10");


            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{propertyName} " + _stringLocalizer[sharedResourceskeys.NotEmpty])
                .NotNull().WithMessage("{propertyValue} " + _stringLocalizer[sharedResourceskeys.Required])
                .MaximumLength(100).WithMessage("{propertyValue} max length  is 10");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.isNameExist(model.NameAr, model.NameEn))
                .WithMessage("Name is Exist");
            RuleFor(x => x.NameAr)
               .MustAsync(async (model, key, CancellationToken) => !await _studentService.isNameExist(model.NameAr, model.NameEn))
               .WithMessage("Name is Exist");

        }
    }
}
