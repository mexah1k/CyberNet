using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;

namespace Tournament.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                await next(context);
            }
            catch (ItemNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.Unauthorized);
            }
            catch (JsonPatchException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
            }
            catch (ParameterForOrderExeption ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
            }
            catch (SqlException)
            {
                await HandleExceptionAsync(context, "Incorrect request exeption", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.InternalServerError);
                logger.LogError(default(EventId), ex, ex.Message); // todo: implement Logger (Sentry.io)
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string exceptionMessage, HttpStatusCode code)
        {
            return context.Response.WriteAsync(GetResponseBody(context, exceptionMessage, code));
        }

        private static string GetResponseBody(HttpContext context, string exceptionMessage, HttpStatusCode code)
        {
            var result = JsonConvert.SerializeObject(new { error = exceptionMessage });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return result;
        }
    }
}