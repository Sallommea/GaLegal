using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests;
using GaLegalGeorgia.Domain;
using GaLegalGeorgia.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace GaLegalGeorgia.Persistence.Repositories
{
    public class ConsultationRequestRepository : GenericRepository<ConsultationRequest>, IConsultationRequest
    {
        public ConsultationRequestRepository(GaLegalDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> UpdateStatus(int Id, string newStatus)
        {
         
            // Find the submission by its ID.
            var submission = await _context.ConsultationRequests.FindAsync(Id);

            if (submission == null)
            {
                // Submission with the given ID doesn't exist.
                return false;
            }

            // Update the status field.
            submission.MessageStatus = newStatus;

            try
            {
                // Save the changes to the database.
                await _context.SaveChangesAsync();
                return true; // Update successful.
            }
            catch (DbUpdateException)
            {
                // Handle database update error, e.g., a concurrency conflict.
                return false; // Update failed.
            }
        }

        public async Task<PaginatedListResult<ConsultationRequest>> GetPaginated(int pageNumber, int itemsPerPage)
        {
            var result = new PaginatedListResult<ConsultationRequest>();

            result.TotalRecords = await _context.Set<ConsultationRequest>().CountAsync();
            result.TotalPages = (int)Math.Ceiling((double)result.TotalRecords / itemsPerPage);
            result.ResultList = await _context.Set<ConsultationRequest>()
                .OrderByDescending(x => x.Id)
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return result;
        }


    }
}
