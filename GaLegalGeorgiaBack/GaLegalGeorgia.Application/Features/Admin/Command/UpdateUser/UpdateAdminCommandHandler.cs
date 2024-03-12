using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Application.Exceptions;
using GaLegalGeorgia.Application.Features.PracticeArea.Commands.UpdatePracticeArea;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Features.Admin.Command.UpdateUser
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;

        public UpdateAdminCommandHandler(IMapper mapper, IAdminRepository adminRepository)
        {
           _mapper = mapper;
           _adminRepository = adminRepository;
        }
        public async Task Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
          
            // validate incoming data
            var validator = new UpdateAdminCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Request", validationResult);
            }
            // convert to domain entity object
            var adminToUpdate = _mapper.Map<Domain.AdminModel>(request);

            // add to database
            //await _adminRepository.UpdateAsync(adminToUpdate);
        }
    }
}

