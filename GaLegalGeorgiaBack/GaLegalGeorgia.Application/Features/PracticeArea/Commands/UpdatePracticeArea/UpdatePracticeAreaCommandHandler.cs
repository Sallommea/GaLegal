using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Commands.UpdatePracticeArea
{
    public class UpdatePracticeAreaCommandHandler : IRequestHandler<UpdatePracticeAreaCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPracticeAreaRepository _practiceAreaRepository;

        public UpdatePracticeAreaCommandHandler(IMapper mapper, IPracticeAreaRepository practiceAreaRepository)
        {
            this._mapper = mapper;
            this._practiceAreaRepository = practiceAreaRepository;
        }
        public async Task Handle(UpdatePracticeAreaCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            var validator = new UpdatePracticeAreaCommandValidator(_practiceAreaRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
              throw new BadRequestException("Invalid Practice Area", validationResult);
            }
            // convert to domain entity object
            var practiceAreaToUpdate = _mapper.Map<Domain.PracticeArea>(request);

            // add to database
            await _practiceAreaRepository.UpdateAsync(practiceAreaToUpdate);
        }
    }
}
