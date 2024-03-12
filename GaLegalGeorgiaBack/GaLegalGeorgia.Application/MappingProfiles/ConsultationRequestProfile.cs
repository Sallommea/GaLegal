using AutoMapper;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.CreateConsultationRequest;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetConsultationRequestDetails;
using GaLegalGeorgia.Domain;

namespace GaLegalGeorgia.Application.MappingProfiles
{
    public class ConsultationRequestProfile : Profile
    {
        public ConsultationRequestProfile()
        {
            CreateMap<ConsultationRequestDto, ConsultationRequest>().ReverseMap();
            CreateMap<ConsultationRequest, ConsultationRequestDetailsDto>().ReverseMap();
            CreateMap<CreateConsultationRequestCommand, ConsultationRequest>();
        }
    }
}
