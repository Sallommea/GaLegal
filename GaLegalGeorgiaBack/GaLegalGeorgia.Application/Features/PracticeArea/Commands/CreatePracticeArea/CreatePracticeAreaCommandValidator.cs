using FluentValidation;
using GaLegalGeorgia.Application.Contracts.Persistence;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Commands.CreatePracticeArea
{
    public class CreatePracticeAreaCommandValidator : AbstractValidator<CreatePracticeAreaCommand>
    {
        private readonly IPracticeAreaRepository _practiceAreaRepository;
        public CreatePracticeAreaCommandValidator(IPracticeAreaRepository practiceAreaRepository)
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.Content).NotEmpty().WithMessage("Content cannot be empty.")
                .NotNull().WithMessage("Content cannot be null.");

            RuleFor(p => p.TitleEn)
                  .NotEmpty().WithMessage("{PropertyName} is required")
                  .NotNull()
                  .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.ContentEn).NotEmpty().WithMessage("Content cannot be empty.")
                .NotNull().WithMessage("Content cannot be null.");

            RuleFor(q => q)
                .MustAsync(PracticeAreaNameUnique)
                .WithMessage("Practice Area Already Exists");

            this._practiceAreaRepository = practiceAreaRepository;
        }

        private Task<bool> PracticeAreaNameUnique(CreatePracticeAreaCommand command, CancellationToken token)
        {
            return _practiceAreaRepository.IsPracticeAreaUnique(command.Title);
        }
    }
}
