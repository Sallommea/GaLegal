
using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests
{
    public class GetConsultationRequestsQueryHandler : IRequestHandler<GetConsultationRequestsQuery,
        PaginatedListResult<ConsultationRequestDto>>
    {
        private readonly IConsultationRequest _consultationRequestRepository;
        private readonly IMapper _mapper;

        public GetConsultationRequestsQueryHandler(IConsultationRequest consultationRequestRepository,
            IMapper mapper)
        {
            this._consultationRequestRepository = consultationRequestRepository;
            this._mapper = mapper;
        }
        public async Task<PaginatedListResult<ConsultationRequestDto>> Handle(GetConsultationRequestsQuery request, CancellationToken cancellationToken)
        {
            var result = new PaginatedListResult<ConsultationRequestDto>();

            var paginated = await _consultationRequestRepository.GetPaginated(
                pageNumber: request.PageNumber,
                itemsPerPage: request.ItemsPerPage
                );

            var mappedList = _mapper.Map<List<ConsultationRequestDto>>(paginated.ResultList);
            var sortedList = mappedList.OrderByDescending(item => item.Id).ToList();

            result.TotalRecords = paginated.TotalRecords;
            result.ResultList = mappedList;
            result.TotalPages = paginated.TotalPages;

            return result;
        }
    }


}
