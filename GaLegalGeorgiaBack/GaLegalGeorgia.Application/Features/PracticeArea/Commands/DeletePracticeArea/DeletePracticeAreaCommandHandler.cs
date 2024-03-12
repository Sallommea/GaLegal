using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.PracticeArea.Commands.DeletePracticeArea
{
    public class DeletePracticeAreaCommandHandler : IRequestHandler<DeletePracticeAreaCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPracticeAreaRepository _practiceAreaRepository;

        public DeletePracticeAreaCommandHandler(IMapper mapper, IPracticeAreaRepository practiceAreaRepository)
        {
            this._mapper = mapper;
            this._practiceAreaRepository = practiceAreaRepository;
        }

        public async Task<Unit> Handle(DeletePracticeAreaCommand request, CancellationToken cancellationToken)
        {
            var practiceAreaToDelete = await _practiceAreaRepository.GetByIdAsync(request.Id);

            if (practiceAreaToDelete == null)
                throw new NotFoundException(nameof(PracticeArea), request.Id);

            await _practiceAreaRepository.DeleteAsync(practiceAreaToDelete);

            return Unit.Value;
        }
    }
}
