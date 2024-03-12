using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Commands.CreatePracticeArea
{
    public class CreatePracticeAreaCommandHandler : IRequestHandler<CreatePracticeAreaCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPracticeAreaRepository _practiceAreaRepository;

        public CreatePracticeAreaCommandHandler(IMapper mapper, IPracticeAreaRepository practiceAreaRepository)
        {
            this._mapper = mapper;
            this._practiceAreaRepository = practiceAreaRepository;
        }
        public async Task<int> Handle(CreatePracticeAreaCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            var validator = new CreatePracticeAreaCommandValidator(_practiceAreaRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid PracticeArea", validationResult);
            }
            // convert to domain entity object
            var practiceAreaToCreate = _mapper.Map<Domain.PracticeArea>(request);

            // add to database
            await _practiceAreaRepository.CreateAsync(practiceAreaToCreate);

            // return record id
            return practiceAreaToCreate.Id;
        }
    }
}
