using AutoMapper;
using GaLegalGeorgia.Application.Features.PracticeArea.Commands.CreatePracticeArea;
using GaLegalGeorgia.Application.Features.PracticeArea.Commands.UpdatePracticeArea;
using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas;
using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails;
using GaLegalGeorgia.Domain;

namespace GaLegalGeorgia.Application.MappingProfiles
{
    public class PracticeAreaProfile : Profile
    {
        public PracticeAreaProfile()
        {
            CreateMap<PracticeArea, PracticeArea>().ReverseMap();
            CreateMap<CreatePracticeAreaCommand, PracticeArea>();
            CreateMap<UpdatePracticeAreaCommand, PracticeArea>();
        }
    }
}
