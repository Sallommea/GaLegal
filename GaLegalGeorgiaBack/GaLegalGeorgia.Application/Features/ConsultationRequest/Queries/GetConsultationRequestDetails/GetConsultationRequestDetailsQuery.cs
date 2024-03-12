using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetConsultationRequestDetails
{

    public record GetConsultationRequestDetailsQuery(int Id) : IRequest<ConsultationRequestDetailsDto>;
}
