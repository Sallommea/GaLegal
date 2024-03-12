using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests
{
    public class PaginatedListResult<T>
    {
        public List<T>? ResultList { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalRecords { get; set; }
    }
}
