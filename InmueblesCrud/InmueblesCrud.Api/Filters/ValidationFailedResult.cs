
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace InmueblesCrud.Api.Filters
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(string Error, string ErrorDescription)
            : base(new ValidationResultModel(Error, ErrorDescription))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }

        public ValidationFailedResult(ValidationResult result)
            : base(new ValidationResultModel(result))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
