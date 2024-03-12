using FluentValidation;
using GaLegalGeorgia.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Commands.UpdatePracticeArea
{
    public class UpdatePracticeAreaCommandValidator : AbstractValidator<UpdatePracticeAreaCommand>
    {
        private readonly IPracticeAreaRepository _practiceAreaRepository;

        public UpdatePracticeAreaCommandValidator(IPracticeAreaRepository practiceAreaRepository)
        {
            RuleFor(p => p.Id)
         .NotNull()
         .MustAsync(PracticeAreaMustExist);

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

            // RuleFor(q => q)
            //  .MustAsync(PracticeAreaTitleUnique)
            //  .WithMessage("Leave type already exists");

            this._practiceAreaRepository= practiceAreaRepository;
        }

        private async Task<bool> PracticeAreaMustExist(int id, CancellationToken arg2)
        {
            var practiceArea = await _practiceAreaRepository.GetByIdAsync(id);
            return practiceArea != null;
        }

        private async Task<bool> PracticeAreaTitleUnique(UpdatePracticeAreaCommand command, CancellationToken token)
        {
            return await _practiceAreaRepository.IsPracticeAreaUnique(command.Title);
        }
    }
}

