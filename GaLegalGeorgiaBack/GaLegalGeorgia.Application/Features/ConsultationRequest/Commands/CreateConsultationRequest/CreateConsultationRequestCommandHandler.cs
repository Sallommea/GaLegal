using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using GaLegalGeorgia.Application.Features.PracticeArea.Commands.CreatePracticeArea;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.CreateConsultationRequest
{
    public class CreateConsultationRequestCommandHandler : IRequestHandler<CreateConsultationRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IConsultationRequest _consultationRequestRepository;

        public CreateConsultationRequestCommandHandler(IMapper mapper, IConsultationRequest consultationRequestRepository)
        {
            this._mapper = mapper;
            this._consultationRequestRepository = consultationRequestRepository;
        }
        public async Task<int> Handle(CreateConsultationRequestCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            var validator = new CreateConsultationRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid PracticeArea", validationResult);
            }
            var consultationRequestToCreate = _mapper.Map<Domain.ConsultationRequest>(request);

            await _consultationRequestRepository.CreateAsync(consultationRequestToCreate);

            return consultationRequestToCreate.Id;
        }
    }
}
