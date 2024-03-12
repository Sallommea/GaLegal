using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Domain;
using GaLegalGeorgia.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Persistence.Repositories
{
    public class PracticeAreaRepository : GenericRepository<PracticeArea>, IPracticeAreaRepository
    {
        public PracticeAreaRepository(GaLegalDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsPracticeAreaUnique(string name)
        {
            return await _context.PracticeAreas.AnyAsync(q => q.Title == name) == false;
        }
    }
}
