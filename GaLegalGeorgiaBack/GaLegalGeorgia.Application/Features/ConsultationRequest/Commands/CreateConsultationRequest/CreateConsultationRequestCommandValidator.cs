using FluentValidation;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.CreateConsultationRequest
{
    public class CreateConsultationRequestCommandValidator : AbstractValidator<CreateConsultationRequestCommand>
    {
        public CreateConsultationRequestCommandValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters");

            RuleFor(p => p.LastName).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters");

            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters")
               .MinimumLength(9).WithMessage("{PropertyName} must be at least 9 characters");

            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters")
              .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters");

        }
    }
}
