using GaLegalGeorgia.Domain;

namespace GaLegalGeorgia.Application.Contracts.Persistence
{
    public interface IPracticeAreaRepository : IGenericRepository<PracticeArea>
    {
        Task<bool> IsPracticeAreaUnique(string name);

      
    }
}
