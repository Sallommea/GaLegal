using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests
{
    public class ConsultationRequestDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string MessageStatus { get; set; } = string.Empty;
      


    }
}
