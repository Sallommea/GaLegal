using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using MediatR;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.DeleteConsultationRequest
{
    public class DeleteConsultationRequestCommandHandler : IRequestHandler<DeleteConsultationRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IConsultationRequest _consultationRequestRepository;

        public DeleteConsultationRequestCommandHandler(IMapper mapper, IConsultationRequest consultationRequestRepository)
        {
            this._mapper = mapper;
            this._consultationRequestRepository = consultationRequestRepository;
        }
        public async Task<Unit> Handle(DeleteConsultationRequestCommand request, CancellationToken cancellationToken)
        {
            var consultationRequestToDelete = await _consultationRequestRepository.GetByIdAsync(request.Id);

            if (consultationRequestToDelete == null)
                throw new NotFoundException(nameof(ConsultationRequest), request.Id);

            await _consultationRequestRepository.DeleteAsync(consultationRequestToDelete);

            return Unit.Value;
        }
    }
}
