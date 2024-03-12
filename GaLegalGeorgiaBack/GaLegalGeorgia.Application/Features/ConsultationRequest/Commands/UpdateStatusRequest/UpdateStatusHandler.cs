using GaLegalGeorgia.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.UpdateStatusRequest
{
    public class UpdateStatusHandler : IRequestHandler<UpdateConsultationStatusCommand>
    {
        private readonly IConsultationRequest _consultationRequest;

        public UpdateStatusHandler(IConsultationRequest consultationRequest)
        {
            _consultationRequest = consultationRequest;
        }
        public async Task Handle(UpdateConsultationStatusCommand request, CancellationToken cancellationToken)
        {
            // You should add error handling, validation, and additional logic as needed.

            // Fetch the consultation request based on its ID.
            var submissionId = request.Id;
            var newStatus = request.Status;

            // Check if the consultation request with the given ID exists.
            var submission = await _consultationRequest.GetByIdAsync(submissionId);

            if (submission == null)
            {
                // Handle the case where the submission with the provided ID is not found.
                throw new Exception("Submission not found");
            }

            // Update the status of the consultation request.
            if (await _consultationRequest.UpdateStatus(submissionId, newStatus))
            {
                // The status was successfully updated. You can log this if needed.
            }
            else
            {
                // Handle the case where the update operation failed.
                throw new Exception("Status update failed");
            }
        }
    }
    }

