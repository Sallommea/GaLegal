using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails
{
    public enum LanguageDetails
    {
        en,
        ge,

    }
        public sealed record GetPracticeAreasDetailsQuery(int Id, string Language ) : IRequest<PracticeAreaDetailDto>;
    
}
