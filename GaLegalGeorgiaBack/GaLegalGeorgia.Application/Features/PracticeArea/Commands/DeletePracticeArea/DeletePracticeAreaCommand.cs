using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Commands.DeletePracticeArea
{
    public class DeletePracticeAreaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
