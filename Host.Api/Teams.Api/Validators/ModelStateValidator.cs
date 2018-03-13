using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Teams.Api.Validators
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ModelStateValidator : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // TODO: implement UnprocessableEntityObjectResult
            }
        }
    }
}