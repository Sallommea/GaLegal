using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.UpdateStatusRequest
{
    public class UpdateConsultationStatusCommand : IRequest
    {
       public int Id { get; set; }
       public string Status { get; set; } = string.Empty;
    }
}
