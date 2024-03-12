using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests;
using GaLegalGeorgia.Domain;

namespace GaLegalGeorgia.Application.Contracts.Persistence
{
    public interface IConsultationRequest : IGenericRepository<ConsultationRequest>
    {
        Task<bool> UpdateStatus(int Id, string newStatus);
        Task<PaginatedListResult<ConsultationRequest>> GetPaginated(int pageNumber, int itemsPerPage);
    }
}
