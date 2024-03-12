using GaLegalGeorgia.Domain;

namespace GaLegalGeorgia.Application.Contracts.Persistence
{
    public interface IAdminRepository
    {
        Task<AdminModel> GetAdmin();

    }
}
