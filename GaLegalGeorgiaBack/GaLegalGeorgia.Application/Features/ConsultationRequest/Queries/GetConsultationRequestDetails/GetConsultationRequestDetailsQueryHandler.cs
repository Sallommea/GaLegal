using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetConsultationRequestDetails
{
    public class GetConsultationRequestDetailsQueryHandler : IRequestHandler<GetConsultationRequestDetailsQuery, ConsultationRequestDetailsDto>
    {
        private readonly IConsultationRequest _consultationRequestRepository;
        private readonly IMapper _mapper;

        public GetConsultationRequestDetailsQueryHandler(IConsultationRequest consultationRequestRepository, IMapper mapper)
        {
            this._consultationRequestRepository = consultationRequestRepository;
            this._mapper = mapper;
        }
        public async Task<ConsultationRequestDetailsDto> Handle(GetConsultationRequestDetailsQuery request, CancellationToken cancellationToken)
        {
            var consultationRequest = await _consultationRequestRepository.GetByIdAsync(request.Id);
            var data = _mapper.Map<ConsultationRequestDetailsDto>(consultationRequest);

            return data;
        }
    }
}
