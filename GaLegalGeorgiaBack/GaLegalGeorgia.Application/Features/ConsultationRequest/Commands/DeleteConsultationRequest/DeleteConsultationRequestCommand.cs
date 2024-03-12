using MediatR;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.DeleteConsultationRequest
{
    public class DeleteConsultationRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
