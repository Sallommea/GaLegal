using AutoMapper;
using GaLegalGeorgia.Application.Features.Admin.Queries.getUser;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetConsultationRequestDetails;
using GaLegalGeorgia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.MappingProfiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminModel, AdminDto>().ReverseMap();
        }
    }
}
