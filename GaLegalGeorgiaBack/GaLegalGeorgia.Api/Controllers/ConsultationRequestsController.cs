using GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.CreateConsultationRequest;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.DeleteConsultationRequest;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.UpdateStatusRequest;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetConsultationRequestDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GaLegalGeorgia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultationRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ConsultationRequestsController>
        //    [Authorize]
        [HttpGet("get-paginated/{pageNumber:int}/{itemsPerPage:int}")]
        public async Task<ActionResult<PaginatedListResult<ConsultationRequestDto>>> Get(int pageNumber, int itemsPerPage)
        {
            var result = await _mediator.Send(new GetConsultationRequestsQuery { PageNumber = pageNumber, ItemsPerPage = itemsPerPage });
            return Ok(result);
        }


        // GET api/<ConsultationRequestsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ConsultationRequestDetailsDto>> Get(int id)
        {
            var consultationRequestDetails = await _mediator.Send(new GetConsultationRequestDetailsQuery(id));
            return Ok(consultationRequestDetails);
        }

        // POST api/<ConsultationRequestsController>
        [HttpPost("create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateConsultationRequestCommand consultationRequest)
        {
            await _mediator.Send(consultationRequest);
            return NoContent();
        }


        // DELETE api/<ConsultationRequestsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteConsultationRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateStatus(UpdateConsultationStatusCommand updateStatus)
        { 
            await _mediator.Send(updateStatus);
            return NoContent();
        }

    }
}
