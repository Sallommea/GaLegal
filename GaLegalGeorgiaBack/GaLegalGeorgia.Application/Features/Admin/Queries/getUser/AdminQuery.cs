using MediatR;

namespace GaLegalGeorgia.Application.Features.Admin.Queries.getUser
{
    public record AdminQuery(string Email, string Password) : IRequest<string>;
}
