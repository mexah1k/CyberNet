using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.Exceptions
{
    public class UnprocessableEnttyObjectResult : ObjectResult
    {
        public UnprocessableEnttyObjectResult(ModelStateDictionary modelState)
            : base(new SerializableError(modelState))
        {
            Throw.IfNull(modelState);
            StatusCode = 422;
        }
    }
}