using MediatR;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.CreateConsultationRequest
{
    public class CreateConsultationRequestCommand : IRequest<int>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MessageStatus { get; set; } = string.Empty;
        public string? Company { get; set; }

        public string? Description { get; set; }

    }
}
