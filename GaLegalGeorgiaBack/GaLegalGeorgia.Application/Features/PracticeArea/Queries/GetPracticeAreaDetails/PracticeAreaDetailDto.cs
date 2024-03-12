using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails
{
    public class PracticeAreaDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<string> Content { get; set; }

       
    }
}
