using Microsoft.AspNetCore.Mvc;

namespace GaLegalGeorgia.Api.Middleware.Models
{
    public class CustomValidationProblemDetails : ProblemDetails
    {
      public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
