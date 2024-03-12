using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using MediatR;
using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaLegalGeorgia.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails
{
    public sealed class GetPracticeAreaDetailsQueryHandler : IRequestHandler<GetPracticeAreasDetailsQuery, PracticeAreaDetailDto>
    {
       
        private readonly IPracticeAreaRepository _practiceAreaRepository;

        public GetPracticeAreaDetailsQueryHandler( IPracticeAreaRepository practiceAreaRepository)
        {
            this._practiceAreaRepository = practiceAreaRepository;
        }

        public async Task<PracticeAreaDetailDto> Handle(GetPracticeAreasDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database to get the practice area details
            var practiceArea = await _practiceAreaRepository.GetByIdAsync(request.Id);

            // Verify that the record exists
            if (practiceArea == null)
                throw new NotFoundException(nameof(PracticeArea), request.Id);

            // Create a single PracticeAreaDetailDto object based on the language
            PracticeAreaDetailDto data;

            if (request.Language == "en")
            {
                data = new PracticeAreaDetailDto
                {
                    Id = practiceArea.Id,
                    Title = practiceArea.TitleEn,
                    Content = practiceArea.ContentEn.Split('$')
                };
            }
            else
            {
                data = new PracticeAreaDetailDto
                {
                    Id = practiceArea.Id,
                    Title = practiceArea.Title,
                    Content = practiceArea.Content.Split('$')
                };
            }

            return data;

        }
    }
}
