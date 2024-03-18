using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;

        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage("NameEn must not be empty")
                .NotNull().WithMessage("NameEn must not be null")
                .MaximumLength(100).WithMessage("name max length  is 10");
            RuleFor(x => x.NameAr)
               .NotEmpty().WithMessage("NameAr must not be empty")
               .NotNull().WithMessage("NameAr must not be null")
               .MaximumLength(100).WithMessage("name max length  is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{propertyName} must not be empty")
                .NotNull().WithMessage("{propertyValue} must not be null")
                .MaximumLength(100).WithMessage("{propertyValue} max length  is 10");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.isNameExistExcludeSelf(model.NameEn, model.Id))
                .WithMessage("NameEn is Exist");



        }
    }
}

